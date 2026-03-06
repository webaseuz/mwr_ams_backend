using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Storage;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DownloadTransportSettingFileCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService) : IRequestHandler<TransportSettingFileDownloadCommand, (byte[], string)?>
{
    public async Task<(byte[], string)?> Handle(TransportSettingFileDownloadCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TransportSettingFiles
            .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);

        WbStorageFile file;
        if (entity is null)
            file = await wbStorageService.GetTempFileAsync(FileStorageConst.TRANSPORT_SETTING_FILE, request.FileId);
        else
        {
            file = await wbStorageService.GetFileAsync(FileStorageConst.TRANSPORT_SETTING_FILE, entity.OwnerId.ToString(), request.FileId);
            file.FileName = entity.FileName;
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
