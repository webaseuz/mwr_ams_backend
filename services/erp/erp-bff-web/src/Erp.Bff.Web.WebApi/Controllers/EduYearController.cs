using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class EduYearController : ControllerBase
{
    private readonly IEduYearApi _eduYearApi;

    public EduYearController(IEduYearApi eduYearApi)
    {
        _eduYearApi = eduYearApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<EduYearBriefDto>), 200)]
    public async Task<IActionResult> GetList([FromBody] EduYearGetListQuery query)
        => Ok(await _eduYearApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(EduYearDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _eduYearApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EduYearDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _eduYearApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, EduYearSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectList()
        => Ok(await _eduYearApi.GetAsSelectListAsync());

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> Create([FromBody] EduYearCreateCommand command)
        => Ok(await _eduYearApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Update([FromBody] EduYearUpdateCommand command)
        => Ok(await _eduYearApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Delete(int id)
      => Ok(await _eduYearApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _eduYearApi.GetSecurityInfo());
    #endregion

}
