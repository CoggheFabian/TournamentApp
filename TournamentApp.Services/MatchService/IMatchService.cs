using System.Collections.Generic;
using TournamentApp.Model;

namespace TournamentApp.Services.MatchService
{
    public interface IMatchService
    {
        public void BulkInsertMatches(List<Match> matchesToInsert);
    }
}