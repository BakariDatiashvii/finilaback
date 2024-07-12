using Microsoft.AspNetCore.Mvc;
using registrationOracle.Models;
using registrationOracle.packages;

namespace registrationOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usercontroller : ControllerBase
    {
        private readonly IPKG_USER _package;
        private readonly ITokenService _tokenService;

        public usercontroller(IPKG_USER package, ITokenService tokenService)
        {
            _package = package;
            _tokenService = tokenService;
        }

        [HttpPost("register_user")]
        public async Task<IActionResult> Register_user([FromForm] registerDto registerDto)
        {
            _package.register(registerDto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromForm] loginDto login)
        {
            user user1 = _package.Login(login);

            if (user1 == null) { return Unauthorized(); }

            var token = _tokenService.CreateToken(user1);
            return Ok(token);
        }
    }
}
