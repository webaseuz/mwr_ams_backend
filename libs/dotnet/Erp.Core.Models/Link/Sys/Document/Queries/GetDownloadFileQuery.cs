using MediatR;

namespace Erp.Core.Sdk.Models;
public class GetDownloadFileQuery : IRequest<byte[]>
{
    public Guid FileId { get; set; }
    public long DocId { get; set; }
    public int TableId { get; set; }
    public int LinkTypeId { get; set; }
}
