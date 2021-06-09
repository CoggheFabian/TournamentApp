using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.TournamentService
{
    public interface ITournamentService
    {
        BaseTournamentDto AddTournament(CreateTournamentDto dto);
    }
}