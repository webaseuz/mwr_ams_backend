using Bms.WEBASE.Storage;

namespace Bms.WEBASE.MinioSdk;

public class MinioConfig :
    FileStorageConfig
{
    public string Endpoint { get; set; } = null!;
    public string Bucket { get; set; } = null!;
    public string TempBucket { get; set; } = null!;
    public string AccessKey { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public bool IsSingletonClient { get; set; }
}
