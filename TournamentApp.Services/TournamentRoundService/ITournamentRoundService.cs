using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public interface ITournamentRoundService
    {
        void CreateTournament(CreateTournamentDto createTournamentDto);
    }
}