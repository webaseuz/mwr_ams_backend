using MediatR;

namespace Erp.Service.Adm.Models;
public class DocumentFileGetListQuery : IRequest<List<DocumentFileDto>>
{
    public int TableId { get; set; }
    public long DocId { get; set; }
}
