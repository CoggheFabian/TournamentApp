using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.UserService
{
    public interface IUserService
    {
        CreatedUserDto Register(UserRegisterDto userRegisterDto);

        void Login();
    }
}