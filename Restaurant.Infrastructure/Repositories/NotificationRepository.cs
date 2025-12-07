using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entity;
using Restaurant.Infrastructure.Data;

namespace Restaurant.Infrastructure.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(AppDbContext context) : base(context)
    {
    }
}
