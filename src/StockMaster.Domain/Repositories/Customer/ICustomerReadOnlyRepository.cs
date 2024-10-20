namespace StockMaster.Domain.Repositories.Customer;
public interface ICustomerReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmail(string email);
}
