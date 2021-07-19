using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.QuizService
{
    public interface IQuizService
    {
        CreatedQuizDto AddQuiz(CreateQuizDto createQuizDto);
    }
}