using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE.Storage;

namespace Erp.Service.Adm.Models;

public class RefuelFileUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public RefuelFileUploadCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
