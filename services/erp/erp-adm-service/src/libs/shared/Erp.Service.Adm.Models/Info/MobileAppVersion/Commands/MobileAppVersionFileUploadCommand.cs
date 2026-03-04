using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class MobileAppVersionFileUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public IFormFile[] Files { get; set; }
}
