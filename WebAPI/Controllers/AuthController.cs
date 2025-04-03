using Microsoft.AspNetCore.Mvc;
using Service.Services;
using WebAPI.RequestModel;

namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(UserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            
            var existingUser = await _userService.GetUserByUsernameAsync(model.Username);
            if (existingUser != null)
            {
                return BadRequest("Username already exists.");
            }

            
            var user = await _userService.RegisterUserAsync(model.Username, model.Email, model.Password);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userService.GetUserByUsernameAsync(model.Username);
            if (user == null || !_userService.VerifyPassword(user, model.Password))
            {
                return Unauthorized("Invalid credentials.");
            }

           
            var token = _jwtService.GenerateToken(user.Id);
            return Ok(new { Token = token });
        }
    }

}
