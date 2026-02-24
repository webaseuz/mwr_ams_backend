using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class DownloadMobileExpenseFileCommandHandler :
    IRequestHandler<DownloadMobileExpenseFileCommand, StorageFile>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;
    public DownloadMobileExpenseFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<StorageFile> Handle(
        DownloadMobileExpenseFileCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.ExpenseFiles
            .FirstOrDefaultAsync(o => o.Id == request.fileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.EXPENSE_FILE;

        if (entity is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.fileId);
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entity.OwnerId.ToString(), request.fileId);
            file.FileName = entity.FileName;
        }

        return file != null ? file : null;
    }
}
