using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportSettingFileDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}
