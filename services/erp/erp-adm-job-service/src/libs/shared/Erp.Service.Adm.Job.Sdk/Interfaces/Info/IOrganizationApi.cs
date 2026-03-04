using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IOrganizationApi
{
    [Post("/Organization/GetList")]
    Task<WbPagedResult<OrganizationBriefDto>> GetListAsync([Body] OrganizationGetListQuery query);

    [Post("/Organization/Get")]
    Task<OrganizationDto> GetAsync();

    [Post("/Organization/GetById/{id}")]
    Task<OrganizationDto> GetByIdAsync(int id);

    [Post("/Organization/GetAsSelectList")]
    Task<WbSelectList<int>> GetAsSelectListAsync([Body] OrganizationSelectListQuery query);

    [Post("/Organization/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] OrganizationCreateCommand command);

    [Post("/Organization/Update")]
    Task<bool> UpdateAsync([Body] OrganizationUpdateCommand command);

    [Post("/Organization/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Organization/GetByInn/{inn}")]
    Task<OrganizationDto> GetByInnAsync(string inn);

    [Post("/Organization/PrintAsExcel")]
    Task<Stream> PrintAsExcelAsync([Body] OrganizationPrintAsExcelCommand query);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Organization/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
