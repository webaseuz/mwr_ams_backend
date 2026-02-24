using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.LogSdk.DAL.Repositories;

namespace WEBASE.LogSdk.BLL.Services;
public class ErrorScopeArchiveService : BaseService<long, ErrorScopeArchive>
{
    public ErrorScopeArchiveService(Repository<long, ErrorScopeArchive> repository)
        : base(repository)
    {
    }
}