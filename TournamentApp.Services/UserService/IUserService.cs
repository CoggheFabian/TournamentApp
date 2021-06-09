using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.UserService
{
    public interface IUserService
    {
        CreatedUserDto Register(UserRegisterDto userRegisterDto);

        bool CheckIfEmailIsAlreadyRegistered(string email);

        GetUserDto GetUserByEmail(string email);

        LoggedInUserDto Login(UserLoginDto userLoginDto);

    }
}