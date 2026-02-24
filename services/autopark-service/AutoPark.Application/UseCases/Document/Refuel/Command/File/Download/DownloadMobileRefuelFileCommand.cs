using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class DownloadMobileRefuelFileCommand :
    IRequest<StorageFile>
{
    public Guid fileId { get; set; }
    public DownloadMobileRefuelFileCommand(Guid fileId)
    {
        this.fileId = fileId;
    }
}
