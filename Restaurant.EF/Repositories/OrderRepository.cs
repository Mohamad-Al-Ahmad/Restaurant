using Restaurant.Core.Interfaces;
using Restaurant.Core.Models;
using Restaurant.EF.Data;

namespace Restaurant.EF.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}
