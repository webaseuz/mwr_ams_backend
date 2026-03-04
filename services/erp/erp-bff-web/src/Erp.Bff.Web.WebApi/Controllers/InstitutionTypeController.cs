using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class InstitutionTypeController : ControllerBase
{
    private readonly IInstitutionTypeApi _institutionTypeApi;

    public InstitutionTypeController(IInstitutionTypeApi institutionTypeApi)
    {
        _institutionTypeApi = institutionTypeApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<InstitutionTypeBriefDto>), 200)]
    public async Task<IActionResult> GetList([FromBody] InstitutionTypeGetListQuery query)
        => Ok(await _institutionTypeApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(InstitutionTypeDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _institutionTypeApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(InstitutionTypeDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _institutionTypeApi.GetByIdAsync(id));

    [HttpPost]
    [ProducesResponseType(typeof(WbSelectList<int, InstitutionTypeSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectList([FromBody] InstitutionTypeSelectListQuery query)
        => Ok(await _institutionTypeApi.GetAsSelectListAsync(query));

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] InstitutionTypeCreateCommand command)
    => Ok(await _institutionTypeApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] InstitutionTypeUpdateCommand command)
        => Ok(await _institutionTypeApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _institutionTypeApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _institutionTypeApi.GetSecurityInfo());
    #endregion
}
