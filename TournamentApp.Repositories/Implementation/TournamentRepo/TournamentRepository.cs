using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.TournamentRepo
{
    public class TournamentRepository : CrudRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(TournamentDbContext context) : base(context)
        {
        }
    }
}