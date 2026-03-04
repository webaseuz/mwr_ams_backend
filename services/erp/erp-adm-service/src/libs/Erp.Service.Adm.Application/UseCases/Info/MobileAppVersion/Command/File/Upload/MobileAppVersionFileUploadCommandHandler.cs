using Erp.Core;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class MobileAppVersionFileUploadCommandHandler(
    IWbStorageService wbStorageService) : IRequestHandler<MobileAppVersionFileUploadCommand, IEnumerable<IWbStorageFileInfo>>
{
    public async Task<IEnumerable<IWbStorageFileInfo>> Handle(MobileAppVersionFileUploadCommand request, CancellationToken cancellationToken)
    {
        List<IWbStorageFileInfo> allResults = new();
        foreach (var file in request.Files)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var result = await wbStorageService.SaveTempAsync(FileStorageConst.MOBILE_APP_VERSION,
                new WbStorageFile(file.FileName, memoryStream));
            allResults.AddRange(result);
        }
        return allResults;
    }
}
