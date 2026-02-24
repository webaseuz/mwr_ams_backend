using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ServiceDesk.Application.UseCases.Devices;

public class UploadDeviceFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadDeviceFileCommand(params IFormFile[] files)
    {
        Files = files;
    }
}