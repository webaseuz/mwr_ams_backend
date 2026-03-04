using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class RegionController : ControllerBase
{
    private readonly IRegionApi _regionApi;

    public RegionController(IRegionApi regionApi)
    {
        _regionApi = regionApi;
    }

    #region POSTS
    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> Create([FromBody] RegionCreateCommand command)
        => Ok(await _regionApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Update([FromBody] RegionUpdateCommand command)
        => Ok(await _regionApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _regionApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _regionApi.GetSecurityInfo());
    #endregion

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<RegionDto>), 200)]
    public async Task<IActionResult> GetList([FromBody] RegionGetListQuery query)
        => Ok(await _regionApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(RegionDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _regionApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RegionDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _regionApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, RegionSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectList()
        => Ok(await _regionApi.GetAsSelectListAsync());

    #endregion
}
