using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class DownloadMobileExpenseFileCommand :
    IRequest<StorageFile>
{
    public Guid fileId { get; set; }
    public DownloadMobileExpenseFileCommand(Guid fileId)
    {
        this.fileId = fileId;
    }
}
