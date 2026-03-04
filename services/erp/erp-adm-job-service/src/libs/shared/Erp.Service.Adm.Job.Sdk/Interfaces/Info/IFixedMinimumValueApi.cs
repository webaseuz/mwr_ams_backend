using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

public interface IFixedMinimumValueApi
{
    /// <summary>
    /// Get a paginated list of pFixed Minimum Value
    /// </summary>
    [Post("/FixedMinimumValue/GetList")]
    Task<WbPagedResult<FixedMinimumValueBriefDto>> GetListAsync([Body] FixedMinimumValueGetListQuery query);

    /// <summary>
    /// Get Fixed Minimum Value by query parameters
    /// </summary>
    [Get("/FixedMinimumValue/Get")]
    Task<FixedMinimumValueDto> GetAsync();

    /// <summary>
    /// Get a Fixed Minimum Value by ID
    /// </summary>
    [Get("/FixedMinimumValue/Get/{id}")]
    Task<FixedMinimumValueDto> GetAsync(int id);

    /// <summary>
    /// Get Fixed Minimum Value as select list
    /// </summary>
    [Get("/FixedMinimumValue/GetAsSelectList")]
    Task<WbSelectList<int, FixedMinimumValueSelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Create a new Fixed Minimum Value
    /// </summary>
    [Post("/FixedMinimumValue/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] FixedMinimumValueCreateCommand command);

    /// <summary>
    /// Update an existing Fixed Minimum Value
    /// </summary>
    [Post("/FixedMinimumValue/Update")]
    Task<int> UpdateAsync([Body] FixedMinimumValueUpdateCommand command);

    /// <summary>
    /// Delete Fixed Minimum Value by ID
    /// </summary>
    [Post("/FixedMinimumValue/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/FixedMinimumValue/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
