using System.Collections.Generic;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public interface IRoundService
    {
        public QuizRoundDto AddRoundToQuiz(CreatedQuizDto addedQuiz);

        List<TournamentWithAllRoundsDto> GetAllRoundFromATournament(int tournamentId);
        RoundUserPointsDto InsertPointsForRound(int roundId, int userId, int score = 0);

    }
}