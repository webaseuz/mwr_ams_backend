using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class UploadDriverDocumentFileCommandHandler :
    IRequestHandler<UploadDriverDocumentFileCommand, IEnumerable<IStorageFileInfo>>
{
    private readonly IStorageAsyncService _storageAsyncService;
    public UploadDriverDocumentFileCommandHandler(IStorageAsyncService storageAsyncService)
    {
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IEnumerable<IStorageFileInfo>> Handle(
        UploadDriverDocumentFileCommand request,
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
            // Not Completed
            return [];
        }
    }
    private async Task<IEnumerable<IStorageFileInfo>> UploadFilesAsync(params StorageFile[] files)
    {
        var document = FileStorageConst.DRIVER_DOCUMENT_FILE;

        var res = await _storageAsyncService.SaveTempAsync(document, files);
        return res;
    }
}
