using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.LogSdk.DAL.Repositories;
using WEBASE.Models;

namespace WEBASE.LogSdk.BLL.Services;

public class AppErrorService : BaseService<long, AppError>
{

    public AppErrorService(Repository<long, AppError> repository)
        : base(repository)
    {

    }

    public IEnumerable<AppError> GetAll()
    {
        return Repository.AllAsQueryable.ToList();
    }

    public PagedResult<AppError> GetList(SortFilterPageOptions dto)
    {
        var result = Repository.AllAsQueryable
                               .SortFilter(dto)
                               .AsPagedResult(dto);
        return result;
    }

    public PagedResult<AppError> GetListBy(AppErrorOption dto)
    {
        var result = Repository.AllAsQueryable
                               .Where(x => x.ErrorScopeId == dto.Id)
                               .SortFilter(dto)
                               .AsPagedResult(dto);
        return result;
    }

    public virtual AppError Get(long id)
    {
        var ent = Repository.ById(id);
        CombineStatuses(Repository);

        return ent;
    }
}
