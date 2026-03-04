using Erp.Core.Models;
using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class RowChangeLogCreateCommand<TKey, TDto> : IRequest<bool>
    where TDto : ISysEntity<TKey>
    where TKey : struct
{
    public IRequestGetByIdQuery<TKey, TDto> GetByIdQuery { get; set; }
    public string Message { get; set; } = string.Empty;
}

