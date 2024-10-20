namespace StockMaster.Domain.Repositories.Product;
public interface IProductWriteOnlyRepository
{
    Task Add(Entities.Product product);
}
