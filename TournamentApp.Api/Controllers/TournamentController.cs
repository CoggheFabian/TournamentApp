using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.TournamentRoundService;
using TournamentApp.Services.TournamentService;

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
            _tournamentRoundService.CreateTournament(createTournamentDto);
            // if (!_userService.CheckIfEmailIsAlreadyRegistered(userRegisterDto.Email)){ return BadRequest("Somebody with that email already exists"); }
            // var createdUser = _userService.Register(userRegisterDto);
            // return Created(nameof(UserInfo), createdUser);
            return Ok("Okay");
        }
    }
}