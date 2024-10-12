using StockMaster.Domain.Repositories.Customer;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

public class CustomersRepository : ICustomerWriteOnlyRepository, ICustomerReadOnlyRepository, ICustomerUpdateOnlyRepository
{
}
