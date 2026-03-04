using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class DocumentChangeLogUpdateCommand : IRequest<bool>
{
    public long Id { get; set; }
}
