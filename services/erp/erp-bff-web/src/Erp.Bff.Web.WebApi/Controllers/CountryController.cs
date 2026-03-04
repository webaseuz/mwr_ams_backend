using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class CountryController : ControllerBase
{
    private readonly ICountryApi _countryApi;

    public CountryController(ICountryApi countryApi)
    {
        _countryApi = countryApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<CountryBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] CountryGetListQuery query)
        => Ok(await _countryApi.GetListAsync(query));

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CountryDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _countryApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(CountryDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _countryApi.GetAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, CountrySelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync()
        => Ok(await _countryApi.GetAsSelectListAsync());

    #endregion

    #region POSTS
    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] CountryCreateCommand command)
        => Ok(await _countryApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] CountryUpdateCommand command)
        => Ok(await _countryApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _countryApi.DeleteAsync(id));

    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _countryApi.GetSecurityInfo());
}
