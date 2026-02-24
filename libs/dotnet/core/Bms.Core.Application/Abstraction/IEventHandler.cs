using Bms.Core.Domain.Domains;

namespace Bms.Core.Application.Abstraction;

public interface IEventHandler<TEvent, TId>
    where TEvent : IDomainEvent
    where TId : struct
{
    Task Handle(TEvent @event);
}
