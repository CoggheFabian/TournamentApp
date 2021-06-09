using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.UserService;

namespace TournamentApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public ActionResult Register([FromBody] UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //Change this to attribute, or middellware

            if (!_userService.CheckIfEmailIsAlreadyRegistered(userRegisterDto.Email)){ return BadRequest("Somebody with that email already exists"); }
            var createdUser = _userService.Register(userRegisterDto);
            return Created(nameof(UserInfo), createdUser);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //PUt this in middelware.
            if (!_userService.CheckIfEmailIsAlreadyRegistered(userLoginDto.Email)) { return BadRequest("Somebody with that email already exists"); }
            var loggedInUser = _userService.Login(userLoginDto);
            if (loggedInUser == null) { return BadRequest("The email or password is incorrect"); }
            return Ok(loggedInUser);
        }

        [HttpGet]
        [Route("userInfo")]
        [Authorize]
        public IActionResult UserInfo()
        {
            var loggedInUserHisEmail = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase))?.Value;
            var res  = _userService.GetUserByEmail(loggedInUserHisEmail);
            if (res == null) { return Unauthorized(); }
            return Ok(res);
        }


    }
}