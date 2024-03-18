using EventBiddingSystem.Model;

namespace EventBiddingSystem.Repository
{
    public class UserRepository : IUserRepository   
    {
        Dictionary<string, User> _users;
        public UserRepository() 
        {
            _users = new Dictionary<string, User>();
        }

        public User CreateUser(string id, string name, int coins)
        {
            User user = new User(id, name, coins);
            _users.Add(user.Id, user);
            return user;
        }

        public User GetUser(string id) { return _users[id]; }

        public bool UserExists(string id) { return _users.ContainsKey(id); }

        public void ShowBalance(string id)
        {
            foreach (var user in _users.Values)
            {
                if(user.Id == id)
                {
                    Console.WriteLine(user.Name + " has " + user.SuperCoins + " coins.");
                }
            }
            return;
        }
    }
}
