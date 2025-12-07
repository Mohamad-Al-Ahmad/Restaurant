using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entity;
using Restaurant.Infrastructure.Data;

namespace Restaurant.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
