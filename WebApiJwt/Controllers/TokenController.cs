using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;
using WebApiJwt.Services;

namespace WebApiJwt.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public TokenController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        //POST api/token/get-token
        [HttpPost("get-token")]
        public IActionResult GetToken([FromBody] User user)
        {
            User u = _userService.GetUser(user);

            if (u == null)
                return Unauthorized();

            string token = _tokenService.GetToken(u);

            return Ok(token);
        }



        //POST api/token/get-encrypted-token
        [HttpPost("get-encrypted-token")]
        public IActionResult GetEncryptedToken([FromBody] User user)
        {
            User u = _userService.GetUser(user);

            if (u == null)
                return Unauthorized();

            string token = _tokenService.GetEncryptedToken(u);

            return Ok(token);
        }
    }
}