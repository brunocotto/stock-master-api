namespace StockMaster.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
