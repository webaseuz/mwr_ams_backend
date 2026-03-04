using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class DocumentStatusGetByIdQuery : IRequest<DocumentStatusDto>
{
    public int Id { get; set; }
}
