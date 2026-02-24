using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class UploadMobileAppVersionCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadMobileAppVersionCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
