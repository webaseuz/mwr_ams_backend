using Microsoft.Data.SqlClient;

namespace WEBASE.LogSdk.DAL.Analyzers;

internal class SqlServerExceptionAnalyzer : IExceptionAnalyzer
{
    public bool IsUniqueConstraintException(Exception exception)
    {
        // Check if the exception is a SqlException
        if (exception is SqlException sqlException)
        {
            // Check for unique constraint violation error number
            return sqlException.Number == 2627 || sqlException.Number == 2601;
        }

        return false;
    }
}
