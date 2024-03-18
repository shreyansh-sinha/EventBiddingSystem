using EventBiddingSystem.Model;

namespace EventBiddingSystem.Util
{
    public class LowBidWinningStrategy : IWinningStrategy
    {
        public (User,Bid) ComputeWinner(Dictionary<User, List<Bid>> UserBids)
        {
            User user = null;
            int lowestBidAmount = int.MaxValue;
            Bid lowestBid = null;

            foreach (var userBid in UserBids)
            {
                User currUser = userBid.Key;
                List<Bid> bids = userBid.Value;

                foreach (var bid in bids)
                {
                    if(lowestBidAmount > bid.Amount)
                    {
                        lowestBidAmount = bid.Amount;
                        lowestBid = bid;
                        user = currUser;
                    }
                    else if(lowestBidAmount == bid.Amount && lowestBid.BidPlaceTime < bid.BidPlaceTime)
                    {
                        lowestBid = bid;
                        lowestBidAmount = bid.Amount;
                        user = currUser;
                    }
                }
            }

            return (user, lowestBid);
        }
    }
}
