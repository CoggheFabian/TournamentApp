using TournamentApp.Repositories.Implementation;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register()
        {
            throw new System.NotImplementedException();
        }

        public void Login()
        {
            throw new System.NotImplementedException();
        }
    }
}