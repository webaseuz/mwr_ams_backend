using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoPark.Application.UseCases.Refuels;

public class UploadRefuelFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadRefuelFileCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
