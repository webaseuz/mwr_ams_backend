using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WEBASE;

namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public abstract class CustomJobRunner<TActionInputData, TActionInputDataSource, TActionExecuter> : ICustomJobRunner
    where TActionExecuter : ICustomJobActionExecuter<TActionInputData>
    where TActionInputDataSource : ICustomJobActionInputDataSource<TActionInputData>
{
    private readonly IServiceProvider _serviceProvider;
    private int _successCount = 0;
    private int _errorCount = 0;
    private int _cacheCount = 0;
    private DateTime _lastSyncAt = DateTime.MinValue;
    private readonly TimeSpan _syncInterval = TimeSpan.FromSeconds(5);
    private readonly object _syncLockObj = new object();

    public CustomJobRunner(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public abstract int JobTypeId { get; }

    public async Task Run(long jobId, string backgroundJobId = null)
    {
        using var runScope = _serviceProvider.CreateScope();
        var runContext = runScope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        var runAuthService = runScope.ServiceProvider.GetRequiredService<IMainAuthService>();
        var actionInputDataSource = runScope.ServiceProvider.GetService<TActionInputDataSource>();
        var loggerService = runScope.ServiceProvider.GetService<ILogger<CustomJob>>();
        var entity = await runContext.CustomJobs.Include(a => a.JobType)
            .FirstOrDefaultAsync(a => a.Id == jobId);

        var source = await actionInputDataSource.GetSource(entity);
        int k = source.Count();
        if (entity.JobTypeId != JobTypeId)
            throw new Exception($"{GetType().Name} and {entity.JobType.FullName} not compatible");

        UpdateEntity(runContext, entity, e =>
        {
            entity.BackgroundJobId = backgroundJobId;
            entity.StartAt = DateTime.Now;
            entity.TotalCount = source.Length;
            entity.Error = null;
            entity.ErrorCount = 0;
            entity.SuccessCount = 0;
            entity.CacheCount = 0;
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = 1;
        });
        loggerService.LogInformation("CustomJob Entity updated");

        try
        {
            loggerService.LogInformation("Parallel ForEachAsync started");

            await Parallel.ForEachAsync(source, new ParallelOptions() { MaxDegreeOfParallelism = 1 }, async (actionInputData, ct) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var scopeContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                CustomJobAction actionEntity = null;

                try
                {
                    var scopeAuthservice = scope.ServiceProvider.GetRequiredService<IMainAuthService>();
                    scopeAuthservice.ResetUserName("sys_admin");

                    //using var actionScope = _serviceProvider.CreateScope();
                    var executer = scope.ServiceProvider.GetRequiredService<TActionExecuter>();

                    actionEntity = AddActionEntity(scopeContext, entity.Id, actionInputData);
                    var result = await executer.Execute(entity, actionInputData);
                    try
                    {
                        UpdateActionEntity(scopeContext, actionEntity, ae =>
                        {
                            ae.EndAt = DateTime.Now;
                            ae.IsSuccess = true;
                            ae.ReturnData = result?.ReturnData;
                            ae.UserMessage = result?.UserMessage;
                            ae.FromCache = (result?.FromCache).GetValueOrDefault();
                        });

                        Interlocked.Increment(ref _successCount);
                        if (actionEntity.FromCache)
                            Interlocked.Increment(ref _cacheCount);
                    }
                    catch (WbClientException ex)
                    {

                        loggerService.LogError
                        (ex.GetInnermostException(), "Error in Parallel.ForEachAsync(child 'try')");

                        UpdateActionEntity(scopeContext, actionEntity, ae =>
                        {
                            ae.EndAt = DateTime.Now;
                            ae.Error = ex.Message;
                        });
                        Interlocked.Increment(ref _errorCount);
                    }
                    SyncEntity(runContext, entity);
                }
                catch (Exception ex)
                {
                    loggerService.LogError
                    (ex.GetInnermostException(), "Error in Parallel.ForEachAsync(parent 'try')");
                    if (actionEntity != null)
                    {
                        UpdateActionEntity(scopeContext, actionEntity, ae =>
                        {
                            ae.EndAt = DateTime.Now;
                            ae.HasException = true;
                            ae.Error = ex.GetInnermostException().ToString();
                        });
                    }
                    Interlocked.Increment(ref _errorCount);
                    SyncEntity(runContext, entity);
                }
            });

            loggerService.LogInformation("Parallel ForEachAsync completed");
            SyncEntity(runContext, entity, true);
        }
        catch (Exception ex)
        {
            loggerService.LogError
            (ex.GetInnermostException(), "Error in Parallel.ForEachAsync(first 'try')");
            UpdateEntity(runContext, entity, e =>
            {
                e.EndAt = DateTime.Now;
                e.Error = ex.ToString();
            });
            SyncEntity(runContext, entity);
        }
    }

    private void SyncEntity(IApplicationDbContext context, CustomJob entity, bool force = false)
    {
        if (!force && (DateTime.Now - _lastSyncAt < _syncInterval))
            return;

        lock (_syncLockObj)
        {
            DateTime now = DateTime.Now;
            if (!force && (now - _lastSyncAt < _syncInterval))
                return;
            _lastSyncAt = now;

            UpdateEntity(context, entity, e =>
            {
                e.SuccessCount = _successCount;
                e.ErrorCount = _errorCount;
                e.CacheCount = _cacheCount;
            });
        }
    }

    private CustomJobAction AddActionEntity(IApplicationDbContext context, long ownerId, TActionInputData sourceItem)
    {
        var actionEntity = new CustomJobAction
        {
            StartAt = DateTime.Now,
            InputData = JsonConvert.SerializeObject(sourceItem),
            OwnerId = ownerId,
            IsSuccess = false,
            HasException = false,
            FromCache = false
        };
        context.CustomJobActions.Add(actionEntity);
        ((DbContext)context).SaveChanges();
        return actionEntity;
    }

    private void UpdateActionEntity(IApplicationDbContext context, CustomJobAction actionEntity, Action<CustomJobAction> action)
    {
        var dbContext = (DbContext)context;
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            action(actionEntity);
            dbContext.SaveChanges();
            transaction.Commit();
        }
    }

    private void UpdateEntity(IApplicationDbContext context, CustomJob entity, Action<CustomJob> action)
    {
        var dbContext = (DbContext)context;
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            //context.Set<CustomJob>().Lock(entity.Id);
            action(entity);
            dbContext.SaveChanges();
            transaction.Commit();
        }
    }
}
