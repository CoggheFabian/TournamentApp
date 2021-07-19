using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.TournamentRoundService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Api.Controllers
{
    [Route("api/quizzes")]
    public class QuizController: ControllerBase
    {
        private readonly IQuizRoundService _quizRoundService;
        private readonly IRoundService _roundService;
        public QuizController(IQuizRoundService quizService, IRoundService roundService)
        {
            _quizRoundService = quizService;
            _roundService = roundService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateTournamentWithMainRounds([FromBody] CreateQuizDto createQuizDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdQuizDto = _quizRoundService.CreateQuiz(createQuizDto, User.FindFirst(ClaimTypes.Email)?.Value);
            if (createdQuizDto == null) return BadRequest("A quiz owner can't be a player");
            return Ok(createQuizDto);
        }

        [HttpGet]
        [Authorize]
        [Route("{tournamentId:int}")]
        public ActionResult GetTournamentDetails(int tournamentId)
        {
            return Ok(_roundService.GetAllRoundFromATournament(tournamentId));
        }


    }
}