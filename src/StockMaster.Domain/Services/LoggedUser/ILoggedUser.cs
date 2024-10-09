namespace StockMaster.Domain.Services.LoggedUser;
public interface ILoggedUser
{
    Task<Entities.User> Get();
}
