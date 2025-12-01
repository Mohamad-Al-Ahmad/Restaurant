using Restaurant.Core.Interfaces;
using Restaurant.Core.Models;
using Restaurant.EF.Data;

namespace Restaurant.EF.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
