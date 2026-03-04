using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[Route("[controller]/[action]")]
[ApiController]
public class FixedMinimumValueController : ControllerBase
{
    private readonly IFixedMinimumValueApi _FixedMinimumValueApi;

    public FixedMinimumValueController(IFixedMinimumValueApi FixedMinimumValueApi)
    {
        _FixedMinimumValueApi = FixedMinimumValueApi;
    }

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<FixedMinimumValueBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] FixedMinimumValueGetListQuery query)
        => Ok(await _FixedMinimumValueApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(FixedMinimumValueDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _FixedMinimumValueApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FixedMinimumValueDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _FixedMinimumValueApi.GetAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, FixedMinimumValueSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _FixedMinimumValueApi.GetAsSelectListAsync());

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] FixedMinimumValueCreateCommand command)
        => Ok(await _FixedMinimumValueApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] FixedMinimumValueUpdateCommand command)
        => Ok(await _FixedMinimumValueApi.UpdateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _FixedMinimumValueApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _FixedMinimumValueApi.GetSecurityInfo());
}
