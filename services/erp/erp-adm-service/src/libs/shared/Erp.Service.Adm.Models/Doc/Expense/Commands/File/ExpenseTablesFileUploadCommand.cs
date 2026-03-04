using MediatR;
using Microsoft.AspNetCore.Http;
using WEBASE.Storage;

namespace Erp.Service.Adm.Models;

public class ExpenseTablesFileUploadCommand : IRequest<IEnumerable<IWbStorageFileInfo>>
{
    public string DocumentName { get; set; }
    public IFormFile[] Files { get; }

    public ExpenseTablesFileUploadCommand(string documentName, params IFormFile[] files)
    {
        Files = files;
        DocumentName = documentName;
    }
}
