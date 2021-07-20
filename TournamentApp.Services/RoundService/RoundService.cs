using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.RoundService
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;
        private readonly IRoundUserPointsRepository _roundUserPointsRepository;

        public RoundService(IRoundRepository roundRepository, IRoundUserPointsRepository roundUserPointsRepository)
        {
            _roundRepository = roundRepository;
            _roundUserPointsRepository = roundUserPointsRepository;
        }


        public QuizRoundDto AddRoundToQuiz(CreatedQuizDto addedQuiz)
        {
            var round = _roundRepository.Add(new QuizRound
            {
                QuizId = addedQuiz.Id,
                RoundName = addedQuiz.QuizRoundDto.RoundName,
                MaxRoundScore = addedQuiz.QuizRoundDto.MaxScorePerRound,
            }).First();

            _roundRepository.Save();
           return new QuizRoundDto{QuizId = round.QuizId, RoundName = round.RoundName, MaxScorePerRound = round.MaxRoundScore};
        }

        public RoundUserPointsDto InsertPointsForRound(int roundId, int userId, int score = 0)
        {
            var userPoints = _roundUserPointsRepository.Add(new RoundUserPoints
            {
                Score = score,
                RoundId = roundId,
                UserId = userId
            }).First();

            _roundUserPointsRepository.Save();
            return new RoundUserPointsDto
                {Score = userPoints.Score, QuizRoundId = roundId, RoundId = roundId, UserId = userId};
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