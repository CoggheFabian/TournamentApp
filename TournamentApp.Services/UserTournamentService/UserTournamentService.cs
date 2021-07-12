using System.Collections.Generic;
using System.Linq;
using TournamentApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Services.UserTournamentService
{
    public class UserTournamentService : IUserTournamentService
    {
        private readonly IUserTournamentRepository _userTournamentRepository;

        public UserTournamentService(IUserTournamentRepository userTournamentRepository)
        {
            _userTournamentRepository = userTournamentRepository;
        }

        public UserWithHisTournamentsDto GetAUserWithHisTournaments(int userId)
        {
            var tournaments = _userTournamentRepository.GetAUserWithHisTournaments(userId);

            var listOfMatches = new List<TournamentWithUserDto>();
            foreach (KeyValuePair<int, string> tournament in tournaments)
            {
                listOfMatches.Add(new TournamentWithUserDto
                {
                    TournamentId = tournament.Key,
                    TournamentName = tournament.Value
                });
            }
            var duplicatesValues = listOfMatches.GroupBy(tour => tour.TournamentId).Where(g => g.Count() > 1).Select(g => g.Key);
            listOfMatches.RemoveAll(item => duplicatesValues.Contains(item.TournamentId));
            return new UserWithHisTournamentsDto {TournamentWithUserDtos = listOfMatches};
        }
    }
}