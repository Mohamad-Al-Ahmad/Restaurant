using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Infrastructure.Data;

namespace Restaurant.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
