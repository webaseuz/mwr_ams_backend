using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Storage;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DownloadExpenseFileCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService) : IRequestHandler<ExpenseFileDownloadCommand, (byte[], string)?>
{
    public async Task<(byte[], string)?> Handle(ExpenseFileDownloadCommand request,
                                                CancellationToken cancellationToken)
    {
        var entity = await context.ExpenseFiles
            .FirstOrDefaultAsync(o => o.Id == request.FileId, cancellationToken);

        WbStorageFile file;
        string document = FileStorageConst.EXPENSE_FILE;

        if (entity is null)
            file = await wbStorageService.GetTempFileAsync(document, request.FileId);
        else
        {
            file = await wbStorageService.GetFileAsync(document, entity.OwnerId.ToString(), request.FileId);
            file.FileName = entity.FileName;
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
