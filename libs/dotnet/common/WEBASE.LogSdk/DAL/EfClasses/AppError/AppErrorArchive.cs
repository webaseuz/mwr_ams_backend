namespace WEBASE.LogSdk.DAL.EfClasses;

public class AppErrorArchive : AppErrorBase
{
    public virtual ErrorScopeArchive ErrorScopeArchive { get; set; }
}
