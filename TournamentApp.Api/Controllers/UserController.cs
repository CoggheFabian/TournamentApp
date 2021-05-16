using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.Token;
using TournamentApp.Services.UserService;

namespace TournamentApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult Authenticate([FromBody] UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_userService.GetUserByEmail(userRegisterDto.Email.ToLower()))
            {
                return new StatusCodeResult(403);
            }
            //Checking if user already has a account, if so return with the right request :-)
            var userInfo = _userService.Register(userRegisterDto);
            return new JsonResult(userInfo);
        }


    }
}