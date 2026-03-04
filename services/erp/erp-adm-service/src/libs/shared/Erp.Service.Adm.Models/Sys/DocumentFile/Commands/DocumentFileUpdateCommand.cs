using MediatR;

namespace Erp.Service.Adm.Models;

public class DocumentFileUpdateCommand : IRequest
{
    public int TableId { get; set; }
    public long DocumentId { get; set; }
    public int LinkTypeId { get; set; }
    public int DownloadFromTypeId { get; set; }
    public List<DocumentFileCreateDto> Files { get; set; }
}
