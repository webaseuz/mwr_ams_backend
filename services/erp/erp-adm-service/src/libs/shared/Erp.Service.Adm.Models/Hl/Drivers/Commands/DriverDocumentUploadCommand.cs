using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE.Storage;

namespace Erp.Service.Adm.Models;

public class DriverDocumentUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public DriverDocumentUploadCommand()
    {
        
    }
    public WbStorageFile[] Files { get; set; }
}
