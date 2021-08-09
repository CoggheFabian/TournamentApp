using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.QuizRoundService
{
    public interface IQuizRoundService
    {
        CreatedQuizDto CreateQuiz(CreateQuizDto createQuizDto, string userEmail);

        QuizRoundDto AddNewRound(QuizRoundDto quizRoundDto, int quizId, string userEmail);

        public StopQuizDto StopQuiz(int quizId, string userEmail);
    }
}