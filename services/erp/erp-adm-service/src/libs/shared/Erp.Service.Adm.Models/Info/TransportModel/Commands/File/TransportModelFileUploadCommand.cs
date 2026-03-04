using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportModelFileUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public IFormFile[] Files { get; set; }
}
