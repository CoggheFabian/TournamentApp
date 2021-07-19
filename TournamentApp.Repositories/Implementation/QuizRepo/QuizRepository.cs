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

    }
}