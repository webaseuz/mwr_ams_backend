using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

public interface ICalculationKindApi
{
    [Post("/CalculationKind/GetList")]
    Task<WbPagedResult<CalculationKindBriefDto>> GetListAsync([Body] CalculationKindGetListQuery query);

    [Post("/CalculationKind/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] CalculationKindCreateCommand command);

    [Post("/CalculationKind/Update")]
    Task<bool> UpdateAsync([Body] CalculationKindUpdateCommand command);

    [Post("/CalculationKind/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/CalculationKind/Get")]
    Task<CalculationKindDto> GetAsync();

    [Post("/CalculationKind/Get/{id}")]
    Task<CalculationKindDto> GetByIdAsync(int id);

    [Post("/CalculationKind/GetAsSelectList")]
    Task<WbSelectList<int, CalculationKindSelectListDto>> GetAsSelectListAsync();
}
