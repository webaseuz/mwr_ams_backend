using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[ApiController]
[Route("[controller]/[action]")]
public class CalculationKindController : ControllerBase
{
    private readonly ICalculationKindApi _calculationKindApi;

    public CalculationKindController(ICalculationKindApi CalculationKindApi)
    {
        _calculationKindApi = CalculationKindApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<CalculationKindBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] CalculationKindGetListQuery query)
    => Ok(await _calculationKindApi.GetListAsync(query));


    [HttpGet]
    [ProducesResponseType(typeof(CalculationKindDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _calculationKindApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CalculationKindDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _calculationKindApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, CalculationKindSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _calculationKindApi.GetAsSelectListAsync());

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] CalculationKindCreateCommand command)
        => Ok(await _calculationKindApi.CreateAsync(command));


    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] CalculationKindUpdateCommand command)
        => Ok(await _calculationKindApi.UpdateAsync(command));


    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _calculationKindApi.DeleteAsync(id));

    #endregion


    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
        => Ok(await _calculationKindApi.GetSecurityInfo());
}
