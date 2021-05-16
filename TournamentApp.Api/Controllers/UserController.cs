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
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid) return BadRequest();


            //Checking if user already has a account, if so return with the right request :-)
            _userService.Register(userRegisterDto);



            // var user = _userRepository.Testing(user.Name, model.Password);
            //
            // if (user == null)
            //     return NotFound(new { message = "User or password invalid" });
            //
            // var token = TokenService.CreateToken(user);
            // user.Password = "";
            // return new
            // {
            //     user = user,
            //     token = token
            // };

            return Ok();
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous()
        {
            return "You are Anonymous";
        }


        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Employee";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Manager";

    }
}