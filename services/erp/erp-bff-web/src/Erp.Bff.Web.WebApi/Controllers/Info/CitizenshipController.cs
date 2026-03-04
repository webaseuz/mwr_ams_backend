using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class CitizenshipController : ControllerBase
{
    private readonly ICitizenshipApi _CitizenshipApi;
    public CitizenshipController(ICitizenshipApi CitizenshipApi)
    {
        _CitizenshipApi = CitizenshipApi;
    }

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<CitizenshipBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] CitizenshipGetListQuery query)
        => Ok(await _CitizenshipApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, CitizenshipSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _CitizenshipApi.GetAsSelectListAsync());

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _CitizenshipApi.GetSecurityInfo());
}
