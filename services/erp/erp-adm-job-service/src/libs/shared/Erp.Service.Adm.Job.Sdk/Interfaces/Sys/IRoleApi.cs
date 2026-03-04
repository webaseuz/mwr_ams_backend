using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// Role API client interface
/// </summary>
public interface IRoleApi
{
    /// <summary>
    /// Get list of roles
    /// </summary>
    [Post("/Role/GetList")]
    Task<WbPagedResult<RoleBriefDto>> GetListAsync([Body] RoleGetListQuery query);

    /// <summary>
    /// Create a new role
    /// </summary>
    [Post("/Role/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] RoleCreateCommand command);

    /// <summary>
    /// Update an existing role
    /// </summary>
    [Post("/Role/Update")]
    Task<bool> UpdateAsync([Body] RoleUpdateCommand command);


    [Post("/Role/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Role/Get")]
    Task<RoleDto> GetAsync();

    [Post("/Role/Get/{id}")]
    Task<RoleDto> GetByIdAsync(int id);

    [Post("/Role/GetAsSelectList")]
    Task<List<RoleSelectListDto>> GetAsSelectList(int? appId);

    [Post("/Role/PrintAsExcel")]
    Task<byte[]> PrintAsExcelAsync([Body] RolePrintAsExcelCommand query);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Role/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
