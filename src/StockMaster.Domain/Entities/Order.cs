using StockMaster.Domain.Enums;

namespace StockMaster.Domain.Entities;

public class Order
{
    private static readonly TimeZoneInfo SaoPauloTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
    public long Id { get; set; }
    public DateTime OrderDate { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, SaoPauloTimeZone);
    public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Pending;
    public OrderType OrderType { get; set; }
    public decimal TotalAmount { get; private set; }
    public DateTime OrderUpdatedAt { get; set; } = DateTime.Now;
    public long CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
