using Restaurant.Core.Interfaces;
using Restaurant.Core.Models;
using Restaurant.EF.Data;

namespace Restaurant.EF.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(AppDbContext context) : base(context)
    {
    }
}
