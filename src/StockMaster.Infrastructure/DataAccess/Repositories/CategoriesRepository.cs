using StockMaster.Domain.Repositories.Category;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

public class CategoriesRepository : ICategoryWriteOnlyRepository, ICategoryReadOnlyRepository, ICategoryUpdateOnlyRepository
{
}
