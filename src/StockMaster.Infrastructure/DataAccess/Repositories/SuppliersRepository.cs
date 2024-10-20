using Microsoft.EntityFrameworkCore;
using StockMaster.Domain.Entities;
using StockMaster.Domain.Repositories.Supplier;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

internal class SuppliersRepository(StockMasterDbContext dbContext) : ISupplierWriteOnlyRepository, ISupplierReadOnlyRepository, ISupplierUpdateOnlyRepository
{
    private readonly StockMasterDbContext _dbContext = dbContext;
    public async Task Add(Supplier supplier)
    {
        await _dbContext.Suppliers.AddAsync(supplier);
    }

    public async Task<Supplier?> GetById(long id)
    {
        return await _dbContext.Suppliers
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}
