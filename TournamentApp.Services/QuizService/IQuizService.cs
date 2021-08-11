using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.QuizService
{
    public interface IQuizService
    {
        CreatedQuizDto AddQuiz(CreateQuizDto createQuizDto);
        public QuizDto GetQuiz(int id);

        public void StopQuiz(int quizId, int userId);

    }
}