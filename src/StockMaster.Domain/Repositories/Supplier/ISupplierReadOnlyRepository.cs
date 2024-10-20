namespace StockMaster.Domain.Repositories.Supplier;
public interface ISupplierReadOnlyRepository
{
    Task<Entities.Supplier?> GetById(long id);
}
