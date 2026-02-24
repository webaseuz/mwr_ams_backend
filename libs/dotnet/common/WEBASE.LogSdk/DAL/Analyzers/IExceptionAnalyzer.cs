namespace WEBASE.LogSdk.DAL.Analyzers;

public interface IExceptionAnalyzer
{
    public bool IsUniqueConstraintException(Exception exception);
}
