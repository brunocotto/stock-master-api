using StockMaster.Domain.Enums;

namespace StockMaster.Domain.Entities;

public class StockMovement
{
    public long Id { get; set; }
    public MovementType MovementType { get; set; }
    public int Quantity { get; set; }
    public DateTime MovementDate { get; set; }
    public MovementReason MovementReason { get; set; }

    public long ProductId { get; set; }
    public required Product Product { get; set; }
}

