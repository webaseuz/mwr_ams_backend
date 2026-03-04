using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationApi _organizationApi;

    public OrganizationController(IOrganizationApi organizationApi)
    {
        _organizationApi = organizationApi;
    }

    [HttpPost]
    [ProducesResponseType(typeof(WbPagedResult<OrganizationBriefDto>), 200)]
    public async Task<IActionResult> GetListAsync([FromBody] OrganizationGetListQuery query)
        => Ok(await _organizationApi.GetListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, OrganizationSelectListDto>), 200)]
    public async Task<IActionResult> GetAsync()
        => Ok(await _organizationApi.GetAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrganizationDto), 200)]
    public async Task<IActionResult> GetByIdAsync(int id)
       => Ok(await _organizationApi.GetByIdAsync(id));

    [HttpPost]
    [ProducesResponseType(typeof(WbSelectList<int, OrganizationSelectListDto>), 200)]
    public async Task<IActionResult> GetAsSelectListAsync([FromBody] OrganizationSelectListQuery query)
        => Ok(await _organizationApi.GetAsSelectListAsync(query));

    [HttpPost]
    [ProducesResponseType(typeof(WbHaveId<int>), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] OrganizationCreateCommand command)
       => Ok(await _organizationApi.CreateAsync(command));

    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> UpdateAsync([FromBody] OrganizationUpdateCommand command)
        => Ok(await _organizationApi.UpdateAsync(command));

    [HttpPost("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _organizationApi.DeleteAsync(id));

    [HttpGet("{inn}")]
    [ProducesResponseType(typeof(OrganizationDto), 200)]
    public async Task<IActionResult> GetByInnAsync(string inn)
   => Ok(await _organizationApi.GetByInnAsync(inn));


    [HttpPost]
    [ProducesResponseType(typeof(FileResult), 200)]
    public async Task<IActionResult> PrintAsExcelAsync([FromBody] OrganizationPrintAsExcelCommand query)
    {
        var fileStream = await _organizationApi.PrintAsExcelAsync(query);

        return File(fileStream,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Tashkilotlar_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetSecurityInfo()
       => Ok(await _organizationApi.GetSecurityInfo());
}


