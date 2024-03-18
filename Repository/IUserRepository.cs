using EventBiddingSystem.Model;

namespace EventBiddingSystem.Repository
{
    public interface IUserRepository
    {
        public User CreateUser(string id, string name, int coins);

        public void ShowBalance(string id);

        public User GetUser(string id);

        public bool UserExists(string id);
    }
}
