using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoPark.Application.UseCases.Transports;

public class UploadTransportFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadTransportFileCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
