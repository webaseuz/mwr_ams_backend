using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// User API client interface
/// </summary>
public interface IUserApi
{
    /// <summary>
    /// Get list of users
    /// </summary>
    [Post("/User/GetList")]
    Task<WbPagedResult<UserBriefDto>> GetListAsync([Body] UserGetListQuery query);

    /// <summary>
    /// Create a new user
    /// </summary>
    [Post("/User/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] UserCreateCommand command);

    /// <summary>
    /// Create a new user
    /// </summary>
    [Post("/User/SyncUserWithEmployee")]
    Task<bool> SyncUserWithEmployeeAsync([Body] SyncUserWithEmployeeCommand command);

    [Post("/User/Attach")]
    Task<bool> AttachAsync([Body] UserAttachCommand command);

    [Post("/User/Update")]
    Task<bool> UpdateAsync([Body] UserUpdateCommand command);

    [Post("/User/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/User/Get")]
    Task<UserBriefDto> GetAsync();

    [Post("/User/Get/{id}")]
    Task<UserBriefDto> GetByIdAsync(int id);

    [Post("/User/PrintAsExcel")]
    Task<byte[]> PrintAsExcelAsync([Body] UserPrintAsExcelCommand query);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/User/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
