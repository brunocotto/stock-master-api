using StockMaster.Domain.Repositories;

namespace StockMaster.Infrastructure.DataAccess;

internal class UnitOfWork(StockMasterDbContext dbContext) : IUnitOfWork
{
    private readonly StockMasterDbContext _dbcontext = dbContext;
    public async Task Commit() => await _dbcontext.SaveChangesAsync();
}
