using MediatR;

namespace Erp.Service.Adm.Models;

public class DocumentFileDeleteCommand : IRequest
{
    public int TableId { get; set; }
    public long DocumentId { get; set; }
    public List<Guid> Files { get; set; }
}
