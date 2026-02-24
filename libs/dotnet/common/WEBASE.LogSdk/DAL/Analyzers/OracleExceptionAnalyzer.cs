using Oracle.ManagedDataAccess.Client;

namespace WEBASE.LogSdk.DAL.Analyzers;

public class OracleExceptionAnalyzer : IExceptionAnalyzer
{
    public bool IsUniqueConstraintException(Exception exception)
    {
        // Check if the exception is an OracleException
        if (exception is OracleException oracleException && oracleException.Number == 1)
        {
            // Check if the error message contains "unique constraint"
            return true;
        }
        return false;
    }
}
