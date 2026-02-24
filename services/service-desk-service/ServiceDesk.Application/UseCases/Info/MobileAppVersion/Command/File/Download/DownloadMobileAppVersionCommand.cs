using MediatR;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class DownloadMobileAppVersionCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
    public DownloadMobileAppVersionCommand(Guid fileId)
    {
        this.fileId = fileId;
    }
}
