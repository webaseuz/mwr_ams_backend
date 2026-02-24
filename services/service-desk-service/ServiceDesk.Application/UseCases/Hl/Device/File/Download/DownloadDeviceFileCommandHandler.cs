using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.Devices;

public class DownloadDeviceFileCommandHandler :
    IRequestHandler<DownloadDeviceFileCommand, (byte[], string)?>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;

    public DownloadDeviceFileCommandHandler(
        IStorageAsyncService storageAsyncService, 
        IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<(byte[], string)?> Handle(DownloadDeviceFileCommand request, 
                                          CancellationToken cancellationToken)
    {
        var entity = await _context.DeviceFiles
            .FirstOrDefaultAsync(x => x.Id == request.fileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.DEVICE_FILE;

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
