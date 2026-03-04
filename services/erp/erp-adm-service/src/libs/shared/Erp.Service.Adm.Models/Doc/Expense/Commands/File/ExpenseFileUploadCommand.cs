using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE.Storage;

namespace Erp.Service.Adm.Models;

public class ExpenseFileUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public ExpenseFileUploadCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
