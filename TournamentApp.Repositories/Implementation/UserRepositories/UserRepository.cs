using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Repositories.Interfaces.UserRepositories;

namespace TournamentApp.Repositories.Implementation.UserRepositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        protected UserRepository(TournamentDbContext context) : base(context)
        {

        }
    }
}