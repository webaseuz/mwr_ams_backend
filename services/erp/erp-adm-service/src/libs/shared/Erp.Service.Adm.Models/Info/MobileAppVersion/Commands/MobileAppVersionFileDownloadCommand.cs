using MediatR;

namespace Erp.Service.Adm.Models;

public class MobileAppVersionFileDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}
