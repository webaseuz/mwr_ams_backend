using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
namespace Erp.Adm.Bff.Web.WebApi;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class OrganizationalFormController : ControllerBase
{
    private readonly IOrganizationalFormApi _organizationalFormApi;

    public OrganizationalFormController(IOrganizationalFormApi organizationalFormApi)
    {
        _organizationalFormApi = organizationalFormApi;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] OrganizationalFormCreateCommand command)
        => Ok(await _organizationalFormApi.CreateAsync(command));

    [HttpPost]
    public async Task<IActionResult> UpdateAsync([FromBody] OrganizationalFormUpdateCommand command)
        => Ok(await _organizationalFormApi.UpdateAsync(command));

    [HttpPost]
    public async Task<IActionResult> GetAsync([FromBody] OrganizationalFormGetByIdQuery query)
        => Ok(await _organizationalFormApi.GetByIdAsync(query));

    [HttpPost]
    public async Task<IActionResult> GetListAsync([FromBody] OrganizationalFormGetListQuery query)
        => Ok(await _organizationalFormApi.GetListAsync(query));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _organizationalFormApi.GetSecurityInfo());
}
