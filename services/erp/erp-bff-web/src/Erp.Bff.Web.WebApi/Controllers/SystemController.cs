using Microsoft.AspNetCore.Mvc;
using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class SystemController : ControllerBase
{
    private readonly ISystemApi _systemApi;
    public SystemController(ISystemApi systemApi)
    {
        _systemApi = systemApi;
    }

    [HttpPost]
    public async Task<IActionResult> UserHasAnyPermission([FromBody] UserHasAnyPermissionQuery query)
        => Ok(await _systemApi.UserHasAnyPermissionAsync(query));
} 
