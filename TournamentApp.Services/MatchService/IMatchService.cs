using System.Collections.Generic;
using TournamentApp.Model;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.MatchService
{
    public interface IMatchService
    {
        public void BulkInsertMatches(List<Match> matchesToInsert);
    }
}