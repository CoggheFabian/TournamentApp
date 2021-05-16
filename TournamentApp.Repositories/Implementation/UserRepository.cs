using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(TournamentDbContext context) : base(context)
        {

        }
    }
}