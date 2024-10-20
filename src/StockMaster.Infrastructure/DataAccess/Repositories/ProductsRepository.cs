using StockMaster.Domain.Entities;
using StockMaster.Domain.Repositories.Product;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

internal class ProductsRepository(
        StockMasterDbContext dbContext
    ) : IProductWriteOnlyRepository, IProductReadOnlyRepository, IProductUpdateOnlyRepository
{
    private readonly StockMasterDbContext _dbContext = dbContext;
    public async Task Add(Product product)
    {
        await _dbContext.Products.AddAsync(product);
    }
}
