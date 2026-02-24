using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoPark.Application.UseCases.Drivers;

public class UploadDriverDocumentFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadDriverDocumentFileCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
