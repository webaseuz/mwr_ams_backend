using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IInstitutionTypeApi
{
    [Post("/InstitutionType/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] InstitutionTypeCreateCommand command);

    [Post("/InstitutionType/Update")]
    Task<bool> UpdateAsync([Body] InstitutionTypeUpdateCommand command);

    [Post("/InstitutionType/GetList")]
    Task<WbPagedResult<InstitutionTypeBriefDto>> GetListAsync([Body] InstitutionTypeGetListQuery query);

    [Post("/InstitutionType/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/InstitutionType/Get")]
    Task<InstitutionTypeDto> GetAsync();

    [Post("/InstitutionType/Get/{id}")]
    Task<InstitutionTypeDto> GetByIdAsync(int id);

    [Post("/InstitutionType/GetAsSelectList")]
    Task<WbSelectList<int>> GetAsSelectListAsync([Body] InstitutionTypeSelectListQuery query);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/InstitutionType/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}

