using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class SpecialtyController : ControllerBase
{
    private readonly ISpecialtyApi _specialtyApi;

    public SpecialtyController(ISpecialtyApi specialtyApi)
    {
        _specialtyApi = specialtyApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<SpecialtyDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] SpecialtyGetListQuery query)
        => Ok(await _specialtyApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(SpecialtyDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _specialtyApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SpecialtyDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _specialtyApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, SpecialtySelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _specialtyApi.GetAsSelectListAsync());

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] SpecialtyCreateCommand command)
        => Ok(await _specialtyApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] SpecialtyUpdateCommand command)
        => Ok(await _specialtyApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _specialtyApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _specialtyApi.GetSecurityInfo());
    #endregion
}
