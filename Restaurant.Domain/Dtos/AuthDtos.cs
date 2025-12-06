using System.Text.Json.Serialization;

namespace Restaurant.Domain.Dtos
{
    public class UserRegisterDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
    }

    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Role { get; set; }
    }
}
