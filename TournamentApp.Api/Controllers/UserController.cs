using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Model;
using TournamentApp.Services.Dtos;
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

            if (!_userService.CheckIfEmailIsAlreadyRegistered(userRegisterDto.Email))
            {
                return BadRequest("Somebody with that email already exists");
            }
            
            var createdUser = _userService.Register(userRegisterDto);
            return Created(nameof(UserInfo), createdUser);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //PUt this in middelware.

            if (!_userService.CheckIfEmailIsAlreadyRegistered(userLoginDto.Email))
            {
                return BadRequest("Somebody with that email already exists");
            }

            var loggedInUser = _userService.Login(userLoginDto);
            if (loggedInUser == null)
            {
                return BadRequest("The email or password is incorrect");
            }
            return Ok(loggedInUser);


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