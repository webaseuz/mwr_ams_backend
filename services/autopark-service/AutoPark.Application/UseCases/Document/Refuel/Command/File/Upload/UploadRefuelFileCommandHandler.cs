using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class UploadRefuelFileCommandHandler :
    IRequestHandler<UploadRefuelFileCommand, IEnumerable<IStorageFileInfo>>
{
    private readonly IStorageAsyncService _storageAsyncService;
    public UploadRefuelFileCommandHandler(IStorageAsyncService storageAsyncService)
    {
        _storageAsyncService = storageAsyncService;
    }
    public async Task<IEnumerable<IStorageFileInfo>> Handle(
        UploadRefuelFileCommand request,
        CancellationToken cancellationToken)
    {
        List<IStorageFileInfo> allResults = new List<IStorageFileInfo>();
        try
        {
            foreach (var file in request.Files)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                StorageFile dtoFiles = new StorageFile(file.FileName, memoryStream);
                var result = await UploadFilesAsync(dtoFiles);
                allResults.AddRange(result);
            }

            return allResults;
        }
        catch (Exception)
        {
            // Not Completed
            return Enumerable.Empty<IStorageFileInfo>();
        }
    }
    private async Task<IEnumerable<IStorageFileInfo>> UploadFilesAsync(params StorageFile[] files)
    {
        var document = FileStorageConst.REFUEL_FILE;

        var res = await _storageAsyncService.SaveTempAsync(document, files);
        return res;
    }
}
