using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.MatchRepository
{
    public class MockMatchRepository : IMatchRepository
    {
        private readonly List<Match> _matches;

        public MockMatchRepository()
        {
            _matches = new List<Match>();
        }

        public IQueryable<Match> Get(int id)
        {
            return _matches.Where(x => x.Id == id).AsQueryable();
        }

        public IQueryable<Match> Add(Match entity)
        {
            _matches.Add(entity);
            return Get(entity.Id);
        }

        public IQueryable<Match> Delete(int id)
        {
            var match = Get(id);
            _matches.Remove(Get(id).First());
            return match;
        }

        public IQueryable<Match> Update(int id, Match entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Match> GetAll()
        {
            return _matches.AsQueryable();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void BulkInsertMatches(List<Match> matches)
        {
            _matches.AddRange(matches);
        }
    }
}