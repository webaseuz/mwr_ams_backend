using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class DistrictController : ControllerBase
{
    private readonly IDistrictApi _districtApi;

    public DistrictController(IDistrictApi districtApi)
    {
        _districtApi = districtApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<DistrictDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] DistrictGetListQuery query)
        => Ok(await _districtApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(DistrictDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _districtApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DistrictDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _districtApi.GetByIdAsync(id));


    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, DistrictSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync(DistrictSelectListQuery query)
        => Ok(await _districtApi.GetAsSelectListAsync(query));

    #endregion

    #region POSTS
    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] DistrictCreateCommand command)
        => Ok(await _districtApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] DistrictUpdateCommand command)
        => Ok(await _districtApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _districtApi.DeleteAsync(id));

    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _districtApi.GetSecurityInfo());
}
