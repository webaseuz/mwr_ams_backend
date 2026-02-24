using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class DownloadServiceApplicationFileCommandHandler :
    IRequestHandler<DownloadServiceApplicationFileCommand, (byte[], string)?>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;

    public DownloadServiceApplicationFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<(byte[], string)?> Handle(
        DownloadServiceApplicationFileCommand request, 
        CancellationToken cancellationToken)
    {
        var entityFile = await _context.ServiceApplicationFiles
            .FirstOrDefaultAsync(x => x.Id == request.fileId, cancellationToken);

        var entityExecutorFile = await _context.ServiceApplicationExecutorFiles
            .FirstOrDefaultAsync(x => x.Id == request.fileId, cancellationToken);
        
        StorageFile file;
        string document = FileStorageConst.SERVICE_APPLICATION_FILE;

        if (entityFile is null && entityExecutorFile is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.fileId);
        else if(entityExecutorFile is null)
        {
            file = await _storageAsyncService.GetFileAsync(document, entityFile.OwnerId.ToString(), request.fileId);
            file.FileName = entityFile.FileName;
        }
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entityExecutorFile.OwnerId.ToString(), request.fileId);
            file.FileName = entityExecutorFile.FileName;
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
