using StockMaster.Domain.Enums;

namespace StockMaster.Domain.Entities;

public class SalesOrder
{
    public long Id { get; set; }  
    public DateTime OrderDate { get; set; }
    public SalesOrderStatuscs Status { get; set; }

    public long CustomerId { get; set; }
    public required Customer Customer { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
