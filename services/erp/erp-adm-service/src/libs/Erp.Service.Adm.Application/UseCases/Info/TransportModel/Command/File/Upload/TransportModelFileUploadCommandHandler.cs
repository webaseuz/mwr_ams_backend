using Erp.Core;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.Storage;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TransportModelFileUploadCommandHandler(
    IWbStorageService wbStorageService) : IRequestHandler<TransportModelFileUploadCommand, IEnumerable<IWbStorageFileInfo>>
{
    public async Task<IEnumerable<IWbStorageFileInfo>> Handle(TransportModelFileUploadCommand request, CancellationToken cancellationToken)
    {
        List<IWbStorageFileInfo> allResults = new();
        foreach (var file in request.Files)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var result = await wbStorageService.SaveTempAsync(FileStorageConst.TRANSPORT_MODEL_FILE,
                new WbStorageFile(file.FileName, memoryStream));
            allResults.AddRange(result);
        }
        return allResults;
    }
}
