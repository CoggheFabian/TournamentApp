using System.Collections.Generic;
using TournamentApp.Model;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IQuizRepository : ICrudRepository<Quiz>
    {
        void StopQuiz(int quizId, int UserId);
    }
}