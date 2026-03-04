using Erp.Service.Adm.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Sdk;
public interface IBankApi
{

    [Post("/Bank/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] BankCreateCommand command);

    [Post("/Bank/Update")]
    Task<bool> UpdateAsync([Body] BankUpdateCommand command);

    [Post("/Bank/GetList")]
    Task<WbPagedResult<BankBriefDto>> GetListAsync([Body] BankGetListQuery query);

    [Post("/Bank/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/Bank/Get")]
    Task<BankDto> GetAsync();

    [Post("/Bank/Get/{id}")]
    Task<BankDto> GetByIdAsync(int id);

    [Post("/Bank/GetAsSelectList")]
    Task<WbSelectList<int>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/Bank/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
