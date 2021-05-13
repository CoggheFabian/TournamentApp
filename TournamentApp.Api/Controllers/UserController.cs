using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Model;
using TournamentApp.Services.Token;

namespace TournamentApp.Api.Controllers
{
    public class UserController : ControllerBase
    {
        [Route("api/[controller]")]
        public class HomeController : ControllerBase
        {
            [HttpPost]
            [Route("login")]
            [AllowAnonymous]
            public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
            {
                var user = UserRepository.Get(model.Username, model.Password);

                if (user == null)
                    return NotFound(new { message = "User or password invalid" });

                var token = TokenService.CreateToken(user);
                user.Password = "";
                return new
                {
                    user = user,
                    token = token
                };
            }
        }
    }
}