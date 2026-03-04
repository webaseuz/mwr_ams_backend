using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface ITableApi
{
    /// <summary>
    /// Get list of file confige
    /// </summary>
    [Post("/Table/GetList")]
    Task<WbPagedResult<TableBriefDto>> GetListAsync([Body] TableGetListQuery query);

    /// <summary>
    /// Update an existing File Config
    /// </summary>
    [Post("/Table/Update")]
    Task<bool> UpdateAsync([Body] TableUpdateCommand command);

    /// <summary>
    /// Get File Config by Id
    /// </summary>
    [Post("/Table/Get/{id}")]
    Task<TableDto> GetByIdAsync(int id);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Table/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
