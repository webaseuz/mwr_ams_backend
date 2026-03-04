using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class AppController : ControllerBase
{
    private readonly IAppApi _appApi;

    public AppController(IAppApi appApi)
    {
        _appApi = appApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<AppBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] AppGetListQuery query)
        => Ok(await _appApi.GetListAsync(query));

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AppDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _appApi.GetByIdAsync(id));

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] AppUpdateCommand command)
        => Ok(await _appApi.UpdateAsync(command));

    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _appApi.GetSecurityInfo());

}
