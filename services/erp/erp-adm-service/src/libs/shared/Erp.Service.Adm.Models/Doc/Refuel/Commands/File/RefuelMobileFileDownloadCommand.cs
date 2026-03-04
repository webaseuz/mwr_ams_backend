using MediatR;

namespace Erp.Service.Adm.Models;

public class RefuelMobileFileDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}
