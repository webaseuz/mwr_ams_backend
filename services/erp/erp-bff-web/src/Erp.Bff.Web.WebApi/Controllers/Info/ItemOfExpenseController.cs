using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[ApiController]
[Route("[controller]/[action]")]
public class ItemOfExpenseController : ControllerBase
{
    private readonly IItemOfExpenseApi _itemOfExpenseApi;

    public ItemOfExpenseController(IItemOfExpenseApi ItemOfExpenseApi)
    {
        _itemOfExpenseApi = ItemOfExpenseApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<ItemOfExpenseBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] ItemOfExpenseGetListQuery query)
    => Ok(await _itemOfExpenseApi.GetListAsync(query));


    [HttpGet]
    [ProducesResponseType(typeof(ItemOfExpenseDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _itemOfExpenseApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ItemOfExpenseDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _itemOfExpenseApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, ItemOfExpenseSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _itemOfExpenseApi.GetAsSelectList());

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] ItemOfExpenseCreateCommand command)
        => Ok(await _itemOfExpenseApi.CreateAsync(command));


    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] ItemOfExpenseUpdateCommand command)
        => Ok(await _itemOfExpenseApi.UpdateAsync(command));


    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _itemOfExpenseApi.DeleteAsync(id));

    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _itemOfExpenseApi.GetSecurityInfo());
}
