using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Dtos;
using Restaurant.Infrastructure.Data;
using System.Threading.Tasks;

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
            var user = await _authService.RegisterAsync(registerDto);
            var token = _authService.GenerateJwtToken(user);
            
            return Ok(new 
            { 
                Token = token,
                User = new { user.Id, user.Email, user.Name }
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            
            if (token == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { Token = token });
        }
    }
}
