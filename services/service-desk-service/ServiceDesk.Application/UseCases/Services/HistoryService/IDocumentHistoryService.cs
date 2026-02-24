using Bms.Core.Domain.Domains;
using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Services.HistoryService;

public interface IDocumentHistoryService
{
	Task<Guid> AddHistory<TId, TEntity, TData>(TData data, CancellationToken cancellationToken)
		where TEntity : class,
			  IHaveIdProp<TId>,
			  IDocumentEntity
		where TData : class,
			  IHaveIdProp<TId>;
}
