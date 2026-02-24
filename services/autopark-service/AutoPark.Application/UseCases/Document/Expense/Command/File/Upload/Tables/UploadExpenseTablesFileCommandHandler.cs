using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class UploadExpenseTablesFileCommandHandler :
    IRequestHandler<UploadExpenseTablesFileCommand, IEnumerable<IStorageFileInfo>>
{
    private readonly IStorageAsyncService _storageAsyncService;
    public UploadExpenseTablesFileCommandHandler(IStorageAsyncService storageAsyncService)
    {
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IEnumerable<IStorageFileInfo>> Handle(UploadExpenseTablesFileCommand request,
                                                            CancellationToken cancellationToken)
    {
        List<IStorageFileInfo> allResults = new List<IStorageFileInfo>();
        try
        {
            foreach (var file in request.Files)
            {
                var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                StorageFile dtoFiles = new StorageFile(file.FileName, memoryStream);

                var result = await _storageAsyncService.SaveTempAsync(request.DocumentName, dtoFiles);

                allResults.AddRange(result);
            }

            return allResults;
        }
        catch (Exception)
        {
            return Enumerable.Empty<IStorageFileInfo>();
        }
    }
}
