using System;
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
            _roundService.AddRoundToQuiz(addedQuiz.QuizRoundDto, addedQuiz.Id);
            _roundService.InsertPointsForRound(addedQuiz.Id, user.Id);
            return new CreatedQuizDto {Id = addedQuiz.Id, Name = addedQuiz.Name, Date = addedQuiz.Date, PlayerInQuizDtos = createQuizDto.Players};
        }

        public QuizRoundDto AddNewRound(QuizRoundDto quizRoundDto, int quizId, string userEmail)
        {
            var user = GetUserFromEmail(userEmail);
            var addedRound = _roundService.AddRoundToQuiz(quizRoundDto, quizId);
            var addedPoints = _roundService.InsertPointsForRound(addedRound.Id, user.Id);
            quizRoundDto.QuizId = quizId;
            quizRoundDto.Id = addedPoints.RoundId;
            return quizRoundDto;
        }

        private GetUserDto GetUserFromEmail(string email) { return _userService.GetUserByEmail(email); }
    }
}