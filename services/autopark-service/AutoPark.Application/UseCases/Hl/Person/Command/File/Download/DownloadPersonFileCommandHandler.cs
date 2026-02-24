using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Persons;

public class DownloadPersonFileCommandHandler :
    IRequestHandler<DownloadPersonFileCommand, (byte[], string)?>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;
    public DownloadPersonFileCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<(byte[], string)?> Handle(
        DownloadPersonFileCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.People
            .FirstOrDefaultAsync(x => x.FileId == request.fileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.PERSON_FILE;

        if (entity is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.fileId);
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entity.Id.ToString(), request.fileId);
            file.FileName = entity.FileName;

        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
