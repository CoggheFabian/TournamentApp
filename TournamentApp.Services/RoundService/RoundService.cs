using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;

        public RoundService(IRoundRepository roundRepository)
        {
            _roundRepository = roundRepository;
        }


        public MainRoundForTournamentDto AddMainRoundForTournament(CreatedTournamentDto addedTournament)
        {
            var mainRound = _roundRepository.Add(new Round
            {
                TournamentId = addedTournament.Id,
                LoserNodeId = 0,
                PreviousRoundId = 0,
                WinnerNodeId = 0,
                NodeSubRoundId = 0
            }).First();

            _roundRepository.Save();
            return new MainRoundForTournamentDto {MainRoundId = mainRound.Id};
        }
    }
}