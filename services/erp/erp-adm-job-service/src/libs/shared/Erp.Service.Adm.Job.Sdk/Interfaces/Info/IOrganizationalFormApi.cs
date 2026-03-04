using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IOrganizationalFormApi
{
    [Post("/OrganizationalForm/Create")]
    Task<int> CreateAsync([Body] OrganizationalFormCreateCommand command);

    [Post("/OrganizationalForm/Update")]
    Task<bool> UpdateAsync([Body] OrganizationalFormUpdateCommand command);

    [Post("/OrganizationalForm/Get")]
    Task<OrganizationFormDto> GetByIdAsync([Body] OrganizationalFormGetByIdQuery query);

    [Post("/OrganizationalForm/GetList")]
    Task<WbPagedResult<OrganizationFormBriefDto>> GetListAsync([Body] OrganizationalFormGetListQuery query);

    [Post("/OrganizationalForm/GetAsSelectList")]
    Task<WbSelectList<int, OrganizationFormSelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/OrganizationalForm/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}

