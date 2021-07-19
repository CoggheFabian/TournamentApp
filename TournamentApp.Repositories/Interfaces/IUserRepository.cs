using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IUserRepository: ICrudRepository<User>
    {
        IQueryable<User> GetUsersByEmail(string email);

        IEnumerable<User> GetPlayersForTournament(List<int> playersIds);

        IEnumerable<Leaderboard> GetLeaderBord();

    }
}