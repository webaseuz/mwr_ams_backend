using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class DownloadExpenseFileCommandHandler :
    IRequestHandler<DownloadExpenseFileCommand, (byte[], string)?>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;
    public DownloadExpenseFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<(byte[], string)?> Handle(DownloadExpenseFileCommand request,
                                                CancellationToken cancellationToken)
    {
        var entity = await _context.ExpenseFiles
            .FirstOrDefaultAsync(o => o.Id == request.FileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.EXPENSE_FILE;

        if (entity is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.FileId);
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entity.OwnerId.ToString(), request.FileId);
            file.FileName = entity.FileName;
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
