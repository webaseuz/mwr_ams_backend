using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportModelFileDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}
