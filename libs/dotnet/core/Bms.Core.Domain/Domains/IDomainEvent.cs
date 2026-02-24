namespace Bms.Core.Domain.Domains;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}