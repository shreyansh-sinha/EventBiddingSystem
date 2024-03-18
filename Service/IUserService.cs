using EventBiddingSystem.Model;

namespace EventBiddingSystem.Service
{
    public interface IUserService
    {
        public User CreateUser(string id, string name, int coins);

        public void ShowBalance(string id);
    }
}
