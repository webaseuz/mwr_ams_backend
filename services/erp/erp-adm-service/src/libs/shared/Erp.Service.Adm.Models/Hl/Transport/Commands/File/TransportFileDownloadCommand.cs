using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportFileDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}
