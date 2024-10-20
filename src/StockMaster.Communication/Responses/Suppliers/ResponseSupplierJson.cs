namespace StockMaster.Communication.Responses.Suppliers;

public class ResponseSupplierJson
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Contact { get; set; }
    public required string Address { get; set; }
    public required string Cnpj { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
}
