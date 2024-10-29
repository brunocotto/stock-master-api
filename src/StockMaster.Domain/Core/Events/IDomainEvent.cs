namespace StockMaster.Domain.Core.Events;
public interface IDomainEvent
{
    DateTime OccurredAt { get; }
}

