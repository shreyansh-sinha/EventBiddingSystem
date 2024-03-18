namespace EventBiddingSystem.Model
{
    public class Event
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Prize {  get; set; }

        public DateTime CreationTime { get; set; }

        public List<User> Participants { get; set; }

        public Event(DateTime creationTime, string name, string prize, string id)
        {
            Id = id;
            Name = name;
            Prize = prize;
            Participants = new List<User>();
            CreationTime = creationTime;

        }
    }
}
