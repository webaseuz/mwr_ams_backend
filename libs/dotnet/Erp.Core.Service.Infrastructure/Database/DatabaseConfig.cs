namespace Erp.Core.Service.Infrastructure;

public class DatabaseConfig
{
    public AppDatabaseConfig AppDatabase { get; set; }
}

public class AppDatabaseConfig
{
    public string ConnectionString { get; set; }
}
