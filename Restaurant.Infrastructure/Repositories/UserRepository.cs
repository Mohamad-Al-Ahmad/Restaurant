using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Infrastructure.Data;

namespace Restaurant.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
