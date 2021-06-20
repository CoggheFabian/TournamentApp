using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.TournamentRoundService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Api.Controllers
{
    [Route("api/tournaments")]
    public class TournamentController: ControllerBase
    {
        private readonly ITournamentRoundService _tournamentRoundService;
        public TournamentController(ITournamentRoundService tournamentService)
        {
            _tournamentRoundService = tournamentService;
        }

        [HttpPost]
        [Authorize]
        public ActionResult Register([FromBody] CreateTournamentDto createTournamentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //Change this to attribute, or middellware
            return Ok(_tournamentRoundService.CreateTournamentWithMainRounds(createTournamentDto));
        }
    }
}