using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IOkedApi
{
    [Post("/Oked/GetList")]
    Task<WbPagedResult<OkedBriefDto>> GetListAsync([Body] OkedGetListQuery query);

    [Post("/Oked/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] OkedCreateCommand command);

    [Post("/Oked/Update")]
    Task<bool> UpdateAsync([Body] OkedUpdateCommand command);

    [Post("/Oked/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Oked/Get")]
    Task<OkedDto> GetAsync();

    [Post("/Oked/Get/{id}")]
    Task<OkedDto> GetByIdAsync(int id);

    [Post("/Oked/GetAsSelectList")]
    Task<WbSelectList<int>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Oked/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
