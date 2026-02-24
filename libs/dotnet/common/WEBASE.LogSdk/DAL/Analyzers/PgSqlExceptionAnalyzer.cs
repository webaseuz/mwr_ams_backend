
using Npgsql;

namespace WEBASE.LogSdk.DAL.Analyzers;

public class PgSqlExceptionAnalyzer : IExceptionAnalyzer
{
    public bool IsUniqueConstraintException(Exception exception)
    {
        if (exception is NpgsqlException npgsqlException && npgsqlException.SqlState == "23505")
        {
            // Check if the error message contains "unique constraint"
            return true;
        }

        return false;
    }
}
