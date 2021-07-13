using System;
using System.Collections.Generic;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.UserTournamentService
{
    public interface IUserTournamentService
    {
        Dictionary<int, string> GetAUserWithHisTournaments(int userId);
        UserWithHisTournamentsDto GetAUserWithHisDetailsAndTournaments(int userId);


    }
}