using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class DownloadMobileAppVersionCommand :
    IRequest<StorageFile>
{
    public Guid fileId { get; set; }
    public DownloadMobileAppVersionCommand(Guid fileId)
    {
        this.fileId = fileId;
    }
}
