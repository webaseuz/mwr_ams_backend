using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE;
using WEBASE.Storage;

namespace Erp.Service.Adm.Models;

public class TransportModelFileUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public IFormFile[] Files { get; set; }
}
