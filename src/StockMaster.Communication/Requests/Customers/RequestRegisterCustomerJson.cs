namespace StockMaster.Communication.Requests.Customers;

public class RequestRegisterCustomerJson
{
    public required string Name { get; set; }
    public required string Cpf { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
}
