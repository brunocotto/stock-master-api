namespace StockMaster.Domain.Entities;

public class OrderItem
{
    public long Id { get; set; } 
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public long ProductId { get; set; }
    public required Product Product { get; set; }
}
