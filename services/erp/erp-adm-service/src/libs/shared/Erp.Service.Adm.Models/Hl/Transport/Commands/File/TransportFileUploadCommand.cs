using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE.Storage;

namespace Erp.Service.Adm.Models;

public class TransportFileUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public TransportFileUploadCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
