using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class DocumentStatusController : ControllerBase
{
    private readonly IDocumentStatusApi _documentStatusApi;

    public DocumentStatusController(IDocumentStatusApi documentStatusApi)
    {
        _documentStatusApi = documentStatusApi;
    }

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<DocumentStatusBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] DocumentStatusGetListQuery query)
        => Ok(await _documentStatusApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(DocumentStatusDto), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _documentStatusApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DocumentStatusDto), 200)]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(await _documentStatusApi.GetAsync(id));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync([FromQuery] DocumentStatusSelectListQuery query)
        => Ok(await _documentStatusApi.GetAsSelectListAsync(query));

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] DocumentStatusCreateCommand command)
        => Ok(await _documentStatusApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] DocumentStatusUpdateCommand command)
        => Ok(await _documentStatusApi.UpdateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _documentStatusApi.DeleteAsync(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _documentStatusApi.GetSecurityInfo());
}
