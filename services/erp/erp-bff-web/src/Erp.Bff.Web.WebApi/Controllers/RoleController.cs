using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class RoleController : ControllerBase
{
    private readonly IRoleApi _roleApi;

    public RoleController(IRoleApi roleApi)
    {
        _roleApi = roleApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<RoleBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] RoleGetListQuery query)
        => Ok(await _roleApi.GetListAsync(query));


    [HttpGet()]
    [ProducesResponseType(typeof(RoleDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _roleApi.GetAsync());

    [HttpGet()]
    [ProducesResponseType(typeof(RoleDto), 200)]
    public async Task<IActionResult> GetAsSelectListAsync(int? appId)
       => Ok(await _roleApi.GetAsSelectList(appId));

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RoleDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _roleApi.GetByIdAsync(id));

    //[HttpGet]
    //public async Task<IActionResult> GetAsSelectListAsync()
    //=> Ok(await _roleApi.GetAsSelectListAsync());

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] RoleCreateCommand command)
        => Ok(await _roleApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] RoleUpdateCommand command)
        => Ok(await _roleApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _roleApi.DeleteAsync(id));

    [HttpPost]
    [ProducesResponseType(typeof(FileResult), 200)]
    public async Task<IActionResult> PrintAsExcelAsync([FromBody] RolePrintAsExcelCommand query)
    {
        var fileBytes = await _roleApi.PrintAsExcelAsync(query);

        return File(fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Rollar{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
    }
    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _roleApi.GetSecurityInfo());
}
