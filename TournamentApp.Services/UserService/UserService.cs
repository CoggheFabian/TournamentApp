using TournamentApp.Repositories.Implementation;
using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(UserRegisterDto userRegisterDto)
        {

        }

        public void Login()
        {
            throw new System.NotImplementedException();
        }
    }

}