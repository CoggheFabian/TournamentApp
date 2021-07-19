using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.RoundRepo;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public class MockRoundService : IRoundService
    {

        private readonly IRoundRepository _roundRepository;

        public MockRoundService()
        {
            _roundRepository = new MockRoundRepository();
        }

        public MainRoundForTournamentDto AddMainRoundForTournament(CreatedQuizDto addedQuiz)
        {
            var mainRound = _roundRepository.Add(new QuizRound
            {
                QuizId = addedQuiz.Id
            }).First();

            return new MainRoundForTournamentDto {MainRoundId = mainRound.Id};
        }

        public List<TournamentWithAllRoundsDto> GetAllRoundFromATournament(int tournamentId)
        {
            var rounds = _roundRepository.GetAllRoundFromATournament(tournamentId).ToList();

            return rounds.Select(round => new TournamentWithAllRoundsDto
                    {RoundId = round.Id})
                .ToList();
        }
    }
}