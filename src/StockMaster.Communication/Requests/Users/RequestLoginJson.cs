namespace StockMaster.Communication.Requests.Users;

public class RequestLoginJson
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}