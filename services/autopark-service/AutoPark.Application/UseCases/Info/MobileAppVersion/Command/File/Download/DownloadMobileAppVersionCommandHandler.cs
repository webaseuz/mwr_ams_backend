using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class DownloadMobileAppVersionCommandHandler :
    IRequestHandler<DownloadMobileAppVersionCommand, StorageFile>
{
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IReadEfCoreContext _context;
    public DownloadMobileAppVersionCommandHandler(IStorageAsyncService storageAsyncService, IReadEfCoreContext context)
    {
        _storageAsyncService = storageAsyncService;
        _context = context;
    }

    public async Task<StorageFile> Handle(
        DownloadMobileAppVersionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.MobileAppVersions
            .FirstOrDefaultAsync(x => x.Id == request.fileId, cancellationToken);

        StorageFile file;
        string document = FileStorageConst.MOBILE_APP_VERSION;

        if (entity is null)
            file = await _storageAsyncService.GetTempFileAsync(document, request.fileId);
        else
        {
            file = await _storageAsyncService.GetFileAsync(document, entity.VersionCode, request.fileId);
            file.FileName = entity.FileName;

        }

        return file != null ? file : null;
    }
}
