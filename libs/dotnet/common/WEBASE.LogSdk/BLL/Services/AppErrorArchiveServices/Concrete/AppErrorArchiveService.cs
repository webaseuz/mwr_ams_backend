using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.LogSdk.DAL.Repositories;
using WEBASE.Models;

namespace WEBASE.LogSdk.BLL.Services;

public class AppErrorArchiveService : BaseService<long, AppErrorArchive>
{
    public AppErrorArchiveService(Repository<long, AppErrorArchive> repository) : base(repository)
    {
    }

    public PagedResult<AppErrorArchive> GetList(SortFilterPageOptions dto)
    {
        return Repository.AllAsQueryable
                .SortFilter(dto)
                .AsPagedResult(dto);
    }

    public virtual AppErrorArchive Get(long id)
    {
        var ent = Repository.ById(id);
        CombineStatuses(Repository);

        return ent;
    }

    public bool ArchiveErrors(IEnumerable<AppError> allErrors)
    {
        var errors = new List<AppErrorArchive>();
        foreach (var error in allErrors)
        {
            var errorEntity = new AppErrorArchive()
            {
                CreatedAt = DateTime.Now,
                Detail = error.Detail,
                HostName = error.HostName,
                IpAddress = error.IpAddress,
                RequestBody = error.RequestBody,
                RequestParams = error.RequestParams,
                RequestPath = error.RequestPath,
                RequestTraceId = error.RequestTraceId,
                StatusCode = error.StatusCode,
                Title = error.Title,
                Type = error.Type,
                UserAgent = error.UserAgent,
                UserAgentDevice = error.UserAgentDevice,
                UserAgentOS = error.UserAgentOS,
                UserAgentUA = error.UserAgentUA,
                UserId = error.UserId,
                UserName = error.UserName,
            };

            errors.Add(errorEntity);
        }

        foreach (var error in errors)
            Repository.Create(error);

        if (IsValid)
            Repository.Save();

        return true;
    }
}
