using System.Collections.Generic;

using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.UserTournamentService
{
    public class UserTournamentService : IUserTournamentService
    {
        private readonly IUserTournamentRepository _userTournamentRepository;
        private readonly IUserService _userService;

        public UserTournamentService(IUserTournamentRepository userTournamentRepository, IUserService userService)
        {
            _userTournamentRepository = userTournamentRepository;
            _userService = userService;
        }

        public Dictionary<int, string> GetAUserWithHisTournaments(int userId)
        {
            Dictionary<int, string> tournaments = new Dictionary<int, string>();
            var tournamentsQueryAble = _userTournamentRepository.GetAUserWithHisTournaments(userId);

            foreach (var tournamentWithUserDto in tournamentsQueryAble)
            {
                if (!tournaments.ContainsKey(tournamentWithUserDto.TournamentId))
                    tournaments.Add(tournamentWithUserDto.TournamentId, tournamentWithUserDto.TournamentName);
            }

            return tournaments;
        }

        public UserWithHisTournamentsDto GetAUserWithHisDetailsAndTournaments(int userId)
        {
            return new UserWithHisTournamentsDto {Tournaments = GetAUserWithHisTournaments(userId), User = _userService.FindUserById(userId)};
        }
    }
}