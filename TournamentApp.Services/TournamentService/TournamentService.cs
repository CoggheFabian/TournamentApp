using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentService
{
    public class TournamentService : ITournamentService
    {
        private readonly IQuizRepository _repository;
        public TournamentService(IQuizRepository repository)
        {
            _repository = repository;
        }


        public CreatedTournamentDto AddTournament(CreateQuizDto createQuizDto)
        {
            Quiz quiz = _repository.Add(new Quiz {Date = createQuizDto.TournamentDate, QuizName = createQuizDto.Name,}).First();
            _repository.Save();
            return new CreatedTournamentDto {Id = quiz.Id, Name = quiz.QuizName, TournamentDate = quiz.Date};
        }
    }
}