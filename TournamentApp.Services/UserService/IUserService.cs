using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.UserService
{
    public interface IUserService
    {
        void Register(UserRegisterDto userRegisterDto);

        void Login();
    }
}