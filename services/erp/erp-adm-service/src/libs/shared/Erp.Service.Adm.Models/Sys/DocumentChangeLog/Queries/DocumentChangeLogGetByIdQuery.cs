using MediatR;

namespace Erp.Service.Adm.Models;

public class DocumentChangeLogGetByIdQuery : IRequest<DocumentChangeLogDto>
{
    public long Id { get; set; }
}
