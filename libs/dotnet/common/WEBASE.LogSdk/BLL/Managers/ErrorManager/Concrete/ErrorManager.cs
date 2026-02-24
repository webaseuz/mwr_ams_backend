using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StatusGeneric;
using System.Diagnostics;
using WEBASE.LogSdk.BLL.Services;
using WEBASE.LogSdk.BLL.Wrappers;
using WEBASE.LogSdk.Core.Helpers;
using WEBASE.LogSdk.DAL;
using WEBASE.LogSdk.DAL.EfClasses;

namespace WEBASE.LogSdk.BLL.Managers;
public class ErrorManager : StatusGenericHandler, IErrorManager
{
    private readonly AppErrorService _appErrorService;
    private readonly ErrorScopeService _errorScopeService;
    private readonly LogSdkContext _dbContext;
    private readonly ILogger<AppError> _logger;
    public ErrorManager(AppErrorService appErrorService, ErrorScopeService errorScopeService,
        LogSdkContext dbcontext, ILogger<AppError> logger)
    {
        _appErrorService = appErrorService;
        _errorScopeService = errorScopeService;
        _dbContext = dbcontext;
        _logger = logger;
    }

    public async Task ErrorOccuredAsync(AppError appError)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string scopeKey = ScopeIntervalHelper.GetKey(DateTime.Now);

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            var scope = await _errorScopeService.FindQuery(appError, scopeKey)
                .FirstOrDefaultAsync();

            CombineStatuses(_errorScopeService);
            if (HasErrors) return;

            if (scope is null)
            {
                var createScope = ErrorScopeWrapper.Wrap(appError);
                scope = _errorScopeService.Create(createScope, true);
                CombineStatuses(_errorScopeService);
                if (HasErrors) return;
            }

            appError.ErrorScopeId = scope.Id;
            _appErrorService.Create(appError, false);
            CombineStatuses(_appErrorService);
            if (HasErrors) return;

            if (scope.IsFixed == true)
            {
                scope.IsFixed = false;
                _errorScopeService.Update(scope, false);
            }

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > 1000)
            _logger.LogWarning($"<AppError> WRITE performance is slow: {stopwatch.ElapsedMilliseconds} ms");
    }
}