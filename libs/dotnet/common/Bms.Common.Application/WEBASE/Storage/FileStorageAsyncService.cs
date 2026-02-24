
using Bms.WEBASE.Extensions;

namespace Bms.WEBASE.Storage;

//This is first version .I had few time so may be there are incorrect codes inside class (Azizbek)
public class FileStorageAsyncService : IStorageAsyncService
{
    private readonly FileStorageConfig _config;
    private Dictionary<string, List<Guid>> _markedForDeleteFileIds = [];
    private Dictionary<string, List<Guid>> _markedForMoveToPersistentFileIds = [];

    public FileStorageAsyncService(FileStorageConfig config)
    {
        _config = config;
    }

    public virtual async Task ResolveMarkedFilesAsync(
        string document,
        string documentId)
    {
        await ResolveMarkedFilesAsync(document, documentId, false);
    }

    public virtual async Task ResolveMarkedFilesAsync(
        string document,
        string documentId,
        bool force)
    {
        try
        {
            string key = $"{document}_{documentId}";

            if (_markedForDeleteFileIds.ContainsKey(key))
            {
                await DeleteAsync(document, documentId, _markedForDeleteFileIds[key].ToArray());

                _markedForDeleteFileIds[key].Clear();
            }

            if (_markedForMoveToPersistentFileIds.ContainsKey(key))
            {
                await MoveToPersistentAsync(document, documentId, force, [.. _markedForMoveToPersistentFileIds[key]]);

                _markedForMoveToPersistentFileIds[key].Clear();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public virtual void MarkFileForDelete(
        string document,
        string documentId,
        params Guid[] fileIds)
    {
        if (document.NullOrEmpty())
            throw new ArgumentException($"{nameof(document)} cannot null or empty", nameof(document));
        if (documentId.NullOrEmpty())
            throw new ArgumentException($"{nameof(documentId)} cannot null or empty", nameof(documentId));

        string key = $"{document}_{documentId}";

        if (!_markedForDeleteFileIds.ContainsKey(key))
            _markedForDeleteFileIds.Add(key, new List<Guid>());

        _markedForDeleteFileIds[key].AddRange(fileIds);
    }

    public virtual void MarkFileForMoveToPersistent(
        string document,
        string documentId,
        params Guid[] tempFileIds)
    {
        if (document.NullOrEmpty())
            throw new ArgumentException($"{nameof(document)} cannot null or empty", nameof(document));
        if (documentId.NullOrEmpty())
            throw new ArgumentException($"{nameof(documentId)} cannot null or empty", nameof(documentId));

        string key = $"{document}_{documentId}";

        if (!_markedForMoveToPersistentFileIds.ContainsKey(key))
            _markedForMoveToPersistentFileIds.Add(key, new List<Guid>());

        _markedForMoveToPersistentFileIds[key].AddRange(tempFileIds);
    }

    public virtual async Task<StorageFile> GetFileAsync(
        string document,
        string documentId,
        Guid fileId)
    {
        try
        {
            string path = Path.Combine(_config.Path, document, documentId);
            if (!Directory.Exists(path))
            {
                throw new FileStorageException("Файл не найдено");
            }

            DirectoryInfo dir = new(path);
            var files = dir.GetFiles($"{fileId}*");

            if (files.Length == 0)
                throw new FileStorageException("Файл не найдено");
            else if (files.Length > 1)
                throw new FileStorageException("Файл в папке неоднозначен");
            else
            {
                MemoryStream ms = new();
                using (var fs = files[0].OpenRead())
                {
                    fs.CopyTo(ms);
                }
                return await Task.FromResult(new StorageFile(fileId, files[0].Name, ms, files[0].Length));
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual async Task<StorageFile> GetTempFileAsync(
        string document,
        Guid tempFileId)
    {
        try
        {

            var fileInfos = GetTempFileInfos(document, tempFileId);

            if (fileInfos.Any())
            {
                string fileName = Path.Combine(_config.TempPath, document, $"{fileInfos[0].FileId}{fileInfos[0].FileName}");
                MemoryStream ms = new();
                using (var fs = File.OpenRead(fileName))
                {
                    fs.CopyTo(ms);
                }
                return await Task.FromResult(new StorageFile(tempFileId, fileInfos[0].FileName, ms, fileInfos[0].FileSize));
            }

            return null;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public virtual IStorageFileInfo[] GetTempFileInfos(
        string document,
        params Guid[] fileIds)
    {

        try
        {
            string path = Path.Combine(_config.TempPath, document);

            if (!Directory.Exists(path))
                return [];

            DirectoryInfo dir = new(path);

            IStorageFileInfo[] result = new IStorageFileInfo[fileIds.Length];

            for (int i = 0; i < fileIds.Length; i++)
            {
                Guid fileId = fileIds[i];

                var files = dir.GetFiles($"{fileId}*");

                if (files.Length == 0)
                    throw new FileStorageException($"Temp file id: `{fileId}` not found in folder: `{document}`");
                else if (files.Length > 1)
                    throw new FileStorageException($"Temp file id: `{fileId}` ambiguous in folder: `{document}`");
                else
                {
                    string fileName = files[0].Name.Substring(fileId.ToString().Length);
                    result[i] = new StorageFileInfo(fileId, fileName, files[0].Length);
                }
            }

            return result;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public virtual async Task<IEnumerable<IStorageFileInfo>> SaveAsync(
        string document,
        string documentId,
        params StorageFile[] files)
    {
        return await SaveInternalAsync(_config.Path, document, documentId, files);
    }

    public virtual async Task<IEnumerable<IStorageFileInfo>> SaveTempAsync(
        string document,
        params StorageFile[] files)
    {
        return await SaveInternalAsync(_config.TempPath, document, null!, files);
    }

    public virtual async Task DeleteAsync(
        string document,
        string documentId,
        params Guid[] fileIds)
    {
        await DeleteInternal(_config.Path, document, documentId, fileIds);
    }

    public virtual async Task DeleteTempAsync(
        string document,
        params Guid[] tempFileIds)
    {
        await DeleteInternal(_config.TempPath, document, null, tempFileIds);
    }

    public virtual async Task MoveToPersistentAsync(
        string document,
        string documentId,
        params Guid[] tempFileIds)
    {
        await MoveToPersistentAsync(document, documentId, false, tempFileIds);
    }

    public virtual async Task MoveToPersistentAsync(
        string document,
        string documentId,
        bool force,
        params Guid[] tempFileIds)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(document))
                throw new ArgumentException("Document name cannot be null or empty.", nameof(document));

            if (string.IsNullOrWhiteSpace(documentId))
                throw new ArgumentException("Document ID cannot be null or empty.", nameof(documentId));

            if (tempFileIds.Length == 0)
                return;

            string tempPath = Path.Combine(_config.TempPath, document);

            if (!Directory.Exists(tempPath))
                return;

            DirectoryInfo tempDir = new(tempPath);
            string path = Path.Combine(_config.Path, document, documentId);
            DirectoryInfo dir = Directory.CreateDirectory(path);
            var filesToMove = new List<Tuple<string, string>>();

            foreach (var tempFileId in tempFileIds)
            {
                var existFiles = dir.GetFiles($"{tempFileId}*");
                var tempFiles = tempDir.GetFiles($"{tempFileId}*");

                if (!force && existFiles.Length > 0)
                    throw new Exception($"Files with id `{tempFileId}` in persistent folder ({Path.Combine(document, documentId)}) already exist");

                if (tempFiles.Length == 0)
                    throw new FileStorageException($"Temp file id: `{tempFileId}` not found in folder: `{document}`");
                else if (tempFiles.Length > 1)
                    throw new FileStorageException($"Temp file id: `{tempFileId}` ambiguous in folder: `{document}`");

                filesToMove.Add(Tuple.Create(tempFiles[0].FullName, Path.Combine(path, $"{tempFileId}{tempFiles[0].Extension}")));
            }

            foreach (var fileToMove in filesToMove)
                File.Move(fileToMove.Item1, fileToMove.Item2, force);

            await Task.CompletedTask;
        }
        catch (Exception)
        {

            throw;
        }
    }


    protected virtual async Task<IEnumerable<IStorageFileInfo>> SaveInternalAsync(
        string basePath,
        string document,
        string documentId,
        params StorageFile[] files)
    {
        try
        {
            if (files.Length == 0)
                return null!;

            if (document.NullOrEmpty())
                throw new ArgumentException("Cannot be null or empty", nameof(document));

            string path = documentId == null ? Path.Combine(basePath, document) : Path.Combine(basePath, document, documentId);

            DirectoryInfo dir = Directory.CreateDirectory(path);

            foreach (var file in files)
            {
                if (file.FileId == Guid.Empty)
                    file.FileId = Guid.NewGuid();

                string fileName = Path.Combine(path, $"{file.FileId}{file.FileName}");

                using FileStream fs = File.Create(fileName);
                using Stream stream = file.GetStream();
                stream.CopyTo(fs);
                file.FileSize = stream.Length;
            }

            return await Task.FromResult(files.Cast<IStorageFileInfo>());

        }
        catch (Exception)
        {

            throw;
        }
    }


    protected virtual async Task DeleteInternal(string basePath,
                                                string document,
                                                string documentId,
                                                params Guid[] fileIds)
    {
        if (fileIds.Length == 0)
            return;

        string path = documentId == null ? Path.Combine(basePath, document) : Path.Combine(basePath, document, documentId);

        DirectoryInfo dir = Directory.CreateDirectory(path);

        await Task.Run(() =>
        {
            foreach (var fileId in fileIds)
            {
                var files = dir.GetFiles($"{fileId}*");

                foreach (var file in files)
                    File.Delete(file.FullName);
            }
        });
    }

    public virtual MemoryStream GetStaticFile(string fileName)
    {

        Stream fs = null;

        try
        {
            fs = GetStaticFileDirect(fileName);

            MemoryStream ms = new();
            fs.CopyTo(ms);
            ms.Position = 0;

            return ms;
        }
        finally
        {
            if (fs != null)
                fs.Dispose();
        }
    }

    public virtual Stream GetStaticFileDirect(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentException($"{nameof(fileName)} cannot be string null or empty", nameof(fileName));

        string path = Path.Combine(_config.StaticFilesPath, fileName);

        if (!File.Exists(path))
        {
            throw new FileStorageException($"Файл не найдено (Адрес: {path})");
        }

        return File.OpenRead(path);
    }

    public void SaveStaticFile(string fileName)
    {
        try
        {

            MemoryStream stream = new();
            var path = Path.Combine(_config.StaticFilesPath, fileName);

            if (!File.Exists(path))
                throw new FileStorageException($"Static file `{fileName}` not found");
            else
            {
                using var fs = File.OpenWrite(fileName);
                stream.Position = 0;
                stream.CopyTo(fs);
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
}
