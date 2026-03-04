using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IRegionApi
{
    [Post("/Region/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] RegionCreateCommand command);

    [Post("/Region/Update")]
    Task<bool> UpdateAsync([Body] RegionUpdateCommand command);

    [Post("/Region/GetList")]
    Task<WbPagedResult<RegionDto>> GetListAsync([Body] RegionGetListQuery query);

    [Post("/Region/SelectList")]
    Task<List<RegionSelectListDto>> SelectListAsync([Body] RegionSelectListQuery query);

    [Post("/Region/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Region/Get")]
    Task<RegionDto> GetAsync();

    [Post("/Region/Get/{id}")]
    Task<RegionDto> GetByIdAsync(int id);

    [Post("/Region/GetAsSelectList")]
    Task<WbSelectList<int, RegionSelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Region/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}

