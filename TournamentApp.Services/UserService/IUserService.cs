using System.Collections.Generic;
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

        GetUserDto FindUserById(int id);

        IEnumerable<PlayerInQuizDto> GetPlayersForTournament(List<PlayerInQuizDto> playerInTournamentDtos);

        List<GetUserDto> GetAllUsers();

        Dictionary<string, int> GetLeaderBord();

    }
}