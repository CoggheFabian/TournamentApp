using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Interfaces
{
    public interface IUserTournamentRepository
    {
        Dictionary<int, string> GetAUserWithHisTournaments(int userId);
    }
}
