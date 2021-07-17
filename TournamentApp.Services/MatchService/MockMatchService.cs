using System.Collections.Generic;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.MatchRepo;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.MatchService
{
    public class MockMatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MockMatchService()
        {
            _matchRepository = new MockMatchRepository();
        }

        public void BulkInsertMatches(List<Match> matchesToInsert)
        {
            _matchRepository.BulkInsertMatches(matchesToInsert);
        }

    }
}