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

        User FindUserById(int id);

        IEnumerable<PlayerInTournamentDto> GetPlayersForTournament(List<PlayerInTournamentDto> playerInTournamentDtos);

        List<GetUserDto> GetAllUsers();

        Dictionary<string, int> GetLeaderBord();

    }
}