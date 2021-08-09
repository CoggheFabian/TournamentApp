using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.QuizRepo
{
    public class MockQuizRepo : IQuizRepository
    {
        private List<Quiz> _quizzes;

        public MockQuizRepo()
        {
            _quizzes = new List<Quiz>();
        }
        public IQueryable<Quiz> Get(int id)
        {
            return _quizzes.Where(tournament => tournament.Id == id).AsQueryable();
        }

        public IQueryable<Quiz> Add(Quiz entity)
        {
            _quizzes.Add(entity);
            return entity.ToQueryable();
        }

        public IQueryable<Quiz> Delete(int id)
        {
            var tournamentToRemove = Get(id);
            _quizzes.Remove(tournamentToRemove.First());
            return tournamentToRemove;
        }

        public IQueryable<Quiz> Update(int id, Quiz entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Quiz> GetAll()
        {
            return _quizzes.AsQueryable();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void StopQuiz(int quizId, int UserId)
        {
            throw new System.NotImplementedException();
        }

        public void StopQuiz(int quizId)
        {
            throw new System.NotImplementedException();
        }
    }
}