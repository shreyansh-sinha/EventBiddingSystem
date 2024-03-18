namespace EventBiddingSystem.Model
{
    public class Bid
    {
        public User User { get; set; }

        public int Amount { get; set; } 

        public DateTime BidPlaceTime { get; set; }

        public Bid(User user, int amount)
        {
            User = user;
            Amount = amount;
            BidPlaceTime = DateTime.Now;
        }
    }
}
