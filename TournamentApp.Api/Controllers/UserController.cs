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
        [Route("register")]
        [AllowAnonymous]
        public ActionResult Register([FromBody] UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_userService.GetUserByEmail(userRegisterDto.Email))
            {
                return BadRequest("Somebody with that email already exists");
            }
            //Checking if user already has a account, if so return with the right request :-)
            var createdUser = _userService.Register(userRegisterDto);
            return Created(nameof(UserInfo), createdUser);
        }

        [HttpGet]
        [Route("userInfo")]
        [AllowAnonymous] //Change this
        public IActionResult UserInfo()
        {
            return Ok();
        }


    }
}