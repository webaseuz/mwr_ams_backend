using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// District API client interface
/// </summary>
public interface IDistrictApi
{
    [Post("/District/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] DistrictCreateCommand command);

    [Post("/District/Update")]
    Task<bool> UpdateAsync([Body] DistrictUpdateCommand command);

    [Post("/District/Get")]
    Task<DistrictDto> GetByQueryAsync([Body] DistrictGetByIdQuery query);

    [Post("/District/GetList")]
    Task<WbPagedResult<DistrictDto>> GetListAsync([Body] DistrictGetListQuery query);

    [Post("/District/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/District/Get")]
    Task<DistrictDto> GetAsync();

    [Post("/District/Get/{id}")]
    Task<DistrictDto> GetByIdAsync(int id);

    [Post("/District/GetAsSelectList")]
    Task<WbSelectList<int, DistrictSelectListDto>> GetAsSelectListAsync([Body] DistrictSelectListQuery query);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/District/GetSecurityInfo")]
    Task<object> GetSecurityInfo();

}
