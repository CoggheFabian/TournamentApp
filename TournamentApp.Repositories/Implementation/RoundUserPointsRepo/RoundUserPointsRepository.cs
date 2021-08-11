using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.RoundUserPointsRepo
{
    public class RoundUserPointsRepository : CrudRepository<RoundUserPoints>, IRoundUserPointsRepository
    {
        private readonly TournamentDbContext _context;
        public RoundUserPointsRepository(TournamentDbContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable<RoundUserPoints> GetPlayersFromQuiz(int quizId)
        {
            var firstRoundIdOfQuiz = _context.Rounds
                .Join(_context.Quizzes, round => round.QuizId, quiz => quiz.Id, (round, quiz) => new {round, quiz})
                .Where(arg => arg.quiz.Id == quizId)
                .Min(arg => arg.round.Id);

          return _context.RoundUserPoints.FromSqlRaw("select Id ,QuizRoundId, UserId, RoundId, score from RoundUserPoints where RoundId = {0}", firstRoundIdOfQuiz);
        }

        public void UpdateScoreForPlayer(int userId, int score, int roundId)
        {
            var roundUserPoints = _context.RoundUserPoints
                 .Where((points) => points.UserId == userId)
                 .First(points => points.RoundId == roundId);
            roundUserPoints.Score = score;
            _context.SaveChanges();
        }


    }
}