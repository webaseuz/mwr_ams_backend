using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IMfyApi
{
    [Post("/Mfy/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] MfyCreateCommand command);

    [Post("/Mfy/Update")]
    Task<bool> UpdateAsync([Body] MfyUpdateCommand command);

    [Post("/Mfy/GetList")]
    Task<WbPagedResult<MfyBriefDto>> GetListAsync([Body] MfyGetListQuery query);

    [Post("/Mfy/Get")]
    Task<MfyDto> GetByIdAsync([Body] MfyGetByIdQuery query);

    [Post("/Mfy/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Mfy/Get")]
    Task<MfyDto> GetAsync();

    [Post("/Mfy/Get/{id}")]
    Task<MfyDto> GetByIdAsync(int id);

    [Post("/Mfy/GetAsSelectList")]
    Task<WbSelectList<int, MfySelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Mfy/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
