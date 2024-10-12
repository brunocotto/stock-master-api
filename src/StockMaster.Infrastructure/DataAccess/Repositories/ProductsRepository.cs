using StockMaster.Domain.Repositories.Product;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

public class ProductsRepository : IProductWriteOnlyRepository, IProductReadOnlyRepository, IProductUpdateOnlyRepository
{
}
