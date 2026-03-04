using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface INationalityApi
{

    [Post("/Nationality/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] NationalityCreateCommand command);

    [Post("/Nationality/Update")]
    Task<bool> UpdateAsync([Body] NationalityUpdateCommand command);

    [Post("/Nationality/GetList")]
    Task<WbPagedResult<NationalityBriefDto>> GetListAsync([Body] NationalityGetListQuery query);

    [Post("/Nationality/Get")]
    Task<NationalityDto> GetByIdAsync([Body] NationalityGetByIdQuery query);

    [Post("/Nationality/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Nationality/Get")]
    Task<NationalityDto> GetAsync();

    [Post("/Nationality/Get/{id}")]
    Task<NationalityDto> GetByIdAsync(int id);

    [Post("/Nationality/GetAsSelectList")]
    Task<WbSelectList<int, NationalitySelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Nationality/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
