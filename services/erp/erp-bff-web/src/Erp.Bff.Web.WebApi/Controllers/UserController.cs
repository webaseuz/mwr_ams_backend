using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserApi _userApi;

    public UserController(IUserApi userApi)
    {
        _userApi = userApi;
    }

    #region GETS

    [HttpPost]
    public async Task<IActionResult> GetListAsync([FromBody] UserGetListQuery query)
        => Ok(await _userApi.GetListAsync(query));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _userApi.GetByIdAsync(id));

    #endregion

    #region POSTS

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserCreateCommand command)
        => Ok(await _userApi.CreateAsync(command));

    [HttpPost]
    public async Task<IActionResult> ExternalCreateAsync([FromBody] SyncUserWithEmployeeCommand command)
        => Ok(await _userApi.SyncUserWithEmployeeAsync(command));

    [HttpPost]
    public async Task<IActionResult> AttachAsync([FromBody] UserAttachCommand command)
        => Ok(await _userApi.AttachAsync(command));

    [HttpPost]
    public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateCommand command)
       => Ok(await _userApi.UpdateAsync(command));

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
      => Ok(await _userApi.DeleteAsync(id));

    [HttpPost]
    [ProducesResponseType(typeof(FileResult), 200)]
    public async Task<IActionResult> PrintAsExcelAsync([FromBody] UserPrintAsExcelCommand query)
    {
        var fileBytes = await _userApi.PrintAsExcelAsync(query);

        return File(fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Foydalanuvchilar_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
    }

    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _userApi.GetSecurityInfo());
}
