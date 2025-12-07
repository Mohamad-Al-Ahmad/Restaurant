using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Entity;

public class Order
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerAddress { get; set; }
    public decimal TotalAmount { get; set; }
    public string Notes { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
