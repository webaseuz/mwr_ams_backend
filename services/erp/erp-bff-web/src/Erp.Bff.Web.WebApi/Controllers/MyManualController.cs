using Erp.Service.My.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class MyManualController : ControllerBase
{
    private readonly IManualApi _manualApi;
    public MyManualController(IManualApi manualApi)
    {
        _manualApi = manualApi;
    }

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> ApplicationTypeSelectListAsync()
        => Ok(await _manualApi.ApplicationTypeSelectListAsync());
}
