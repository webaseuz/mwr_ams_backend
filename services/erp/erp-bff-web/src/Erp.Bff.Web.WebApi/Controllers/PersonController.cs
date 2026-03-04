using Erp.Core.Models;
using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class PersonController : ControllerBase
{
    private readonly IPersonApi _personApi;

    public PersonController(IPersonApi personApi)
    {
        _personApi = personApi;
    }

    #region GETS


    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<PersonBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] PersonGetListQuery query)
        => Ok(await _personApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(PersonDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _personApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PersonDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _personApi.GetByIdAsync(id));

    #endregion

    #region POSTS

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] PersonCreateCommand command)
       => Ok(await _personApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] PersonUpdateCommand command)
        => Ok(await _personApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
    => Ok(await _personApi.DeleteAsync(id));

    [HttpPost]
    [ProducesResponseType(typeof(PersonDto), 200)]
    public async Task<IActionResult> PersonGetByPassportDataAsync([FromBody] PersonGetByPassportDataQuery query)
        => Ok(await _personApi.PersonGetByPassportDataAsync(query));

    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> PersonGetPhotoFromGSPAsync([FromBody] PersonGetPhotoFromGSPQuery query)
        => Ok(await _personApi.PersonGetPhotoFromGSPAsync(query));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> PersonSyncAsync([FromBody] PersonSyncQuery query)
        => Ok(await _personApi.PersonSyncAsync(query));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _personApi.GetSecurityInfo());

    #endregion
}
