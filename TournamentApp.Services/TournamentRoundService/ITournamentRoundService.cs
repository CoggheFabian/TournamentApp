using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public interface ITournamentRoundService
    {
        public void CreateTournament(CreateTournamentDto createTournamentDto);
    }
}