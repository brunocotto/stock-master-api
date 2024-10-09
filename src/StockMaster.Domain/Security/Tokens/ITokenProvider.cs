namespace StockMaster.Domain.Security.Tokens;
public interface ITokenProvider
{
    string TokenOnRequest();
}
