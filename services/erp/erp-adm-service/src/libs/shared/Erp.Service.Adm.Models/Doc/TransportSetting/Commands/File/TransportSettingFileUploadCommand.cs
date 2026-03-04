using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE.Storage;

namespace Erp.Service.Adm.Models;

public class TransportSettingFileUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public TransportSettingFileUploadCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
