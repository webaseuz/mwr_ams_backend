using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[ApiController]
[Route("[controller]/[action]")]
public class NationalityController : ControllerBase
{
    private readonly INationalityApi _nationalityApi;

    public NationalityController(INationalityApi nationalityApi)
    {
        _nationalityApi = nationalityApi;
    }

    #region GETS

    [HttpPost]
    public async Task<IActionResult> GetListAsync([FromBody] NationalityGetListQuery query)
        => Ok(await _nationalityApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(NationalityDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _nationalityApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(NationalityDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _nationalityApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, NationalitySelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _nationalityApi.GetAsSelectListAsync());

    #endregion

    #region POSTS
    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] NationalityCreateCommand command)
    => Ok(await _nationalityApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] NationalityUpdateCommand command)
        => Ok(await _nationalityApi.UpdateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
    => Ok(await _nationalityApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _nationalityApi.GetSecurityInfo());
    #endregion
}
