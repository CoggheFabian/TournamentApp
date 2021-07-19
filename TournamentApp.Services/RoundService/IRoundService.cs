using System.Collections.Generic;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public interface IRoundService
    {
        public MainRoundForTournamentDto AddMainRoundForTournament(CreatedQuizDto addedQuiz);

        List<TournamentWithAllRoundsDto> GetAllRoundFromATournament(int tournamentId);

    }
}