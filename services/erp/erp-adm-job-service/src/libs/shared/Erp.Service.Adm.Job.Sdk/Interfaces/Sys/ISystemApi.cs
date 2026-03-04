using Erp.Service.Adm.Job.Models;
using Refit;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// System API client interface
/// </summary>
public interface ISystemApi
{
    /// <summary>
    /// Check if user has any of the specified permissions
    /// </summary>
    [Post("/System/UserHasAnyPermission")]
    Task<bool> UserHasAnyPermissionAsync([Body] UserHasAnyPermissionQuery query);

}
