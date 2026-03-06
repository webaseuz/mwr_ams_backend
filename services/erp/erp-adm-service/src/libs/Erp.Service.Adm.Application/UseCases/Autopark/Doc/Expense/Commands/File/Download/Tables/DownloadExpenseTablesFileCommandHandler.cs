using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Storage;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DownloadExpenseTablesFileCommandHandler(
    IWbStorageService wbStorageService,
    IApplicationDbContext context) : IRequestHandler<ExpenseTablesFileDownloadCommand, (byte[], string)?>
{
    public async Task<(byte[], string)?> Handle(ExpenseTablesFileDownloadCommand request,
                                                CancellationToken cancellationToken)
    {
        if (request.DocumentName == FileStorageConst.EXPENSE_BATTERY_FILE)
        {
            var entity = await context.ExpenseBatteryFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_INCPECTION_FILE)
        {
            var entity = await context.ExpenseInspectionFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_INSURANCE_FILE)
        {
            var entity = await context.ExpenseInsuranceFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_LIQUID_FILE)
        {
            var entity = await context.ExpenseLiquidFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_OIL_FILE)
        {
            var entity = await context.ExpenseOilFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_TIRE_FILE)
        {
            var entity = await context.ExpenseTireFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else return await DownloadTempFileAsync(request.FileId, request.DocumentName);
    }

    private async Task<(byte[], string)?> DownloadFileAsync(Guid fileId, string fileName, long ownerId, string document)
    {
        WbStorageFile file;

        file = await wbStorageService.GetFileAsync(document, ownerId.ToString(), fileId);

        if (file == null)
            await wbStorageService.GetFileAsync(document, "0", fileId);

        file.FileName = fileName;

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }

    private async Task<(byte[], string)?> DownloadTempFileAsync(Guid fileId, string document)
    {
        var file = await wbStorageService.GetTempFileAsync(document, fileId);
        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
