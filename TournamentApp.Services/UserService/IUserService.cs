using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.UserService
{
    public interface IUserService
    {
        CreatedUserDto Register(UserRegisterDto userRegisterDto);

        bool GetUserByEmail(string email);

        void Login();
    }
}