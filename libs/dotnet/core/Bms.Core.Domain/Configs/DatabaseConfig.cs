namespace Bms.Core.Domain;


public class DatabaseConfig
{
    public PgSqlConfig PgSql { get; set; }
}

public class PgSqlConfig
{
    public string ConnectionString { get; set; }
}
