using System;
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


        public QuizRoundDto AddRoundToQuiz(QuizRoundDto quizDto, int quizId)
        {
            var round = _roundRepository.Add(new QuizRound {QuizId = quizId, RoundName = quizDto.RoundName, MaxRoundScore = quizDto.MaxScorePerRound}).First();
           _roundRepository.Save();
           return new QuizRoundDto{QuizId = round.QuizId, RoundName = round.RoundName, MaxScorePerRound = round.MaxRoundScore, Id = round.Id};
        }



        public IEnumerable<GetUserPointDto> GetPlayersFromARound(int quizId)
        {
            var players = _roundUserPointsRepository.GetPlayersFromQuiz(quizId);
            foreach (var roundUserPoints in players)
            {
                yield return new GetUserPointDto() {RoundId = roundUserPoints.RoundId, UserId = roundUserPoints.UserId};
            }
        }


        public List<TournamentWithAllRoundsDto> GetAllRoundFromATournament(int tournamentId)
        {
            var rounds = _roundRepository.GetAllRoundFromATournament(tournamentId).ToList();

            return rounds.Select(round => new TournamentWithAllRoundsDto
                {RoundId = round.Id})
                .ToList();
        }


        public RoundUserPointsDto SavePointsForUserInRound(int roundId, int userId, int score = 0)
        {
            var userPoints = _roundUserPointsRepository.Add(new RoundUserPoints
                {Score = score, RoundId = roundId, UserId = userId}).First();
            _roundUserPointsRepository.Save();
            return new RoundUserPointsDto
                {Score = userPoints.Score, QuizRoundId = roundId, RoundId = roundId, UserId = userId};
        }

        public void InsertUsersIntoTheRoundUserPoints(int roundId, List<PlayerInQuizDto> playerInQuiz, int score)
        {
            foreach (var player in playerInQuiz)
            {
                SavePointsForUserInRound(roundId, player.Id);
            }
        }

        public void InsertUsersIntoTheRoundUserPoints(int roundId, List<UpdateScoreForRoundDto> playerInQuiz)
        {
            foreach (var player in playerInQuiz)
            {
                SavePointsForUserInRound(roundId, player.UserId, player.Score);
            }
        }

        public RoundUserPointsDto UpdateScoreForPlayer(int userId, int score, int roundId)
        {
            _roundUserPointsRepository.UpdateScoreForPlayer(userId, score, roundId);
            return new RoundUserPointsDto{Score = score, RoundId = roundId, UserId = userId};
        }
    }
}