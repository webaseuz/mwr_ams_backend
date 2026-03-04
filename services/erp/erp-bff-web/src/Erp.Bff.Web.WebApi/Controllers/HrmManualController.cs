using Erp.Service.Hrm.Models;
using Erp.Service.Hrm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class HrmManualController : ControllerBase
{
    private readonly IPositionApi _positionApi;
    private readonly IDepartmentApi _departmentApi;
    public HrmManualController(IPositionApi positionApi, IDepartmentApi departmentApi)
    {
        _positionApi = positionApi;
        _departmentApi = departmentApi;
    }

    //[HttpGet]
    //[ProducesResponseType(typeof(WbSelectList<int>), 200)]
    //public async Task<IActionResult> PositionSelectListAsync()
    //    => Ok(await _positionApi.GetAsSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> PositionSelectListAsync([FromQuery] PositionByOrgStructureSelectListQuery query)
        => Ok(await _positionApi.GetByOrgStructureAsSelectListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> DepartmentSelectListAsync([FromQuery] DepartmentByOrgStructureSelectListQuery query)
        => Ok(await _departmentApi.GetByOrgStructureAsSelectListAsync(query));
}
