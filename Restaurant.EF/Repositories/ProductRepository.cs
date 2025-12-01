using Restaurant.Core.Interfaces;
using Restaurant.Core.Models;
using Restaurant.EF.Data;

namespace Restaurant.EF.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
