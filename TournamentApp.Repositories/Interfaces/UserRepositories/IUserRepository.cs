using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;

namespace TournamentApp.Repositories.Interfaces.UserRepositories
{
    public interface IUserRepository: ICrudRepository<User>
    {
        public static User Testing(string username, string password)
        {
            var users = new List<User>();
            users.Add(
                new User {
                    Id = 1,
                    Player = new Player
                    {
                        Id = 1,
                        Name = "goku"
                    },
                Password = "goku",
                Role = "manager" }
            );

            users.Add(
                new User {
                    Id = 2,
                    Player = new Player
                    {
                        Id = 2,
                        Name = "goku"
                    },
                    Password = "goku",
                    Role = "manager" }
            );

            users.Add(
                new User {
                    Id = 3,
                    Player = new Player
                    {
                        Id = 3,
                        Name = "goku"
                    },
                    Password = "goku",
                    Role = "manager" }
            );
            return users.FirstOrDefault(x => x.Player.Name.ToLower() == username.ToLower());
        }
    }
}