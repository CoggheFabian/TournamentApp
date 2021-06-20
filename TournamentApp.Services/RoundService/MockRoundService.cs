using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.RoundRepo;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public class MockRoundService : IRoundService
    {

        private readonly IRoundRepository _roundRepository;

        public MockRoundService()
        {
            _roundRepository = new MockRoundRepository();
        }

        public MainRoundForTournamentDto AddMainRoundForTournament(CreatedTournamentDto addedTournament)
        {
            var mainRound = _roundRepository.Add(new Round
            {
                TournamentId = addedTournament.Id
            }).First();

            return new MainRoundForTournamentDto {MainRoundId = mainRound.Id};
        }
    }
}