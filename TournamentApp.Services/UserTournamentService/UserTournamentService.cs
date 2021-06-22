using System.Collections.Generic;
using System.Linq;
using TournamentApp.Repositories.Implementation.UserTournamentRepo;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.UserTournamentService
{
    public class UserTournamentService : IUserTournamentService
    {
        private readonly UserTournamentRepository _userTournamentRepository;

        public UserTournamentService(UserTournamentRepository userTournamentRepository)
        {
            _userTournamentRepository = userTournamentRepository;
        }

        public UserWithHisTournamentsDto GetAUserWithHisTournaments(int userId)
        {
            var tournaments = _userTournamentRepository.GetAUserWithHisTournaments(userId);

            var listOfMatches = new List<TournamentWithUserDto>();
            foreach (var tournament in tournaments)
            {
                listOfMatches.AddRange(tournament.(singleTournament => new TournamentWithUserDto {TournamentId = singleTournament.TournamentId, TournamentName = singleTournament.TournamentName}));
            }

            var duplicatesValues = listOfMatches.GroupBy(tour => tour.TournamentId).Where(g => g.Count() > 1).Select(g => g.Key);
            foreach (var duplicateId in duplicatesValues)
            {
                listOfMatches.RemoveAt(duplicateId);
            }
            return new UserWithHisTournamentsDto {TournamentWithUserDtos = listOfMatches};
        }
    }
}