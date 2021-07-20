using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.RoundUserPointsRepo
{
    public class RoundUserPointsRepository : CrudRepository<RoundUserPoints>, IRoundUserPointsRepository
    {
        public RoundUserPointsRepository(TournamentDbContext context) : base(context)
        {

        }
    }
}