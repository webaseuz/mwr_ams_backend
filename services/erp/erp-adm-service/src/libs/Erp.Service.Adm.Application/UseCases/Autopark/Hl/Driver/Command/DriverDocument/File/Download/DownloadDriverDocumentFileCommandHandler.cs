using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Storage;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DownloadDriverDocumentFileCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService) : IRequestHandler<DriverDocumentDownloadCommand, (byte[], string)?>
{
    public async Task<(byte[], string)?> Handle(DriverDocumentDownloadCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.DriverDocuments
            .FirstOrDefaultAsync(x => x.DocumentFileId == request.FileId, cancellationToken);

        WbStorageFile file;
        string document = FileStorageConst.DRIVER_DOCUMENT_FILE;

        if (entity is null)
            file = await wbStorageService.GetTempFileAsync(document, request.FileId);
        else
        {
            file = await wbStorageService.GetFileAsync(document, entity.OwnerId.ToString(), request.FileId);
            file.FileName = entity.DocumentFileName ?? "Image.png";
        }

        return file != null ? (((MemoryStream)file.GetStream()).ToArray(), Path.GetExtension(file.FileName)) : null;
    }
}
