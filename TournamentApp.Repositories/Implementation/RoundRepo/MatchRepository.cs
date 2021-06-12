using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.RoundRepo
{
    public class MatchRepository : CrudRepository<Match>, IMatchRepository
    {
        private readonly TournamentDbContext _context;

        protected MatchRepository(TournamentDbContext context) : base(context)
        {
            _context = context;
        }


        public int BulkInsertMatches()
        {
            throw new System.NotImplementedException();
        }
    }
}