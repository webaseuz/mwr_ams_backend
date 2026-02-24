namespace Bms.Core.Domain.Domains;

public static class DomainEvents
{
    private static readonly List<Delegate> Handlers = new();

    public static void Register<T>(Action<T> handler)
        where T : IDomainEvent
        => Handlers.Add(handler);

    public static void Raise<T>(T @event)
        where T : IDomainEvent
    {
        foreach (var handler in Handlers.OfType<Action<T>>())
            handler(@event);
    }
}
