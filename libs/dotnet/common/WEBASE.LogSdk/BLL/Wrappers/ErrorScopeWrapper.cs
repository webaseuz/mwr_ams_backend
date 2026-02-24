using WEBASE.LogSdk.BLL.Normalizers;
using WEBASE.LogSdk.Core.Helpers;
using WEBASE.LogSdk.DAL.EfClasses;

namespace WEBASE.LogSdk.BLL.Wrappers;

public class ErrorScopeWrapper
{
    /// <summary>
    /// Wraps an AppError into an ErrorScope.
    /// </summary>
    /// <param name="appError"></param>
    /// <returns></returns>
    public static ErrorScope Wrap(AppError appError)
    {
        // Create a new ErrorScope object
        var scope = new ErrorScope()
        {
            HostName = appError.HostName,
            IsFixed = false,
            Title = appError.Title,
            Type = appError.Type,
        };

        scope.ScopeKey = ScopeIntervalHelper.GetKey(DateTime.Now);
        scope.Code = appError.Code ?? ExceptionHasher.Generate(appError.Title ?? String.Empty);
        scope.NormalizedRequestPath = appError.NormalizedRequestPath ?? RouteNormalizer.NormalizeURLPath(appError.RequestPath);

        return scope;
    }
}
