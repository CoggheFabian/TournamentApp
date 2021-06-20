using System.Collections.Generic;
using TournamentApp.Model;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IMatchRepository : ICrudRepository<Match>
    {
         void BulkInsertMatches(List<Match> matches);
    }
}