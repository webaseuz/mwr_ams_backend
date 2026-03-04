using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class MobileAppVersionFileDownloadCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService) : IRequestHandler<MobileAppVersionFileDownloadCommand, (byte[], string)?>
{
    public async Task<(byte[], string)?> Handle(MobileAppVersionFileDownloadCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.MobileAppVersions
            .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);

        WbStorageFile file;
        if (entity is null)
            file = await wbStorageService.GetTempFileAsync(FileStorageConst.MOBILE_APP_VERSION, request.FileId);
        else
        {
            file = await wbStorageService.GetFileAsync(FileStorageConst.MOBILE_APP_VERSION, entity.VersionCode, request.FileId);
            if (file != null) file.FileName = entity.FileName;
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), System.IO.Path.GetExtension(file.FileName)) : null;
    }
}
