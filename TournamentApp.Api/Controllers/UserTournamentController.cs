using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.UserTournamentService;

namespace TournamentApp.Api.Controllers
{
    [Route("api/users/")]
    public class UserTournamentController : ControllerBase
    {
        private readonly IUserTournamentService _userTournamentService;

        public UserTournamentController(IUserTournamentService userTournamentService)
        {
            _userTournamentService = userTournamentService;
        }

        [HttpGet]
        [Route("{id:int}/tournaments")]
        public ActionResult GetAUserAndAllHisTournaments(int id, [FromQuery(Name = "details")] bool details)
        {
            return details ? Ok(_userTournamentService.GetAUserWithHisDetailsAndTournaments(id)) : Ok(_userTournamentService.GetAUserWithHisTournaments(id));
        }
    }
}