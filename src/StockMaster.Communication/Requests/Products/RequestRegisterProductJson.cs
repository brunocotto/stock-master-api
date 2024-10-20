namespace StockMaster.Communication.Requests.Products;

public class RequestRegisterProductJson
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Barcode { get; set; }
    public int StockQuantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public long CategoryId { get; set; }
    public long SupplierId { get; set; }
}
