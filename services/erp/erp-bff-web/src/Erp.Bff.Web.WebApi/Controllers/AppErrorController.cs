using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class AppErrorController : ControllerBase
{
    private readonly IAppErrorApi _appArrorApi;

    public AppErrorController(IAppErrorApi appErrorApi)
    {
        _appArrorApi = appErrorApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<ErrorScopeListDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] ErrorScopeSortFilterPageOption query)
        => Ok(await _appArrorApi.GetListAsync(query));

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<ErrorListDto>), 200)]
    public async Task<IActionResult> ItemsListAsync([FromBody] ErrorSortFilterPageOption query)
        => Ok(await _appArrorApi.ItemsListAsync(query));

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AppDto), 200)]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(await _appArrorApi.GetAsync(id));

    [HttpGet("{itemId}")]
    [ProducesResponseType(typeof(ErrorDto), 200)]
    public async Task<IActionResult> ItemsAsync(long itemId)
        => Ok(await _appArrorApi.ItemsAsync(itemId));

    #endregion

    #region POSTS

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Fix(long id)
    {
        var response = await _appArrorApi.FixAsync(id);
        return Ok(response.IsSuccessStatusCode);
    }

    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _appArrorApi.GetSecurityInfo());
}
