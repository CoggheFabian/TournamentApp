using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _repository;
        public QuizService(IQuizRepository repository)
        {
            _repository = repository;
        }


        public CreatedQuizDto AddQuiz(CreateQuizDto createQuizDto)
        {
            var quiz = _repository.Add(new Quiz {Date = createQuizDto.Date, QuizName = createQuizDto.Name, QuizOwnerId = createQuizDto.QuizOwnerId}).First();
            _repository.Save();
            return new CreatedQuizDto {Id = quiz.Id, Name = quiz.QuizName, Date = quiz.Date};
        }
    }
}