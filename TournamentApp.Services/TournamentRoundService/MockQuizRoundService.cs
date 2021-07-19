using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.RoundRepo;
using TournamentApp.Services.MatchService;
using TournamentApp.Services.QuizService;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public class MockQuizRoundService : IQuizRoundService
    {
        private readonly MockQuizService _mockQuizService;
        private readonly MockUserService _mockUserService;
        private readonly MockRoundService _mockRoundService;
        private readonly MockMatchService _mockMatchService;

        public MockQuizRoundService()
        {
            _mockUserService = new MockUserService();
            _mockQuizService = new MockQuizService();
            _mockRoundService = new MockRoundService();
            _mockMatchService = new MockMatchService();
        }


        public CreatedQuizDto CreateQuiz(CreateQuizDto createQuizDto, string userEmail)
        {
            var addedQuiz = _mockQuizService.AddQuiz(createQuizDto);
            var playerInTournamentDtos = GetPlayersForTournament(createQuizDto.Players);
            var combinationsPlayers = new Combinations<PlayerInQuizDto>(playerInTournamentDtos, 2);
            var mainRound = _mockRoundService.AddMainRoundForTournament(addedQuiz);
            var playableMatches = GenerateMatchesBasedOnPlayerCombination(combinationsPlayers, mainRound.MainRoundId );
            _mockMatchService.BulkInsertMatches(playableMatches.ToList());
            return new CreatedQuizDto {Id = addedQuiz.Id, Name = addedQuiz.Name, Date = addedQuiz.Date, PlayerInQuizDtos = createQuizDto.Players};
        }

        private IEnumerable<PlayerInQuizDto> GetPlayersForTournament(List<PlayerInQuizDto> playerInTournamentDtos)
        {
            var users = _mockUserService.GetPlayersForQuiz(playerInTournamentDtos);
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