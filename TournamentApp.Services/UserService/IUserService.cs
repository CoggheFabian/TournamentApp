using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.UserService
{
    public interface IUserService
    {
        object Register(UserRegisterDto userRegisterDto);

        void Login();
    }
}