using MediatR;

namespace Erp.Core.Models;

public interface IRequestGetByIdQuery<TId, TResponse> : IRequest<TResponse>
    where TResponse : IBaseEntity<TId>
    where TId : struct
{
    public TId Id { get; set; }
    public bool IsDocChangeLog { get; set; }
}
