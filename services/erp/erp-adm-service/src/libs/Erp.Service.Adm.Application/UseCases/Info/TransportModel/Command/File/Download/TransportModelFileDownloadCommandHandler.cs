using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TransportModelFileDownloadCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService) : IRequestHandler<TransportModelFileDownloadCommand, (byte[], string)?>
{
    public async Task<(byte[], string)?> Handle(TransportModelFileDownloadCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TransportModelFiles
            .FirstOrDefaultAsync(x => x.Id == request.FileId, cancellationToken);

        WbStorageFile file;
        if (entity is null)
            file = await wbStorageService.GetTempFileAsync(FileStorageConst.TRANSPORT_MODEL_FILE, request.FileId);
        else
        {
            file = await wbStorageService.GetFileAsync(FileStorageConst.TRANSPORT_MODEL_FILE, entity.TransportModelId.ToString(), request.FileId);
            if (file != null) file.FileName = entity.FileName;
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), System.IO.Path.GetExtension(file.FileName)) : null;
    }
}
