
namespace Bms.WEBASE.Storage;

public interface IStorageAsyncService
{
    Task<StorageFile> GetFileAsync(string document, string documentId, Guid fileId);
    Task<StorageFile> GetTempFileAsync(string document, Guid fileId);

    Task<IEnumerable<IStorageFileInfo>> SaveAsync(string document, string documentId, params StorageFile[] files);
    Task<IEnumerable<IStorageFileInfo>> SaveTempAsync(string document, params StorageFile[] files);

    Task MoveToPersistentAsync(string document, string documentId, params Guid[] tempFileIds);
    Task MoveToPersistentAsync(string document, string documentId, bool force, params Guid[] tempFileIds);

    Task ResolveMarkedFilesAsync(string document, string documentId);
    Task ResolveMarkedFilesAsync(string document, string documentId, bool force);

    Task DeleteAsync(string document, string documentId, params Guid[] fileIds);
    Task DeleteTempAsync(string document, params Guid[] tempFileIds);



    void MarkFileForDelete(string document, string documentId, params Guid[] fileIds);
    void MarkFileForMoveToPersistent(string document, string documentId, params Guid[] fileIds);
    public IStorageFileInfo[] GetTempFileInfos(string document, params Guid[] fileIds);
    MemoryStream GetStaticFile(string fileName);
    void SaveStaticFile(string fileName);
    Stream GetStaticFileDirect(string fileName);
}
