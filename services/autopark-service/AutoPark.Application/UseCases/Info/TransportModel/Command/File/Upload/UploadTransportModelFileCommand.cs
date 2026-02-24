using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoPark.Application.UseCases.TransportModels;

public class UploadTransportModelFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadTransportModelFileCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
