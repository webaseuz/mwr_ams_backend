using MediatR;

namespace Erp.Service.Adm.Models;

public class DriverDocumentDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}
