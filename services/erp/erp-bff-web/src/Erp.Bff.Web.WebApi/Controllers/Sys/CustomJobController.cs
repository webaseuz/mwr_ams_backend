using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[Route("[controller]/[action]")]
[ApiController]
public class CustomJobController(ICustomJobApi api) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<CustomJobBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] CustomJobGetListQuery query)
        => Ok(await api.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(CustomJobDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await api.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomJobDto), 200)]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(await api.GetAsync(id));

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<long>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] CustomJobCreateCommand command)
        => Ok(await api.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] CustomJobUpdateCommand command)
        => Ok(await api.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(await api.DeleteAsync(id));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> ApproveAsync([FromBody] CustomJobApproveCommand command)
        => Ok(await api.ApproveAsync(command));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await api.GetSecurityInfo());
}
