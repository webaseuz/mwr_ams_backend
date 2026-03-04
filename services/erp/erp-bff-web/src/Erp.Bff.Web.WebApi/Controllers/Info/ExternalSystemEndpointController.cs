using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[ApiController]
[Route("[controller]/[action]")]
public class ExternalSystemEndpointController : ControllerBase
{
    private readonly IExternalSystemEndpointApi _externalSystemEndpointApi;

    public ExternalSystemEndpointController(IExternalSystemEndpointApi ExternalSystemEndpointApi)
    {
        _externalSystemEndpointApi = ExternalSystemEndpointApi;
    }

    #region GETS

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<ExternalSystemEndpointBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] ExternalSystemEndpointGetListQuery query)
    => Ok(await _externalSystemEndpointApi.GetListAsync(query));

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ExternalSystemEndpointDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _externalSystemEndpointApi.GetByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(ExternalSystemEndpointDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _externalSystemEndpointApi.GetAsync());

    //[HttpGet]
    //[ProducesResponseType(typeof(WbSelectList<int, ExternalSystemEndpointSelectListDto>), 200)]
    //public async Task<IActionResult> GetAsSelectListAsync()
    //    => Ok(await _externalSystemEndpointApi.GetAsSelectList());

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] ExternalSystemEndpointCreateCommand command)
        => Ok(await _externalSystemEndpointApi.CreateAsync(command));


    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] ExternalSystemEndpointUpdateCommand command)
        => Ok(await _externalSystemEndpointApi.UpdateAsync(command));


    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _externalSystemEndpointApi.DeleteAsync(id));

    #endregion

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _externalSystemEndpointApi.GetSecurityInfo());
}
