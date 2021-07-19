using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.TournamentRepo
{
    public class MockQuizRepo : IQuizRepository
    {
        private List<Quiz> _tournaments;

        public MockQuizRepo()
        {
            _tournaments = new List<Quiz>();
        }
        public IQueryable<Quiz> Get(int id)
        {
            return _tournaments.Where(tournament => tournament.Id == id).AsQueryable();
        }

        public IQueryable<Quiz> Add(Quiz entity)
        {
            _tournaments.Add(entity);
            return entity.ToQueryable();
        }

        public IQueryable<Quiz> Delete(int id)
        {
            var tournamentToRemove = Get(id);
            _tournaments.Remove(tournamentToRemove.First());
            return tournamentToRemove;
        }

        public IQueryable<Quiz> Update(int id, Quiz entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Quiz> GetAll()
        {
            return _tournaments.AsQueryable();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}