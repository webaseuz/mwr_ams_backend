namespace Erp.Core.Models;

public interface ISysEntity<TId> : IBaseEntity<TId> where TId : struct
{
    int TableId { get; }
}

public interface ISysEntity : ISysEntity<long> { }
