using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class TableController : ControllerBase
{
    private readonly ITableApi _tableApi;

    public TableController(ITableApi tableApi)
    {
        _tableApi = tableApi;
    }

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<TableBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] TableGetListQuery query)
        => Ok(await _tableApi.GetListAsync(query));

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TableDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _tableApi.GetByIdAsync(id));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] TableUpdateCommand command)
        => Ok(await _tableApi.UpdateAsync(command));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _tableApi.GetSecurityInfo());
}
