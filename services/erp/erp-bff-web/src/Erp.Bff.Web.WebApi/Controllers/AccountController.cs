using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
namespace Erp.Adm.Bff.Web.WebApi;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class AccountController : ControllerBase
{
    private readonly IAccountApi _accountApi;

    public AccountController(IAccountApi accountApi)
    {
        _accountApi = accountApi;
    }

    [HttpPost]
    public async Task<IActionResult> GetAuthInfoAsync()
    {
        var result = await _accountApi.GetAuthInfoAsync();
        return Ok(result);
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
    {
        return Ok(await _accountApi.GetSecurityInfo());
    }
}
