namespace Erp.Core.Models;

public interface IBaseEntity<TId> where TId : struct
{
    TId Id { get; set; }
}
