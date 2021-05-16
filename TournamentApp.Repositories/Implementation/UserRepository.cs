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

        public User Testing(string username, string password)
        {
            var users = new List<User>();
                users.Add(
                    new User {
                        Id = 1,
                        Name = "goku",
                        Password = "goku",
                        Role = "manager",
                    }
                );

                users.Add(
                    new User {
                        Id = 2,
                        Name = "goku",
                        Password = "goku",
                        Role = "manager" }
                );

                users.Add(
                    new User {
                        Id = 3,
                        Name = "goku",
                        Password = "goku",
                        Role = "manager" }
                );
                return users.FirstOrDefault(x => x.Name.ToLower() == username.ToLower());
        }
    }
}