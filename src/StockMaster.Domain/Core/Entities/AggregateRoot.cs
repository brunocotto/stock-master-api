using StockMaster.Domain.Core.Events;

namespace StockMaster.Domain.Core.Entities;

public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (_domainEvents.All(e => e.GetType() != domainEvent.GetType()))
        {
            _domainEvents.Add(domainEvent);
        }
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

