using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces.TournamentRepositories;

namespace TournamentApp.Repositories.Implementation.TournamentRepositories
{
    public class TournamentRepository : CrudRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(TournamentDbContext context) : base(context)
        {
        }
    }
}