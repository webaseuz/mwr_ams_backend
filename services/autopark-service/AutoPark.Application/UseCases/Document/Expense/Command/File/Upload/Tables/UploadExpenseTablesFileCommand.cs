using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoPark.Application.UseCases.Expenses;

public class UploadExpenseTablesFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public string DocumentName { get; }
    public IFormFile[] Files { get; }

    public UploadExpenseTablesFileCommand(string documentName, params IFormFile[] files)
    {
        Files = files;
        DocumentName = documentName;
    }
}
