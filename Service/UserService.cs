using EventBiddingSystem.Model;
using EventBiddingSystem.Repository;

namespace EventBiddingSystem.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(string id, string name, int coins)
        {
            User user = _userRepository.CreateUser(id, name, coins);
            return user;
        }

        public void ShowBalance(string id)
        {
            _userRepository.ShowBalance(id);
        }
    }
}
