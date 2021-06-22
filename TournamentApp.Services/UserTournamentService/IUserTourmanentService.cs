using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.UserTournamentService
{
    public interface IUserTournamentService
    {
        UserWithHisTournamentsDto GetAUserWithHisTournaments(int userId);

    }
}