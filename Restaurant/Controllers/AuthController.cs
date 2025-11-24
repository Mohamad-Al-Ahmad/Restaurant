using Microsoft.AspNetCore.Mvc;
using Restaurant.Dtos;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            try
            {
                var user = _authService.Register(registerDto);
                var token = _authService.GenerateJwtToken(user);
                
                return Ok(new 
                { 
                    Token = token,
                    User = new { user.Id, user.Email, user.Role }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration");
                return BadRequest(ex.Message );
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            try
            {
                var token = _authService.Login(loginDto);
                var user = _authService.GetUserByEmail(loginDto.Email);
                
                return Ok(new 
                {
                    Token = token,
                    User = new { user.Id, user.Email, user.Role }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user login");
                return Unauthorized("Invalid email or password");
            }
        }
    }
}
