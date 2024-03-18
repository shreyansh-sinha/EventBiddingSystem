using EventBiddingSystem.Model;

namespace EventBiddingSystem.Service
{
    public interface IEventService
    {
        public void ChooseWinner(string eventId);

        public Event AddEvent(string name, string prize, DateTime creationDate, string id);

        public void RegisterParticipant(string memberId, string eventId);

        public void SubmitBid(string memberId, string eventId, List<int> bidAmount);
    }
}
