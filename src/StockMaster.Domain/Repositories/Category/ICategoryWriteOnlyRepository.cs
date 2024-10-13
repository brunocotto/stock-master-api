namespace StockMaster.Domain.Repositories.Category;
public interface ICategoryWriteOnlyRepository
{
    Task Add(Entities.Category category);
}
