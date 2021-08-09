using System.Linq;
using TournamentApp.Model;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IRoundUserPointsRepository : ICrudRepository<RoundUserPoints>
    {
        public IQueryable<RoundUserPoints> GetPlayersFromQuiz(int quizId);
        public void UpdateScoreForPlayer(int userId, int score, int roundId);




    }
}