using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class EduDirectionController : ControllerBase
{
    private readonly IEduDirectionApi _eduDirectionApi;

    public EduDirectionController(IEduDirectionApi eduDirectionApi)
    {
        _eduDirectionApi = eduDirectionApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<EduDirectionDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] EduDirectionGetListQuery query)
        => Ok(await _eduDirectionApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(EduDirectionDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _eduDirectionApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EduDirectionDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _eduDirectionApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, EduDirectionSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync(int? stateId)
        => Ok(await _eduDirectionApi.GetAsSelectListAsync(new EduDirectionSelectListQuery { StateId = stateId }));

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] EduDirectionCreateCommand command)
        => Ok(await _eduDirectionApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] EduDirectionUpdateCommand command)
        => Ok(await _eduDirectionApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _eduDirectionApi.DeleteAsync(id));


    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _eduDirectionApi.GetSecurityInfo());
    #endregion
}
