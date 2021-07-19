using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Api.Controllers
{
    [Route("api/leaderBoards")]
    public class LeaderBordController : ControllerBase
    {
        private readonly IUserService _userService;

        public LeaderBordController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowLeaderBoards()
        {
            return Ok(_userService.GetLeaderBord());
        }
    }
}