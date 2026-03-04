using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class DocumentChangeLogGetByIdQuery : IRequest<DocumentChangeLogDto>
{
    public long Id { get; set; }
}
