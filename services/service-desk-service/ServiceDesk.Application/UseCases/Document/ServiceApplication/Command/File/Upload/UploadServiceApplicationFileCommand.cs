using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UploadServiceApplicationFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadServiceApplicationFileCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
