using EventBiddingSystem.Model;

namespace EventBiddingSystem.Repository
{
    public interface IEventRepository
    {
        public Event CreateEvent(string name, string prize, DateTime creationDate, string id);

        public void RegisterParticipant(User user, string eventId);

        public void SubmitBid(string memberId, string eventId, List<Bid> bids);

        public void ChooseWinner(string eventId);
    }
}
