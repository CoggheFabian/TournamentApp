using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.RoundService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Api.Controllers
{
    [Route("api/quizzes")]
    public class UserPointController : ControllerBase
    {
        private readonly IRoundService _roundService;

        public UserPointController(IRoundService roundService)
        {
            _roundService = roundService;
        }

        [HttpPatch]
        //[Authorize]
        [Route("{quizId:int}/rounds/{roundId:int}")]
        public IActionResult UpdateScore([FromBody] UpdateScoreForRoundDto updateScoreForRoundDto , int quizId, int roundId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_roundService.UpdateScoreForPlayer(updateScoreForRoundDto.UserId, updateScoreForRoundDto.Score, roundId));
        }
    }
}