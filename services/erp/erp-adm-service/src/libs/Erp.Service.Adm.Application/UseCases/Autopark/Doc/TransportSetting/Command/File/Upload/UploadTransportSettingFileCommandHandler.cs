using Erp.Core;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE.Storage;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UploadTransportSettingFileCommandHandler(
    IWbStorageService wbStorageService) : IRequestHandler<TransportSettingFileUploadCommand, IEnumerable<IWbStorageFileInfo>>
{
    public async Task<IEnumerable<IWbStorageFileInfo>> Handle(TransportSettingFileUploadCommand request, CancellationToken cancellationToken)
    {
        List<IWbStorageFileInfo> allResults = new();
        foreach (var file in request.Files)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var result = await wbStorageService.SaveTempAsync(FileStorageConst.TRANSPORT_SETTING_FILE,
                new WbStorageFile(file.FileName, memoryStream));
            allResults.AddRange(result);
        }
        return allResults;
    }
}
