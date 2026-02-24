using Microsoft.EntityFrameworkCore;
using WEBASE.LogSdk.Core.Helpers;
using WEBASE.LogSdk.DAL.Analyzers;
using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.LogSdk.DAL.Repositories;
using WEBASE.Models;

namespace WEBASE.LogSdk.BLL.Services;
public class ErrorScopeService : BaseService<long, ErrorScope>
{
    private readonly IExceptionAnalyzer _exceptionAnalyzer;
    public ErrorScopeService(Repository<long, ErrorScope> repository,
        IExceptionAnalyzer exceptionAnalyzer)
        : base(repository)
    {
        _exceptionAnalyzer = exceptionAnalyzer;
    }

    public ErrorScopeDashboardDto GetDashboard(ErrorScopeDashboardOptions options)
    {
        var res = new ErrorScopeDashboardDto();

        res.ExistServices = Repository.AllAsQueryable.Select(x => x.HostName).ToHashSet();

        var query = Repository.AllAsQueryable;

        if (options.IsFixed is not null)
            query = query.Where(x => x.IsFixed == options.IsFixed);

        if (options.IsDaily)
        {
            string scopekey = ScopeIntervalHelper.GetKey(DateTime.Now);
            query = query.Where(x => x.ScopeKey == scopekey);
        }

        res.Divisions = (from scope in query
                         join error in Repository.DbContext.Set<AppError>()
                         on scope.Id equals error.ErrorScopeId
                         group error by scope.HostName into groupedErrors
                         select new ErrorScopeDashboardDivisionDto
                         {
                             Host = groupedErrors.Key,
                             ErrorCount = groupedErrors.Count(),
                             ErrorFixedCount = groupedErrors.Count(t => t.ErrorScope.IsFixed == true),
                             ErrorNotFixedCount = groupedErrors.Count(t => t.ErrorScope.IsFixed == false),
                         })
                         .OrderByDescending(x => x.ErrorCount)
                         .ToList();

        int totalCount = res.Divisions.Sum(x => x.ErrorCount);

        foreach (var division in res.Divisions)
        {
            division.ErrorPercent = Math.Round((double)division.ErrorCount / totalCount * 100, 2);
            division.ErrorFixedPercent = Math.Round((double)division.ErrorFixedCount / division.ErrorCount * 100, 2);
            division.ErrorNotFixedPercent = Math.Round((double)division.ErrorNotFixedCount / division.ErrorCount * 100, 2);
        }

        return res;
    }

    public PagedResult<ErrorScopeDto> GetList(ErrorScopeOption options)
    {
        var result = (from scope in Repository.AllAsQueryable
                      let count = Repository.DbContext.Set<AppError>()
                        .Where(x => x.ErrorScopeId == scope.Id)
                        .Count()
                      let lastOccured = Repository.DbContext.Set<AppError>()
                         .Where(x => x.ErrorScopeId == scope.Id)
                         .Select(x => x.CreatedAt)
                         .OrderByDescending(t => t)
                         .FirstOrDefault()
                      select new ErrorScopeDto()
                      {
                          Id = scope.Id,
                          Code = scope.Code,
                          Count = count,
                          CreatedAt = scope.CreatedAt,
                          ModifiedAt = scope.ModifiedAt,
                          NormalizedRequestPath = scope.NormalizedRequestPath,
                          HostName = scope.HostName,
                          IsFixed = scope.IsFixed,
                          ScopeKey = scope.ScopeKey,
                          Title = scope.Title,
                          Type = scope.Type,
                          LastOccuredAt = lastOccured,
                          FixedAt = scope.IsFixed == true ? scope.ModifiedAt : null
                      })
                     .AsNoTracking()
                     .SortFilter(options)
                     .AsPagedResult(options);

        result.Rows = result.Rows.ToList();

        foreach (var item in result.Rows)
        {
            item.CanFix = item.IsFixed == null || item.IsFixed == false;
        }

        return result;
    }
    public ErrorScopeTabDto GetTabInfo(bool isDaily)
    {
        var query = Repository.AllAsQueryable;

        if (isDaily)
        {
            string scopeKey = ScopeIntervalHelper.GetKey(DateTime.Now);
            query = query.Where(x => x.ScopeKey == scopeKey);
        }

        // Aggregate query directly, minimizing intermediate operations
        var result = query.GroupBy(x => true) // Group by a constant to ensure one group for all records
            .Select(group => new ErrorScopeTabDto
            {
                All = group.Count(),
                Fixed = group.Count(x => x.IsFixed == true),
                NotFixed = group.Count(x => x.IsFixed == false)
            })
            .FirstOrDefault();

        return result ?? new ErrorScopeTabDto(); // Return an empty DTO if no data exists
    }
    public virtual ErrorScopeDto Get(long id)
    {
        var result = (from scope in Repository.AllAsQueryable
                      let count = Repository.DbContext.Set<AppError>().Where(x => x.ErrorScopeId == scope.Id).Count()
                      let lastOccured = Repository.DbContext.Set<AppError>()
                         .Where(x => x.ErrorScopeId == scope.Id)
                         .Select(x => x.CreatedAt)
                         .OrderByDescending(t => t)
                         .FirstOrDefault()
                      select new ErrorScopeDto()
                      {
                          Id = scope.Id,
                          Code = scope.Code,
                          Count = count,
                          CreatedAt = scope.CreatedAt,
                          ModifiedAt = scope.ModifiedAt,
                          NormalizedRequestPath = scope.NormalizedRequestPath,
                          HostName = scope.HostName,
                          IsFixed = scope.IsFixed,
                          ScopeKey = scope.ScopeKey,
                          Title = scope.Title,
                          Type = scope.Type,
                          LastOccuredAt = lastOccured
                      }).AsNoTracking()
                     .FirstOrDefault(x => x.Id == id);

        if (result is null)
        {
            AddError("Not found");
            return null!;
        }

        result.CanFix = result.IsFixed == null || result.IsFixed == false;
        result.FixedAt = result.IsFixed == true ? result.ModifiedAt : null;

        return result;
    }

    public IQueryable<ErrorScope> FindQuery(AppError entity, string scopeKey)
        => Repository.DbContext.Set<ErrorScope>().Where(x =>
                    x.HostName == entity.HostName &&
                    x.Type == entity.Type &&
                    x.NormalizedRequestPath == entity.NormalizedRequestPath &&
                    x.ScopeKey == scopeKey &&
                    x.Code == entity.Code);
    public IQueryable<ErrorScope> FindQuery(ErrorScope entity)
        => Repository.DbContext.Set<ErrorScope>().Where(x =>
                    x.HostName == entity.HostName &&
                    x.Type == entity.Type &&
                    x.NormalizedRequestPath == entity.NormalizedRequestPath &&
                    x.ScopeKey == entity.ScopeKey &&
                    x.Code == entity.Code);
    public override ErrorScope Create(ErrorScope entity, bool autoSave = true)
    {
        try
        {
            return base.Create(entity, autoSave);
        }
        catch (DbUpdateException ex)
            when (_exceptionAnalyzer.IsUniqueConstraintException(ex))
        {
            return FindQuery(entity).First();
        }
    }
    public void Fix(long scopeId)
    {
        var ent = Repository.ById(scopeId);

        if (ent is null)
        {
            AddError("Not found");
            return;
        }

        ent.IsFixed = true;

        Repository.Save();
    }
}