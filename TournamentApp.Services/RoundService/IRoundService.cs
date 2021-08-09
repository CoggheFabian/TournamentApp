using System.Collections.Generic;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public interface IRoundService
    {
        public QuizRoundDto AddRoundToQuiz(QuizRoundDto quizDto, int quizId);

        List<TournamentWithAllRoundsDto> GetAllRoundFromATournament(int tournamentId);
        RoundUserPointsDto SavePointsForUserInRound(int roundId, int userId, int score = 0);
        void InsertUsersIntoTheRoundUserPoints(int roundId, List<PlayerInQuizDto> playerInQuiz, int scores = 0);
        void InsertUsersIntoTheRoundUserPoints(int roundId, List<UpdateScoreForRoundDto> playerInQuiz);
        public IEnumerable<GetUserPointDto> GetPlayersFromARound(int quizId);

        public RoundUserPointsDto UpdateScoreForPlayer(int userId, int score, int roundId);


    }
}