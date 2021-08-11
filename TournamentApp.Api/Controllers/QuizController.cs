using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Model;
using TournamentApp.Services.QuizRoundService;
using TournamentApp.Services.RoundService;
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
        public IActionResult CreateQuizWithRound([FromBody] CreateQuizDto createQuizDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdQuizDto = _quizRoundService.CreateQuiz(createQuizDto, GetUserEmailFromToken());
            if (createdQuizDto == null) return BadRequest("A quiz owner can't be a player");
            return Ok(createQuizDto);
        }

        [HttpPost]
        [Authorize]
        [Route("{quizId:int}/rounds")]
        public IActionResult AddRound([FromBody] QuizRoundDto roundDto, int quizId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newRound = _quizRoundService.AddNewRound(roundDto, quizId, GetUserEmailFromToken());
            if (newRound != null) return Ok(newRound);
            return BadRequest("Something went wrong while adding the round to a quiz");
        }

        [HttpPut]
        [Authorize]
        [Route("{quizId:int}")]
        public IActionResult StopQuiz(int quizId)
        {
            _quizRoundService.StopQuiz(quizId, GetUserEmailFromToken());
            return Ok("Quiz has been stopped");
        }

        [HttpGet]
        [Authorize]
        [Route("{tournamentId:int}")]
        public ActionResult GetTournamentDetails(int tournamentId)
        {
            return Ok(_roundService.GetAllRoundFromATournament(tournamentId));
        }

        private string GetUserEmailFromToken()
        {
            return User.FindFirst(ClaimTypes.Email)?.Value;
        }


    }
}