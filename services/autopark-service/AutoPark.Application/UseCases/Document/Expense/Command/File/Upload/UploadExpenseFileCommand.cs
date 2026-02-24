using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoPark.Application.UseCases.Expenses;

public class UploadExpenseFileCommand :
    IRequest<IEnumerable<IStorageFileInfo>>
{
    public IFormFile[] Files { get; }

    public UploadExpenseFileCommand(params IFormFile[] files)
    {
        Files = files;
    }
}
