using StockMaster.Domain.Entities;

namespace StockMaster.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}
