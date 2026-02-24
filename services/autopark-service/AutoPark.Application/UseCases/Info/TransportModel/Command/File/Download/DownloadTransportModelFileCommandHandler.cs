using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportModels;

public class DownloadTransportModelFileCommandHandler :
    IRequestHandler<DownloadTransportModelFileCommand, (byte[], string)?>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;
    public DownloadTransportModelFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<(byte[], string)?> Handle(
        DownloadTransportModelFileCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.TransportModelFiles
            .FirstOrDefaultAsync(x => x.Id == request.fileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.TRANSPORT_MODEL_FILE;

        if (entity is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.fileId);
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entity.TransportModelId.ToString(), request.fileId);
            file.FileName = entity.FileName;
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
