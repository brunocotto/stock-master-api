using Microsoft.EntityFrameworkCore;
using StockMaster.Domain.Entities;
using StockMaster.Domain.Repositories.Customer;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

internal class CustomersRepository(
        StockMasterDbContext dbContext
    ) : ICustomerWriteOnlyRepository, ICustomerReadOnlyRepository, ICustomerUpdateOnlyRepository
{
    private readonly StockMasterDbContext _dbContext = dbContext;
    public async Task Add(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Customers.AnyAsync(c => c.Email.Equals(email));
    }
}
