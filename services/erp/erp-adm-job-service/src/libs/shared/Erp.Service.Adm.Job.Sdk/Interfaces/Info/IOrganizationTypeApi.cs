using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IOrganizationTypeApi
{
    [Post("/OrganizationType/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] CreateOrganizationTypeCommand command);

    [Post("/OrganizationType/Update")]
    Task<bool> UpdateAsync([Body] OrganizationTypeUpdateCommand command);

    [Post("/OrganizationType/GetList")]
    Task<WbPagedResult<OrganizationTypeBriefDto>> GetListAsync([Body] OrganizationTypeGetListQuery query);

    [Post("/OrganizationType/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/OrganizationType/Get")]
    Task<OrganizationTypeDto> GetAsync();

    [Post("/OrganizationType/Get/{id}")]
    Task<OrganizationTypeDto> GetByIdAsync(int id);

    [Post("/OrganizationType/GetAsSelectList")]
    Task<WbSelectList<int, OrganizationTypeSelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/OrganizationType/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
