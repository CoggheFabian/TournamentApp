using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Combinatorics.Collections;
using TournamentApp.Model;
using TournamentApp.Services.MatchService;
using TournamentApp.Services.QuizService;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public class QuizRoundService : IQuizRoundService
    {
        private readonly IQuizService _quizService;
        private readonly IUserService _userService;
        private readonly IMatchService _matchService;
        private readonly IRoundService _roundService;
        public QuizRoundService(IQuizService quizService, IUserService userService, IMatchService matchService, IRoundService roundService)
        {
            _quizService = quizService;
            _userService = userService;
            _matchService = matchService;
            _roundService = roundService;
        }

        public CreatedQuizDto CreateQuiz(CreateQuizDto createQuizDto, string userEmail)
        {
            var user = _userService.GetUserByEmail(userEmail);
            createQuizDto.QuizOwnerId = user.Id;
            var playerIds = createQuizDto.Players.Select(dto => dto.Id);
            if (playerIds.Contains(createQuizDto.QuizOwnerId)) return null;
            var addedQuiz = _quizService.AddQuiz(createQuizDto);
            return new CreatedQuizDto {Id = addedQuiz.Id, Name = addedQuiz.Name, Date = addedQuiz.Date, PlayerInQuizDtos = createQuizDto.Players};
        }

    }
}