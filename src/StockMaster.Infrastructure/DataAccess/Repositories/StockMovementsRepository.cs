using StockMaster.Domain.Repositories.StockMovement;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

public class StockMovementsRepository : IStockMovementWriteOnlyRepository, IStockMovementReadOnlyRepository, IStockMovementUpdateOnlyRepository
{
}
