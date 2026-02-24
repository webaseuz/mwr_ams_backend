using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Transports;

public class DownloadTransportFileCommandHandler :
    IRequestHandler<DownloadTransportFileCommand, (byte[], string)?>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;
    public DownloadTransportFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<(byte[], string)?> Handle(
        DownloadTransportFileCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.TransportFiles
            .FirstOrDefaultAsync(x => x.Id == request.fileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.TRANSPORT_FILE;

        if (entity is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.fileId);
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entity.OwnerId.ToString(), request.fileId);
            file.FileName = entity.FileName;

        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
