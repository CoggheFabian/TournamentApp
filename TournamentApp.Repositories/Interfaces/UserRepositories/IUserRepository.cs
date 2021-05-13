using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;

namespace TournamentApp.Repositories.Interfaces.UserRepositories
{
    public interface IUserRepository: ICrudRepository<User>
    {
        public User Testing(string username, string password);

    }
}