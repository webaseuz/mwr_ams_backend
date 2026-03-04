using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class OkedController : ControllerBase
{
    private readonly IOkedApi _okedApi;

    public OkedController(IOkedApi okedApi)
    {
        _okedApi = okedApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<OkedBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] OkedGetListQuery query)
    => Ok(await _okedApi.GetListAsync(query));


    [HttpGet]
    [ProducesResponseType(typeof(OkedDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _okedApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OkedDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _okedApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _okedApi.GetAsSelectListAsync());

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] OkedCreateCommand command)
        => Ok(await _okedApi.CreateAsync(command));


    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] OkedUpdateCommand command)
        => Ok(await _okedApi.UpdateAsync(command));


    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _okedApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _okedApi.GetSecurityInfo());
    #endregion

}
