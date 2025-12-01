using Restaurant.Core.Interfaces;
using Restaurant.Core.Models;
using Restaurant.EF.Data;

namespace Restaurant.EF.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
