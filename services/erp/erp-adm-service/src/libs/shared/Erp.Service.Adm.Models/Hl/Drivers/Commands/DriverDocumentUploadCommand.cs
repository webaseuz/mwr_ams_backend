using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Models;

public class DriverDocumentUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public IFormFile[] Files { get; set; } = [];
}
