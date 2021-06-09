using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public class TournamentRoundService : ITournamentRoundService
    {
        private readonly ITournamentRepository _tournamentRepository;
        public TournamentRoundService(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public void CreateTournament(CreateTournamentDto createTournamentDto)
        {

        }
    }
}