using Bms.WEBASE.Storage;
using MediatR;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.Devices;

public class UploadDeviceFileCommandHandler :
    IRequestHandler<UploadDeviceFileCommand, IEnumerable<IStorageFileInfo>>
{
    private readonly IStorageAsyncService _storageAsyncService;
    public UploadDeviceFileCommandHandler(IStorageAsyncService storageAsyncService)
    {
        _storageAsyncService = storageAsyncService;
    }
    public async Task<IEnumerable<IStorageFileInfo>> Handle(
        UploadDeviceFileCommand request, 
        CancellationToken cancellationToken)
    {
        List<IStorageFileInfo> allResults = [];
        try
        {
            foreach (var file in request.Files)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream, cancellationToken);
                StorageFile dtoFiles = new(file.FileName, memoryStream);
                var result = await UploadFilesAsync(dtoFiles);
                allResults.AddRange(result);
            }

            return allResults;
        }
        catch (Exception)
        {
            return Enumerable.Empty<IStorageFileInfo>();
        }
    }

    private async Task<IEnumerable<IStorageFileInfo>> UploadFilesAsync(params StorageFile[] files)
    {
        var document = FileStorageConst.DEVICE_FILE;

        var res = await _storageAsyncService.SaveTempAsync(document, files);
        return res;
    }
}
