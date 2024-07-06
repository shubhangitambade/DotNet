using JWT_Auth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWT_Auth.Services;
using JWT_Auth.Models;
//using Microsoft.AspNetCore.Authorization;
using JWT_Auth.Helper;
namespace JWT_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]

        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);    

            if(response == null)
            {
                return BadRequest(new { message = "Username or password is incorrecr" });

            }
            return Ok(response);
        }

        //[Authorize]
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
