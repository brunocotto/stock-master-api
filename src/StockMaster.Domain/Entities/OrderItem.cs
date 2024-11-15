namespace StockMaster.Domain.Entities;

public class OrderItem
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public int Quantity { get; private set; }
}
