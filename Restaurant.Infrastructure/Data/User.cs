using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Enums;

namespace Restaurant.Infrastructure.Data;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
    public Roles Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
