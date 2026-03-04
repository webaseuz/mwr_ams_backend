using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// EduDirection API client interface
/// </summary>
public interface IEduDirectionApi
{
    [Post("/EduDirection/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] EduDirectionCreateCommand command);

    [Post("/EduDirection/Update")]
    Task<bool> UpdateAsync([Body] EduDirectionUpdateCommand command);

    [Post("/EduDirection/Get")]
    Task<EduDirectionDto> GetByQueryAsync([Body] EduDirectionGetByIdQuery query);

    [Post("/EduDirection/GetList")]
    Task<WbPagedResult<EduDirectionDto>> GetListAsync([Body] EduDirectionGetListQuery query);

    [Post("/EduDirection/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/EduDirection/Get")]
    Task<EduDirectionDto> GetAsync();

    [Post("/EduDirection/Get/{id}")]
    Task<EduDirectionDto> GetByIdAsync(int id);

    [Post("/EduDirection/GetAsSelectList")]
    Task<WbSelectList<int, EduDirectionSelectListDto>> GetAsSelectListAsync([Body] EduDirectionSelectListQuery query);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/EduDirection/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
