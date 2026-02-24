using Minio;

namespace Bms.WEBASE.MinioSdk;

public class MinioStorageClient :
    IDisposable
{
    public IMinioClient Client { get; } = null!;
    public MinioConfig Config { get; } = null!;

    public MinioStorageClient(MinioConfig minioConfig)
    {
        Config = minioConfig;
        Client = new MinioClient()
                .WithEndpoint(minioConfig.Endpoint)
                .WithCredentials(minioConfig.AccessKey, minioConfig.SecretKey)
                .Build();
    }
    public void Dispose()
    {
        try
        {
            Client?.Dispose();
        }
        catch (Exception)
        { }
    }
}
