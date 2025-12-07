using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Entity;

public class Notification
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}
