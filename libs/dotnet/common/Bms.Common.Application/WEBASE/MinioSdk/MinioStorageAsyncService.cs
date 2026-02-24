using Bms.WEBASE.Extensions;
using Bms.WEBASE.Storage;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.Exceptions;
using System.Web;

namespace Bms.WEBASE.MinioSdk;

//There may be some errors.I had few time to write these.So I am sorry ! (Azizbek)
public class MinioStorageAsyncService :
    FileStorageAsyncService,
    IStorageAsyncService
{
    private readonly MinioConfig _config;

    private const string FILE_NAME_TAG_KEY = "filename";
    protected IMinioClient Client { get; }

    public MinioStorageAsyncService(MinioStorageClient minioClient) :
        base(minioClient.Config)
    {
        _config = minioClient.Config;
        Client = minioClient.Client;
    }

    public override async Task<StorageFile> GetFileAsync(string document,
                                        string documentId,
                                        Guid fileId)
    {
        try
        {
            ThrowIfNotValidConfig();

            ArgumentNullException.ThrowIfNull(document);

            ArgumentNullException.ThrowIfNull(documentId);

            var path = $"{document}/{documentId}";

            var objName = $"{path}/{fileId}";

            ObjectStat stat = null!;

            try
            {
                stat = await Client.StatObjectAsync(new StatObjectArgs()
                    .WithBucket(_config.Bucket)
                    .WithObject(objName));
            }
            catch (Exception ex)
            {
                if (ex.InnerException is not ObjectNotFoundException)
                    throw;

                throw new MinioDefaultException($"File (id: {fileId}) not found");
            }


            Stream stream = null!;

            var statOne = await Client.GetObjectAsync(new GetObjectArgs()
                .WithBucket(_config.Bucket)
                .WithObject(objName).WithCallbackStream(
                    s =>
                        {
                            var br = new BinaryReader(s);
                            var ms = new MemoryStream(br.ReadBytes((int)stat.Size));
                            stream = ms;
                        }
                ));

            Task.Delay(5).Wait();


            string fileName = FileNameDecode(stat.MetaData?.ContainsKey(FILE_NAME_TAG_KEY)
                == true ? stat.MetaData[FILE_NAME_TAG_KEY] : string.Empty);

            return new StorageFile(fileId,
                                   fileName ?? string.Empty,
                                   stream,
                                   fileSize: stat.Size);

        }
        catch (Exception)
        {

            throw;
        }
    }


    public override async Task<StorageFile> GetTempFileAsync(string document, Guid tempFileId)
    {
        try
        {
            ThrowIfNotValidConfig();

            ArgumentNullException.ThrowIfNull(document);


            var fileInfos = GetTempFileInfos(document, tempFileId);

            if (fileInfos.Length > 0)
            {
                string objName = $"{document}/{fileInfos[0].FileId}";

                Stream stream = null!;
                await Client.GetObjectAsync(new GetObjectArgs()
                    .WithBucket(_config.TempBucket)
                    .WithObject(objName)
                    .WithCallbackStream(s =>
                    {
                        var br = new BinaryReader(s);
                        var ms = new MemoryStream(br.ReadBytes((int)fileInfos[0].FileSize));
                        stream = ms;
                    }));

                await Task.Delay(5);

                return new StorageFile(tempFileId, fileInfos[0].FileName, stream, fileInfos[0].FileSize);
            }

            return null!;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public override async Task<IEnumerable<IStorageFileInfo>> SaveTempAsync(string document,
                                                           params StorageFile[] files)
    {
        ThrowIfNotValidConfig();

        ArgumentNullException.ThrowIfNull(document);

        return await SaveInternalAsync(_config.TempBucket, document, null!, files);
    }

    protected override async Task<IEnumerable<IStorageFileInfo>> SaveInternalAsync(string basePath,
                                                                  string document,
                                                                  string documentId,
                                                                  params StorageFile[] files)
    {
        if (files.Length == 0)
            return null!;

        if (document.NullOrEmpty())
            throw new ArgumentException("Cannot be null or empty", nameof(document));

        bool isTemp = basePath == _config.TempBucket;

        var path = isTemp ? document : $"{document}/{documentId}";

        foreach (var file in files)
        {
            if (file.FileId == Guid.Empty)
                file.FileId = Guid.NewGuid();

            string objName = $"{path}/{file.FileId}";

            try
            {

                using Stream stream = file.GetStream();
                var putArgs = new PutObjectArgs()
                    .WithBucket(basePath)
                    .WithObject(objName)
                    .WithStreamData(stream)
                    .WithObjectSize(stream.Length);

                if (!string.IsNullOrEmpty(file.FileName))
                    putArgs = putArgs.WithHeaders(
                        new Dictionary<string, string>
                        {
                            {
                                FILE_NAME_TAG_KEY,
                                FileNameEncode(file.FileName)
                            }
                        });

                await Client.PutObjectAsync(putArgs);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error uploading file {file.FileName} to MinIO", ex);
            }
        }

        return await Task.FromResult(files.Cast<IStorageFileInfo>());
    }

    public override async Task MoveToPersistentAsync(string document,
                                          string documentId,
                                          bool force,
                                          params Guid[] tempFileIds)
    {
        try
        {

            ThrowIfNotValidConfig();

            ArgumentNullException.ThrowIfNull(document);
            ArgumentNullException.ThrowIfNull(documentId);

            if (tempFileIds.Length == 0)
                return;

            var path = $"{document}/{documentId}";
            var filesToMove = new List<Tuple<string, string>>();

            foreach (var tempFileId in tempFileIds)
            {
                string destFile = $"{path}/{tempFileId}";
                string tempFile = $"{document}/{tempFileId}";

                if (!force && Exists(destFile))
                    throw new Exception($"File with id: {tempFileId} is persistent storage already exists");

                filesToMove.Add(Tuple.Create(tempFile, destFile));
            }

            try
            {
                foreach (var fileToMove in filesToMove)
                {
                    var statObjectArgs = new StatObjectArgs()
                        .WithBucket(_config.TempBucket)
                        .WithObject(fileToMove.Item1);

                    var objExists = await Client.StatObjectAsync(statObjectArgs);

                    if (objExists == null)
                        throw new ObjectNotFoundException($"Object {fileToMove.Item1} not found in {_config.TempBucket}");

                    var copySourceObjectArgs = new CopySourceObjectArgs()
                            .WithBucket(_config.TempBucket)
                            .WithObject(fileToMove.Item1);

                    var copyObjectArgs = new CopyObjectArgs()
                        .WithBucket(_config.Bucket)
                        .WithObject(fileToMove.Item2)
                        .WithCopyObjectSource(copySourceObjectArgs);

                    await Client.CopyObjectAsync(copyObjectArgs);

                    var removeObjectArgs = new RemoveObjectArgs()
                        .WithBucket(_config.TempBucket)
                        .WithObject(fileToMove.Item1);

                    await Client.RemoveObjectAsync(removeObjectArgs);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error {nameof(MoveToPersistentAsync)} to MinIO", ex);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public override async Task DeleteAsync(string document,
                                string documentId,
                                params Guid[] fileIds)
    {
        try
        {
            ThrowIfNotValidConfig();

            ArgumentNullException.ThrowIfNull(document);

            if (fileIds.Length == 0)
                return;

            string path = $"{document}/{documentId}";

            foreach (var fileId in fileIds)
            {
                string objName = $"{path}/{fileId}";

                await Client.RemoveObjectAsync(new RemoveObjectArgs()
                    .WithBucket(_config.Bucket)
                    .WithObject(objName));
            }

        }
        catch (Exception)
        {

            throw;
        }
    }

    public override async Task DeleteTempAsync(string document, params Guid[] tempFileIds)
    {
        ThrowIfNotValidConfig();

        ArgumentException.ThrowIfNullOrEmpty(document);

        foreach (var fileId in tempFileIds)
        {
            string objName = $"{document}/{fileId}";

            await Client.RemoveObjectAsync(new RemoveObjectArgs()
                .WithBucket(_config.TempBucket)
                .WithObject(objName));
        }
    }



    public override IStorageFileInfo[] GetTempFileInfos(string document, params Guid[] fileIds)
    {
        try
        {
            ThrowIfNotValidConfig();

            ArgumentNullException.ThrowIfNull(document);

            IStorageFileInfo[] result = new IStorageFileInfo[fileIds.Length];

            for (int i = 0; i < fileIds.Length; i++)
            {
                Guid fileId = fileIds[i];
                string objName = $"{document}/{fileId}";
                ObjectStat stat = null;

                try
                {
                    stat = Client.StatObjectAsync(new StatObjectArgs()
                        .WithBucket(_config.TempBucket)
                        .WithObject(objName)).Result;
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerException == null || ex.InnerException is not ObjectNotFoundException)
                        throw;

                    throw new MinioDefaultException($"Temp file (id: {fileId}) not found");
                }

                if (!stat.MetaData.ContainsKey(FILE_NAME_TAG_KEY) || stat.MetaData[FILE_NAME_TAG_KEY].NullOrEmpty())
                    throw new MinioDefaultException($"Filename metadata not found. Temp file id: {fileId}");
                else
                {
                    string fileName = FileNameDecode(stat.MetaData[FILE_NAME_TAG_KEY]);
                    result[i] = new StorageFileInfo(fileId, fileName, (int)stat.Size);
                }
            }

            return result;

        }
        catch (Exception)
        {

            throw;
        }
    }

    private void ThrowIfNotValidConfig()
    {
        if (string.IsNullOrEmpty(_config.TempBucket))
            throw new MinioInvalidConfigurationException($"{nameof(MinioConfig.TempBucket)} cannot be empty");

        if (string.IsNullOrEmpty(_config.Bucket))
            throw new MinioInvalidConfigurationException($"{nameof(MinioConfig.Bucket)} cannot be empty");
    }

    private bool Exists(string objectName)
    {
        try
        {
            return Client.StatObjectAsync(new StatObjectArgs()
                         .WithBucket(_config.Bucket)
                         .WithObject(objectName)).Result.Size > 0;
        }
        catch
        {
            return false;
        }
    }

    private string FileNameEncode(string fileName)
        => HttpUtility.UrlEncode(fileName);

    private string FileNameDecode(string encodedFileName)
        => HttpUtility.UrlDecode(encodedFileName);

}
