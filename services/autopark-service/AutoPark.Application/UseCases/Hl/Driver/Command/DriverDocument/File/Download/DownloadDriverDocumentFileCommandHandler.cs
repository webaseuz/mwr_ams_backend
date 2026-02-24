using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Drivers;

public class DownloadDriverDocumentFileCommandHandler :
    IRequestHandler<DownloadDriverDocumentFileCommand, (byte[], string)?>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;
    public DownloadDriverDocumentFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<(byte[], string)?> Handle(
        DownloadDriverDocumentFileCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.DriverDocuments
            .FirstOrDefaultAsync(x => x.DocumentFileId == request.fileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.DRIVER_DOCUMENT_FILE;

        if (entity is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.fileId);
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entity.OwnerId.ToString(), request.fileId);
            file.FileName = entity.DocumentFileName is not null ? entity.DocumentFileName : "Image.png";
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
