using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public interface IRoundService
    {
        public MainRoundForTournamentDto AddMainRoundForTournament(CreatedTournamentDto addedTournament);
    }
}