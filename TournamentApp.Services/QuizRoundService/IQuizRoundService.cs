using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.QuizRoundService
{
    public interface IQuizRoundService
    {
        CreatedQuizDto CreateQuiz(CreateQuizDto createQuizDto, string userEmail);
    }
}