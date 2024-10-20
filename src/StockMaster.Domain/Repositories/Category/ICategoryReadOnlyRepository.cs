namespace StockMaster.Domain.Repositories.Category;
public interface ICategoryReadOnlyRepository
{
    Task<Entities.Category?> GetById(long id);
}
