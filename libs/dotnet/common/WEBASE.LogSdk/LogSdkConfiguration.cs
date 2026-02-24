using WEBASE.LogSdk.Core.Enums;

namespace WEBASE.LogSdk
{
    public interface ILogSdkConfiguration
    {
        string ApplicationName { get; set; }
        DatabaseType DatabaseType { get; set; }
        string ConnectionString { get; set; }
        AppErrorOptions AppError { get; set; }
        AppErrorArchiveOptions AppErrorArchive { get; set; }
        bool ShowControllers { get; set; }
    }

    public class LogSdkConfiguration : ILogSdkConfiguration
    {
        public string ApplicationName { get; set; }
        public DatabaseType DatabaseType { get; set; }
        public string ConnectionString { get; set; }
        public AppErrorOptions AppError { get; set; }
        public AppErrorArchiveOptions AppErrorArchive { get; set; }
        public bool ShowControllers { get; set; } = false;
    }

    public class AppErrorOptions
    {
        public bool Enabled { get; set; }
        public bool IncludeBody { get; set; }
        public int DetailMaxLength { get; set; }
        public bool IncludeDetailInResponse { get; set; }
    }

    public class AppErrorArchiveOptions
    {
        public bool Enabled { get; set; }
        public bool IncludeBody { get; set; }
        public int DetailMaxLength { get; set; }
        public bool IncludeDetailInResponse { get; set; }
    }
}
