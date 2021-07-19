using System.Linq;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Implementation.UserTournamentRepo
{
    public class MockUserTournamentRepo : IUserTournamentRepository
    {
        public IQueryable<TournamentWithUserDto> GetAUserWithHisTournaments(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}