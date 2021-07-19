using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IRoundRepository : ICrudRepository<QuizRound>
    {
        IQueryable<QuizRound> MakeMainRoundForTournament(CreatedTournamentDto createdTournamentDto);
        IQueryable<QuizRound> GetAllRoundFromATournament(int tournamentId);

    }
}