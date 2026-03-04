using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface ICountryApi
{
    [Post("/Country/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] CountryCreateCommand command);

    [Post("/Country/Update")]
    Task<bool> UpdateAsync([Body] CountryUpdateCommand command);

    [Post("/Country/GetList")]
    Task<WbPagedResult<CountryBriefDto>> GetListAsync([Body] CountryGetListQuery query);

    [Post("/Country/Get")]
    Task<CountryDto> GetAsync();

    [Post("/Country/Get/{id}")]
    Task<CountryDto> GetByIdAsync(int id);

    [Post("/Country/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Country/GetAsSelectList")]
    Task<WbSelectList<int, CountrySelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Country/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}

