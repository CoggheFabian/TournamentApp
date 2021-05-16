using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IUserRepository: ICrudRepository<User>
    {
        IQueryable<User> GetUsersByEmail(string email);
    }
}