using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Infrastructure.Data;

namespace Restaurant.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
