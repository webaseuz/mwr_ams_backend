using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class OrganizationTypeController : ControllerBase
{
    private readonly IOrganizationTypeApi _organizationTypeApi;

    public OrganizationTypeController(IOrganizationTypeApi organizationTypeApi)
    {
        _organizationTypeApi = organizationTypeApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<OrganizationTypeBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] OrganizationTypeGetListQuery query)
        => Ok(await _organizationTypeApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(OrganizationTypeDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _organizationTypeApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrganizationTypeDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
   => Ok(await _organizationTypeApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, OrganizationTypeSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _organizationTypeApi.GetAsSelectListAsync());

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateOrganizationTypeCommand command)
        => Ok(await _organizationTypeApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] OrganizationTypeUpdateCommand command)
        => Ok(await _organizationTypeApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _organizationTypeApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _organizationTypeApi.GetSecurityInfo());
    #endregion
}
