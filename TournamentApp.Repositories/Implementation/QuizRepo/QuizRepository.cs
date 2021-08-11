using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.QuizRepo
{
    public class QuizRepository : CrudRepository<Quiz>, IQuizRepository
    {
        private TournamentDbContext _context;
        public QuizRepository(TournamentDbContext context) : base(context)
        {
            _context = context;
        }

        public void StopQuiz(int quizId, int userId)
        {
            var quiz = Get(quizId).First();
            if (quiz.QuizOwnerId != userId) return;
            quiz.IsQuizFinished = true;
            Save();
        }
    }
}