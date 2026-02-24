using AutoPark.Domain.Constants;
using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.Persons;

public class UploadPersonFileCommandHandler :
    IRequestHandler<UploadPersonFileCommand, IEnumerable<IStorageFileInfo>>
{
    private readonly IStorageAsyncService _storageAsyncService;
    public UploadPersonFileCommandHandler(IStorageAsyncService storageAsyncService)
    {
        _storageAsyncService = storageAsyncService;
    }
    public async Task<IEnumerable<IStorageFileInfo>> Handle(
        UploadPersonFileCommand request,
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
        var document = FileStorageConst.PERSON_FILE;

        var res = await _storageAsyncService.SaveTempAsync(document, files);
        return res;
    }
}
