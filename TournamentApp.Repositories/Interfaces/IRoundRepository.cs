using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IRoundRepository : ICrudRepository<Round>
    {
        IQueryable<Round> MakeMainRoundForTournament(CreatedTournamentDto createdTournamentDto);
        IQueryable<Round> GetAllRoundFromATournament(int tournamentId);

    }
}