using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.TournamentService;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public class TournamentRoundService : ITournamentRoundService
    {
        private readonly ITournamentService _tournamentService;
        private readonly IUserService _userService;
        private readonly IMatchRepository _matchRepository;
        private readonly IRoundService _roundService;
        public TournamentRoundService(ITournamentService tournamentService, IUserService userService, IMatchRepository matchRepository, IRoundService roundService)
        {
            _tournamentService = tournamentService;
            _userService = userService;
            _matchRepository = matchRepository;
            _roundService = roundService;
        }

        public void CreateTournament(CreateTournamentDto createTournamentDto)
        {
            var addedTournament = _tournamentService.AddTournament(createTournamentDto);
            var playerInTournamentDtos = GetPlayersForTournament(createTournamentDto.Players);
            var combinationsPlayers = new Combinations<PlayerInTournamentDto>(playerInTournamentDtos, 2);

            var mainRound = _roundService.AddMainRoundForTournament(addedTournament);


            var matches = GenerateMatchesBasedOnPlayerCombination(combinationsPlayers, mainRound.MainRoundId );

            _matchRepository.BulkInsertMatches(matches.ToList());

        }

        private IEnumerable<Match> GenerateMatchesBasedOnPlayerCombination(Combinations<PlayerInTournamentDto> playersCombination, int roundId)
        {
            foreach (var playerInMatch in playersCombination)
            {
                yield return new Match
                {
                    Player1Id = playerInMatch[0].Id,
                    Player2Id = playerInMatch[1].Id,
                    ScorePlayer1 = 0,
                    ScorePlayer2 = 0,
                    IsMatchPlayed = false,
                    RoundId = roundId
                };
            }
        }

        //This could be in a other service
        public IEnumerable<PlayerInTournamentDto> GetPlayersForTournament(List<PlayerInTournamentDto> playerInTournamentDtos)
        {
            foreach (var playerInTournament in playerInTournamentDtos)
            {
                var user = _userService.FindUserById(playerInTournament.Id); //Change this with 1 Db call thats gets all the users, instead of 5 * a single user.
                yield return new PlayerInTournamentDto {Id = user.Id, UserName = user.Name};
            }
        }
    }
}