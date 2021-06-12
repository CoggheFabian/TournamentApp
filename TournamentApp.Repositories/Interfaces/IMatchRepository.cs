using System.Collections.Generic;
using TournamentApp.Model;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IMatchRepository : ICrudRepository<Match>
    {
         //int BulkInsertMatches(List<PlayerInMatchDto> playerInMatchDtos);
    }
}