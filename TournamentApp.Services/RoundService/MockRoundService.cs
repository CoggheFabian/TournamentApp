using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public class MockRoundService : IRoundService
    {

        private readonly IRoundRepository _roundRepository;

        public MockRoundService(IRoundRepository roundRepository)
        {
            _roundRepository = roundRepository;
        }

        public MainRoundForTournamentDto AddMainRoundForTournament(CreatedTournamentDto addedTournament)
        {
            var mainRound = _roundRepository.Add(new Round
            {
                TournamentId = addedTournament.Id
            }).First();

            _roundRepository.Save();
            return new MainRoundForTournamentDto {MainRoundId = mainRound.Id};
        }
    }
}