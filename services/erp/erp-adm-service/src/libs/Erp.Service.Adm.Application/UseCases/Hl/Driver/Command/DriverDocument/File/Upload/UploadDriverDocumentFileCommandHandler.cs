using Erp.Core;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE.Storage;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UploadDriverDocumentFileCommandHandler(
    IWbStorageService wbStorageService) : IRequestHandler<DriverDocumentUploadCommand, IEnumerable<IWbStorageFileInfo>>
{
    public async Task<IEnumerable<IWbStorageFileInfo>> Handle(DriverDocumentUploadCommand request, CancellationToken cancellationToken)
    {
        List<IWbStorageFileInfo> allResults = new();
        foreach (var file in request.Files)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream, cancellationToken);
            var result = await wbStorageService.SaveTempAsync(FileStorageConst.DRIVER_DOCUMENT_FILE,
                new WbStorageFile(file.FileName, memoryStream));
            allResults.AddRange(result);
        }
        return allResults;
    }
}
