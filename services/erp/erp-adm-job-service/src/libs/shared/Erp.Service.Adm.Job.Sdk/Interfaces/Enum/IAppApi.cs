using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

public interface IAppApi
{
    [Post("/App/Update")]
    Task<bool> UpdateAsync([Body] AppUpdateCommand command);

    [Post("/App/GetList")]
    Task<WbPagedResult<AppBriefDto>> GetListAsync([Body] AppGetListQuery query);

    [Post("/App/Get/{id}")]
    Task<AppDto> GetByIdAsync(int id);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/App/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
