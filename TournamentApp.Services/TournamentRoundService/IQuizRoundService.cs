using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public interface IQuizRoundService
    {
        CreatedQuizDto CreateQuiz(CreateQuizDto createQuizDto, string userEmail);
    }
}