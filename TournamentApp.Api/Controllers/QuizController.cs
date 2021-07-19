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
        private readonly ITournamentRoundService _tournamentRoundService;
        private readonly IRoundService _roundService;
        public QuizController(ITournamentRoundService tournamentService, IRoundService roundService)
        {
            _tournamentRoundService = tournamentService;
            _roundService = roundService;
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateTournamentWithMainRounds([FromBody] CreateQuizDto createQuizDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_tournamentRoundService.CreateTournamentWithMainRounds(createQuizDto));
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