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

        public QuizRoundDto AddRoundToQuiz(CreatedQuizDto addedQuiz)
        {
            var mainRound = _roundRepository.Add(new QuizRound
            {
                QuizId = addedQuiz.Id
            }).First();

            return new QuizRoundDto();
        }

        public QuizRoundDto AddRoundToQuiz(QuizRoundDto quizDto, int quizId)
        {
            throw new System.NotImplementedException();
        }

        public List<TournamentWithAllRoundsDto> GetAllRoundFromATournament(int tournamentId)
        {
            var rounds = _roundRepository.GetAllRoundFromATournament(tournamentId).ToList();

            return rounds.Select(round => new TournamentWithAllRoundsDto
                    {RoundId = round.Id})
                .ToList();
        }

        public RoundUserPointsDto InsertPointsForRound(int roundId, int userId, int score = 0)
        {
            throw new System.NotImplementedException();
        }
    }
}