namespace StockMaster.Domain.Repositories.Customer;
public interface ICustomerWriteOnlyRepository
{
    Task Add(Entities.Customer customer);
}
