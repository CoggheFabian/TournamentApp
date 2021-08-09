using System;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.QuizRepo;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.QuizService
{
    public class MockQuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public MockQuizService()
        {
            _quizRepository = new MockQuizRepo();
        }

        public CreatedQuizDto AddQuiz(CreateQuizDto createQuizDto)
        {
            var tournament = _quizRepository.Add(new Quiz
            {
                Date = createQuizDto.Date,
                Id = 3,
                QuizName = createQuizDto.Name
            }).First();

            return new CreatedQuizDto {Name = tournament.QuizName, Date = DateTime.Now};
        }

        public QuizDto GetQuiz(int id)
        {
            throw new NotImplementedException();
        }

        public void StopQuiz(int quizId, int userId)
        {
            throw new NotImplementedException();
        }

        public void StopQuiz(int quizId)
        {
            throw new NotImplementedException();
        }
    }
}