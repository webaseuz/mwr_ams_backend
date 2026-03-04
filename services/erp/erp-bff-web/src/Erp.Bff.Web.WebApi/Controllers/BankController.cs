using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class BankController : ControllerBase
{
    private readonly IBankApi _bankApi;

    public BankController(IBankApi bankApi)
    {
        _bankApi = bankApi;
    }

    #region GETS
    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<BankBriefDto>), 200)]
    public async Task<IActionResult> GetList([FromBody] BankGetListQuery query)
        => Ok(await _bankApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(BankDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _bankApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BankDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _bankApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
       => Ok(await _bankApi.GetAsSelectListAsync());

    #endregion

    #region POSTS
    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] BankCreateCommand command)
        => Ok(await _bankApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] BankUpdateCommand command)
        => Ok(await _bankApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(await _bankApi.DeleteAsync(id));
    }

    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _bankApi.GetSecurityInfo());
}
