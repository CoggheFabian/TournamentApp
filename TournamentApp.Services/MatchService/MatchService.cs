using System.Collections.Generic;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Services.MatchService
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public void BulkInsertMatches(List<Match> matchesToInsert)
        {
            _matchRepository.BulkInsertMatches(matchesToInsert);
        }
    }
}