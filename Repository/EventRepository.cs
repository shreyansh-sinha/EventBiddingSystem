using EventBiddingSystem.Model;
using EventBiddingSystem.Util;

namespace EventBiddingSystem.Repository
{
    public class EventRepository : IEventRepository
    { 
        Dictionary<string, Event> eventsMap;
        Dictionary<DateTime, Event> eventCalendar;
        Dictionary<Event, Dictionary<User, List<Bid>>> userBiddings;
        private readonly IUserRepository userRepository;
        private readonly IWinningStrategy winningStrategy;

        int MAX_BIDS_ALLOWED = 5;

        public EventRepository(IUserRepository userRepository, IWinningStrategy winningStrategy)
        {
            eventsMap = new Dictionary<string, Event>();
            eventCalendar = new Dictionary<DateTime, Event>();
            userBiddings = new Dictionary<Event, Dictionary<User, List<Bid>>>();
            this.userRepository = userRepository;
            this.winningStrategy = winningStrategy;
        }

        public Event CreateEvent(string name, string prize, DateTime creationDate, string id)
        {
            if(eventCalendar.ContainsKey(creationDate.Date))
            {
                Console.WriteLine("Event already exists for given date");
            }

            Event @event = new Event(creationDate, name, prize, id);
            eventCalendar.Add(creationDate.Date, @event);
            eventsMap.Add(id, @event);
            return @event;
        }

        public void RegisterParticipant(User user, string eventId)
        {
            if(eventsMap.ContainsKey(eventId))
            {
                Event @event = eventsMap[eventId];
                @event.Participants.Add(user);
                Dictionary<User, List<Bid>> userBidsList = new();
                userBidsList.Add(user, new List<Bid>());
                userBiddings.Add(@event, userBidsList);
            }
        }

        public void SubmitBid(string memberId, string eventId, List<Bid> bids)
        {
            if(!eventsMap.ContainsKey(eventId))
            {
                Console.WriteLine("Event does not exist");
                return;
            }

            Event @event = eventsMap[eventId];
            TimeSpan difference = DateTime.Now - @event.CreationTime;
            if(difference.TotalHours > 24)
            {
                Console.WriteLine("Event has expired");
                return;
            }

            User user = this.userRepository.GetUser(memberId);

            if(user != null)
            {
                if(!@event.Participants.Exists(p => p.Id == user.Id))
                {
                    Console.WriteLine("User is not registered in this event");
                    return;
                }
                
                if(bids.Count > MAX_BIDS_ALLOWED)
                {
                    Console.WriteLine($"You cannot submit more than {MAX_BIDS_ALLOWED} bids");
                    return;
                }

                if(bids.DistinctBy(x => x.Amount).Count() < bids.Count)
                {
                    Console.Write("You cannot submit the same bid more than once");
                    return;
                }

                int maxBidValue = bids.Max(x => x.Amount);
                if(maxBidValue < 0)
                {
                    Console.WriteLine("You cannot submit a negative bid");
                    return;
                }

                if(user.SuperCoins < maxBidValue)
                {
                    Console.WriteLine("Not enough coins to place bid");
                    return;
                }

                var userBidding = userBiddings[@event];
                bids.ForEach(bid => userBidding[user].Add(bid));
            }
            else
            {
                Console.WriteLine("User does not exist");
                return;
            }
        }

        public void ChooseWinner(string eventId)
        {
            if(!eventsMap.ContainsKey(eventId))
            {
                Console.WriteLine("Event does not exist");
                return;
            }

            Event @event = eventsMap[eventId];

            (User, Bid) winner = winningStrategy.ComputeWinner(userBiddings[@event]);
            User user = winner.Item1;
            Bid bid = winner.Item2;

            user.SuperCoins -= bid.Amount;

            if (winner.Item1 != null && winner.Item2 != null)
            {
                Console.WriteLine("Winner: " + user.Name + "won " + @event.Prize + " with " + bid.Amount + " coins");
            }
        }
    }
}
