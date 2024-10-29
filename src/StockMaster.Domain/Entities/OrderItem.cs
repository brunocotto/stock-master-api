using StockMaster.Domain.ValueObjects;

namespace StockMaster.Domain.Entities;

public class OrderItem
{
    public long Id { get; set; }
    public long ProductId { get; }
    public required Product Product { get; set; }
    public int Quantity { get; private set; }
    public Money UnitPrice { get; }
    public Money TotalPrice => UnitPrice.Multiply(Quantity);

    public OrderItem(long productId, int quantity, Money unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice), "UnitPrice cannot be null.");
    }

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity must be greater than zero.");

        Quantity = newQuantity;
    }
}
