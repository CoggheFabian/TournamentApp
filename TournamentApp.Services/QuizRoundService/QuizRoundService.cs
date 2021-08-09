using System;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Services.MatchService;
using TournamentApp.Services.QuizService;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.QuizRoundService
{
    public class QuizRoundService : IQuizRoundService
    {
        private readonly IQuizService _quizService;
        private readonly IUserService _userService;
        private readonly IRoundService _roundService;

        public QuizRoundService(IQuizService quizService, IUserService userService, IRoundService roundService)
        {
            _quizService = quizService;
            _userService = userService;
            _roundService = roundService;
        }

        public CreatedQuizDto CreateQuiz(CreateQuizDto createQuizDto, string userEmail)
        {
            var user = GetUserFromEmail(userEmail);
            createQuizDto.QuizOwnerId = user.Id;
            var playerIds = createQuizDto.Players.Select(dto => dto.Id);
            if (playerIds.Contains(createQuizDto.QuizOwnerId)) return null;
            var addedQuiz = _quizService.AddQuiz(createQuizDto);
            addedQuiz.QuizRoundDto = createQuizDto.Round;
            var addedRound = _roundService.AddRoundToQuiz(addedQuiz.QuizRoundDto, addedQuiz.Id);
            _roundService.InsertUsersIntoTheRoundUserPoints(addedRound.Id, createQuizDto.Players);
            return new CreatedQuizDto {Id = addedQuiz.Id, Name = addedQuiz.Name, Date = addedQuiz.Date, PlayerInQuizDtos = createQuizDto.Players};
        }

        public QuizRoundDto AddNewRound(QuizRoundDto quizRoundDto, int quizId, string userEmail)
        {
            if (_quizService.GetQuiz(quizId) == null)
                return null;

            var addedRound = _roundService.AddRoundToQuiz(quizRoundDto, quizId);
            var players = _roundService.GetPlayersFromARound(quizId).ToList();
            _roundService.InsertUsersIntoTheRoundUserPoints(addedRound.Id, TransFormGetUserPointDtoToPlayerInQuizDto(players).ToList());
            quizRoundDto.QuizId = quizId;
            quizRoundDto.Id = addedRound.Id;
            return quizRoundDto;
        }

        public StopQuizDto StopQuiz(int quizId, string userEmail)
        {
            var userId = _userService.GetUserByEmail(userEmail).Id;
            _quizService.StopQuiz(quizId, userId);
            return new StopQuizDto {QuizId = quizId};
        }

        private GetUserDto GetUserFromEmail(string email) { return _userService.GetUserByEmail(email); }

        private IEnumerable<UpdateScoreForRoundDto> TransFormGetUserPointDtoToPlayerInQuizDto(
            IEnumerable<GetUserPointDto> userPointDtos)
        {
            return userPointDtos.Select(dto => new UpdateScoreForRoundDto() {Score = 0, UserId = dto.UserId});
        }
    }
}