using StockMaster.Domain.Core.Entities;

namespace StockMaster.Domain.Core.Events;

public class DomainEvents
{
    // Mapeamento de tipos de eventos para seus respectivos manipuladores (handlers).
    private static readonly Dictionary<Type, List<Action<IDomainEvent>>> _handlersMap = [];

    // Lista de agregados que possuem eventos de dom�nio a serem despachados.
    private static readonly List<AggregateRoot> _markedAggregates = [];

    // Flag para habilitar ou desabilitar o disparo de eventos.
    public static bool ShouldRun { get; set; } = true;

    // Marca um agregado para que seus eventos de dom�nio sejam despachados posteriormente.
    public static void MarkAggregateForDispatch(AggregateRoot aggregate)
    {
        // Verifica se o agregado j� est� marcado. Se n�o, adiciona � lista de agregados marcados.
        if (!_markedAggregates.Any(a => a.Equals(aggregate)))
        {
            _markedAggregates.Add(aggregate);
        }
    }

    // Despacha todos os eventos de dom�nio associados ao agregado especificado.
    public static void DispatchEventsForAggregate(AggregateRoot aggregate)
    {
        // Despacha todos os eventos associados ao agregado.
        DispatchAggregateEvents(aggregate);

        // Limpa os eventos de dom�nio do agregado ap�s o despacho.
        aggregate.ClearDomainEvents();

        // Remove o agregado da lista de agregados marcados.
        RemoveAggregateFromMarkedDispatchList(aggregate);
    }

    // Registra um manipulador (callback) para um tipo espec�fico de evento de dom�nio.
    public static void Register<TDomainEvent>(Action<TDomainEvent> callback) where TDomainEvent : IDomainEvent
    {
        var eventType = typeof(TDomainEvent);

        // Verifica se j� existem handlers registrados para o tipo de evento.
        if (!_handlersMap.TryGetValue(eventType, out List<Action<IDomainEvent>>? value))
        {
            // Se n�o houver handlers, cria uma nova lista para armazen�-los.
            value = new List<Action<IDomainEvent>>();
            _handlersMap[eventType] = value;
        }

        // Adiciona o callback � lista de handlers para esse tipo de evento.
        value.Add((e) => callback((TDomainEvent)e));
    }

    // Limpa todos os handlers registrados.
    public static void ClearHandlers()
    {
        _handlersMap.Clear();
    }

    // Limpa a lista de agregados marcados para despacho de eventos.
    public static void ClearMarkedAggregates()
    {
        _markedAggregates.Clear();
    }

    // Despacha todos os eventos associados ao agregado especificado.
    private static void DispatchAggregateEvents(AggregateRoot aggregate)
    {
        // Itera sobre os eventos de dom�nio do agregado e os despacha individualmente.
        foreach (var domainEvent in aggregate.DomainEvents)
        {
            Dispatch(domainEvent);
        }
    }

    // Remove o agregado da lista de agregados marcados ap�s seus eventos serem despachados.
    private static void RemoveAggregateFromMarkedDispatchList(AggregateRoot aggregate)
    {
        _markedAggregates.Remove(aggregate);
    }

    // Despacha um evento de dom�nio espec�fico para os handlers registrados.
    private static void Dispatch(IDomainEvent domainEvent)
    {
        // Verifica se o despacho de eventos est� habilitado.
        if (!ShouldRun) return;

        // Obt�m o tipo do evento de dom�nio.
        var eventType = domainEvent.GetType();

        // Verifica se existem handlers registrados para esse tipo de evento.
        if (_handlersMap.TryGetValue(eventType, out var handlers))
        {
            // Chama cada handler registrado, passando o evento de dom�nio.
            foreach (var handler in handlers)
            {
                handler(domainEvent);
            }
        }
    }
}
