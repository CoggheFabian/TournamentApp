using System.Collections.Generic;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public interface IRoundService
    {
        public QuizRoundDto AddRoundToQuiz(QuizRoundDto quizDto, int quizId);

        List<TournamentWithAllRoundsDto> GetAllRoundFromATournament(int tournamentId);
        RoundUserPointsDto InsertPointsForRound(int roundId, int userId, int score = 0);

    }
}