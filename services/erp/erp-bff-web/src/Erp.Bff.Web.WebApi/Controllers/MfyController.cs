using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class MfyController : ControllerBase
{
    private readonly IMfyApi _mfyApi;

    public MfyController(IMfyApi mfyApi)
    {
        _mfyApi = mfyApi;
    }

    #region GETS    
    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<MfyBriefDto>), 200)]
    public async Task<IActionResult> GetList([FromBody] MfyGetListQuery query)
        => Ok(await _mfyApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(MfyDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _mfyApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MfyDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _mfyApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, MfySelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectList()
        => Ok(await _mfyApi.GetAsSelectListAsync());

    #endregion

    #region POST
    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> Create([FromBody] MfyCreateCommand command)
        => Ok(await _mfyApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Update([FromBody] MfyUpdateCommand command)
        => Ok(await _mfyApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mfyApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _mfyApi.GetSecurityInfo());
    #endregion
}
