using Microsoft.AspNetCore.Identity;
using Restaurant.Infrastructure.Data;
using Restaurant.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Services
{
    public class UserManagementService
    {
        private readonly UserManager<User> _userManager;

        public UserManagementService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            return await _userManager.CreateAsync(user, password);
        }
    }
}