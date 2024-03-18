using EventBiddingSystem.Model;

namespace EventBiddingSystem.Util
{
    public interface IWinningStrategy
    {
        public (User,Bid) ComputeWinner(Dictionary<User, List<Bid>> UserBids);
    }
}
