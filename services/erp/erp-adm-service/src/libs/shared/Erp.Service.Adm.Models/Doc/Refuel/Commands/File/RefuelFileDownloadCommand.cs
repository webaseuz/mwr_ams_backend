using MediatR;

namespace Erp.Service.Adm.Models;

public class RefuelFileDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}
