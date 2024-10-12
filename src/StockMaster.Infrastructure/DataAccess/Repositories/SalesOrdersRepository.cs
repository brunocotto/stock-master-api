using StockMaster.Domain.Repositories.SalesOrder;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

public class SalesOrdersRepository : ISalesOrderWriteOnlyRepository, ISalesOrderReadOnlyRepository, ISalesOrderUpdateOnlyRepository
{
}
