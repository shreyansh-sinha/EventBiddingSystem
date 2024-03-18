using EventBiddingSystem.Model;
using EventBiddingSystem.Repository;

namespace EventBiddingSystem.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        private readonly IUserRepository userRepository;
        public EventService(IEventRepository eventRepository, IUserRepository userRepository)
        {
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
        }

        public Event AddEvent(string eventId, string prize, DateTime creationDate, string id)
        {
            Event @event = eventRepository.CreateEvent(eventId, prize, creationDate, id);
            return @event;
        }

        public void ChooseWinner(string eventId)
        {
            eventRepository.ChooseWinner(eventId);
        }

        public void RegisterParticipant(string memberId, string eventId)
        {
            User user = this.userRepository.GetUser(memberId);       
            eventRepository.RegisterParticipant(user, eventId);
        }

        public void SubmitBid(string memberId, string eventId, List<int> bidAmount)
        {
            User user = this.userRepository.GetUser(memberId);
            List<Bid> bids = new List<Bid>();
            foreach (var amount in bidAmount)
            {
                Bid bid = new Bid(user, amount);
                bids.Add(bid);
            }
            eventRepository.SubmitBid(memberId, eventId, bids);
        }
    }
}
