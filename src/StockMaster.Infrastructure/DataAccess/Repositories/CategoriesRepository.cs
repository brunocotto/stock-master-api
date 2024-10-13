using StockMaster.Domain.Entities;
using StockMaster.Domain.Repositories.Category;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

internal class CategoriesRepository(StockMasterDbContext dbContext) : ICategoryWriteOnlyRepository, ICategoryReadOnlyRepository, ICategoryUpdateOnlyRepository
{
    private readonly StockMasterDbContext _dbContext = dbContext;
    public async Task Add(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
    }
}
