using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.TournamentRoundService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Api.Controllers
{
    [Route("api/tournaments")]
    public class TournamentController: ControllerBase
    {
        private readonly ITournamentRoundService _tournamentRoundService;
        private readonly IRoundService _roundService;
        public TournamentController(ITournamentRoundService tournamentService, IRoundService roundService)
        {
            _tournamentRoundService = tournamentService;
            _roundService = roundService;
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateTournamentWithMainRounds([FromBody] CreateTournamentDto createTournamentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //Change this to attribute, or middellware
            return Ok(_tournamentRoundService.CreateTournamentWithMainRounds(createTournamentDto));
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