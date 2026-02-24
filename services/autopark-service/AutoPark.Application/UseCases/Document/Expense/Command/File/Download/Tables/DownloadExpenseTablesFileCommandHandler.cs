using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class DownloadExpenseTablesFileCommandHandler :
    IRequestHandler<DownloadExpenseTablesFileCommand, (byte[], string)?>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;
    public DownloadExpenseTablesFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<(byte[], string)?> Handle(DownloadExpenseTablesFileCommand request,
                                                CancellationToken cancellationToken)
    {
        if (request.DocumentName == FileStorageConst.EXPENSE_BATTERY_FILE)
        {
            var entity = await _context.ExpenseBatteryFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_INCPECTION_FILE)
        {
            var entity = await _context.ExpenseInspectionFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_INSURANCE_FILE)
        {
            var entity = await _context.ExpenseInsuranceFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_LIQUID_FILE)
        {
            var entity = await _context.ExpenseLiquidFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_OIL_FILE)
        {
            var entity = await _context.ExpenseOilFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else if (request.DocumentName == FileStorageConst.EXPENSE_TIRE_FILE)
        {
            var entity = await _context.ExpenseTireFiles
                .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);
            return entity != null ? await DownloadFileAsync(request.FileId, entity.FileName, entity.OwnerId, request.DocumentName)
                                  : await DownloadTempFileAsync(request.FileId, request.DocumentName);
        }
        else return await DownloadTempFileAsync(request.FileId, request.DocumentName);
    }

    private async Task<(byte[], string)?> DownloadFileAsync(Guid fileId, string fileName, long ownerId, string document)
    {
        StorageFile file;

        file = await _storageAsyncService.GetFileAsync(document, ownerId.ToString(), fileId);

        if (file == null)
            await _storageAsyncService.GetFileAsync(document, "0", fileId);

        file.FileName = fileName;

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }

    private async Task<(byte[], string)?> DownloadTempFileAsync(Guid fileId, string document)
    {
        var file = await _storageAsyncService.GetTempFileAsync(document, fileId);
        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
