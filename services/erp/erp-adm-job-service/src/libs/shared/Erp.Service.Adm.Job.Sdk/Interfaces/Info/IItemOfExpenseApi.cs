using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

public interface IItemOfExpenseApi
{
    [Post("/ItemOfExpense/GetList")]
    Task<WbPagedResult<ItemOfExpenseBriefDto>> GetListAsync([Body] ItemOfExpenseGetListQuery query);

    [Post("/ItemOfExpense/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] ItemOfExpenseCreateCommand command);

    [Post("/ItemOfExpense/Update")]
    Task<bool> UpdateAsync([Body] ItemOfExpenseUpdateCommand command);

    [Post("/ItemOfExpense/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/ItemOfExpense/Get")]
    Task<ItemOfExpenseDto> GetAsync();

    [Post("/ItemOfExpense/Get/{id}")]
    Task<ItemOfExpenseDto> GetByIdAsync(int id);

    [Post("/ItemOfExpense/GetAsSelectList")]
    Task<WbSelectList<int, ItemOfExpenseSelectListDto>> GetAsSelectList();
}
