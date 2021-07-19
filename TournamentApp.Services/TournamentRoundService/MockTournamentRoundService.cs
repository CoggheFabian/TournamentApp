using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.RoundRepo;
using TournamentApp.Repositories.Implementation.TournamentRepo;
using TournamentApp.Services.MatchService;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.TournamentService;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public class MockTournamentRoundService : ITournamentRoundService
    {
        private readonly MockTournamentService _mockTournamentService;
        private readonly MockUserService _mockUserService;
        private readonly MockRoundService _mockRoundService;
        private readonly MockMatchService _mockMatchService;

        public MockTournamentRoundService()
        {
            _mockUserService = new MockUserService();
            _mockTournamentService = new MockTournamentService();
            _mockRoundService = new MockRoundService();
            _mockMatchService = new MockMatchService();
        }


        public CreatedTournamentDto CreateTournamentWithMainRounds(CreateQuizDto createQuizDto)
        {
            var addedTournament = _mockTournamentService.AddTournament(createQuizDto);
            var playerInTournamentDtos = GetPlayersForTournament(createQuizDto.Players);
            var combinationsPlayers = new Combinations<PlayerInQuizDto>(playerInTournamentDtos, 2);
            var mainRound = _mockRoundService.AddMainRoundForTournament(addedTournament);
            var playableMatches = GenerateMatchesBasedOnPlayerCombination(combinationsPlayers, mainRound.MainRoundId );
            _mockMatchService.BulkInsertMatches(playableMatches.ToList());
            return new CreatedTournamentDto {Id = addedTournament.Id, Matches = playableMatches, Name = addedTournament.Name,
                                             TournamentDate = addedTournament.TournamentDate, MainRoundForTournament = mainRound };
        }

        private IEnumerable<PlayerInQuizDto> GetPlayersForTournament(List<PlayerInQuizDto> playerInTournamentDtos)
        {
            var users = _mockUserService.GetPlayersForTournament(playerInTournamentDtos);
            foreach (var playerInTournamentDto in users) { yield return new PlayerInQuizDto {Id = playerInTournamentDto.Id, UserName = playerInTournamentDto.UserName}; }
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
    }
}