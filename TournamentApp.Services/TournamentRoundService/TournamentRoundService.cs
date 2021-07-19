using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;
using TournamentApp.Model;
using TournamentApp.Services.MatchService;
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
        private readonly IMatchService _matchService;
        private readonly IRoundService _roundService;
        public TournamentRoundService(ITournamentService tournamentService, IUserService userService, IMatchService matchService, IRoundService roundService)
        {
            _tournamentService = tournamentService;
            _userService = userService;
            _matchService = matchService;
            _roundService = roundService;
        }

        public CreatedTournamentDto CreateTournamentWithMainRounds(CreateQuizDto createQuizDto)
        {
            var addedTournament = _tournamentService.AddTournament(createQuizDto);
            var playerInTournamentDtos = GetPlayersForTournament(createQuizDto.Players);
            var combinationsPlayers = new Combinations<PlayerInQuizDto>(playerInTournamentDtos, 2);
            var mainRound = _roundService.AddMainRoundForTournament(addedTournament);
            var playableMatches = GenerateMatchesBasedOnPlayerCombination(combinationsPlayers, mainRound.MainRoundId );
            _matchService.BulkInsertMatches(playableMatches.ToList());

            return new CreatedTournamentDto {Id = addedTournament.Id, Matches = playableMatches, Name = addedTournament.Name, TournamentDate = addedTournament.TournamentDate, MainRoundForTournament = mainRound };

        }

        private IEnumerable<Match> GenerateMatchesBasedOnPlayerCombination(Combinations<PlayerInQuizDto> playersCombination, int roundId)
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

        public IEnumerable<PlayerInQuizDto> GetPlayersForTournament(List<PlayerInQuizDto> playerInTournamentDtos)
        {
            var users = _userService.GetPlayersForTournament(playerInTournamentDtos);

            foreach (var playerInTournamentDto in users)
            {
                yield return new PlayerInQuizDto {Id = playerInTournamentDto.Id, UserName = playerInTournamentDto.UserName};
            }
        }


    }
}