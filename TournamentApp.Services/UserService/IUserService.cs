using TournamentApp.Model;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.UserService
{
    public interface IUserService
    {
        CreatedUserDto Register(UserRegisterDto userRegisterDto);

        bool CheckIfEmailIsAlreadyRegistered(string email);

        GetUserDto GetUserByEmail(string email);

        LoggedInUserDto Login(UserLoginDto userLoginDto);

        User FindUserById(int id);

    }
}