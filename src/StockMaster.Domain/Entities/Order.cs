using StockMaster.Domain.Enums;
using StockMaster.Domain.ValueObjects;

namespace StockMaster.Domain.Entities;

public class Order
{
    private static readonly TimeZoneInfo SaoPauloTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
    public long Id { get; set; }
    public DateTime OrderDate { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, SaoPauloTimeZone);
    public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Pending;
    public OrderType OrderType { get; set; }
    public Money TotalAmount { get; private set; } = new Money(0);
    public DateTime OrderUpdatedAt { get; set; } = DateTime.Now;
    public long CustomerId { get; set; }
    public required Customer Customer { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = [];

    public void AddItem(OrderItem item)
    {
        if (OrderStatus != OrderStatusEnum.Pending)
            throw new InvalidOperationException("Cannot add items to an order that is not pending.");

        OrderItems.Add(item);
        UpdateTotalAmount();
        UpdateTimestamp();
    }

    public void RemoveItem(OrderItem item)
    {
        if (OrderStatus != OrderStatusEnum.Pending)
            throw new InvalidOperationException("Cannot remove items from an order that is not pending.");

        OrderItems.Remove(item);
        UpdateTotalAmount();
        UpdateTimestamp();
    }

    public void ChangeStatus(OrderStatusEnum newStatus)
    {
        if (OrderStatus is OrderStatusEnum.Completed or OrderStatusEnum.Cancelled)
            throw new InvalidOperationException("Cannot change the status of a completed or cancelled order.");

        if (OrderStatus == OrderStatusEnum.Pending && newStatus == OrderStatusEnum.Processing)
        {
            OrderStatus = newStatus;
            UpdateTimestamp();
        }
        else if (OrderStatus == OrderStatusEnum.Processing && (newStatus == OrderStatusEnum.Completed || newStatus == OrderStatusEnum.Cancelled))
        {
            OrderStatus = newStatus;
            UpdateTimestamp();
        }
        else
        {
            throw new InvalidOperationException($"Cannot change order status from {OrderStatus} to {newStatus}.");
        }
    }

    private void UpdateTotalAmount()
    {
        TotalAmount = OrderItems.Aggregate(new Money(0), (sum, item) => sum.Add(item.TotalPrice));
    }

    public void UpdateTimestamp()
    {
        OrderUpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, SaoPauloTimeZone);
    }

    public void CompleteOrder()
    {
        if (OrderStatus != OrderStatusEnum.Processing)
            throw new InvalidOperationException("Only processing orders can be completed.");

        OrderStatus = OrderStatusEnum.Completed;
        UpdateTimestamp();
    }

    public void CancelOrder()
    {
        if (OrderStatus != OrderStatusEnum.Processing && OrderStatus != OrderStatusEnum.Pending)
            throw new InvalidOperationException("Only pending or processing orders can be cancelled.");

        OrderStatus = OrderStatusEnum.Cancelled;
        UpdateTimestamp();
    }
}
