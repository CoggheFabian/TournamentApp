using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.TournamentRepo
{
    public class MockTournamentRepo : ITournamentRepository
    {
        private List<Tournament> _tournaments;

        public MockTournamentRepo()
        {
            _tournaments = new List<Tournament>();
        }
        public IQueryable<Tournament> Get(int id)
        {
            return _tournaments.Where(tournament => tournament.Id == id).AsQueryable();
        }

        public IQueryable<Tournament> Add(Tournament entity)
        {
            _tournaments.Add(entity);
            return entity.ToQueryable();
        }

        public IQueryable<Tournament> Delete(int id)
        {
            var tournamentToRemove = Get(id);
            _tournaments.Remove(tournamentToRemove.First());
            return tournamentToRemove;
        }

        public IQueryable<Tournament> Update(int id, Tournament entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Tournament> GetAll()
        {
            return _tournaments.AsQueryable();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}