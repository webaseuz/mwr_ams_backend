using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoPark.Application.UseCases.TransportSettings;

public class UploadTransportSettingFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadTransportSettingFileCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
