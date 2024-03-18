namespace EventBiddingSystem.Model
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int SuperCoins { get; set; }

        public User(string id, string name, int coins)
        {
            Id = id;
            SuperCoins = coins;
            Name = name;
        }
    }
}
