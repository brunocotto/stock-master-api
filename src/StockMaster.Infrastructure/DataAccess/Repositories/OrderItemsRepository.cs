using StockMaster.Domain.Repositories.OrderItem;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

public class OrderItemsRepository : IOrderItemWriteOnlyRepository, IOrderItemReadOnlyRepository, IOrderItemUpdateOnlyRepository
{
}
