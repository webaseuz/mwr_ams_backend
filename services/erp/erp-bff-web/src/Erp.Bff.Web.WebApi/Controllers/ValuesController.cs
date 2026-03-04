using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Adm.Bff.Web.WebApi;

[Route("[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        WEBASE.Salary.Core.SalaryCalculationCore v = new WEBASE.Salary.Core.SalaryCalculationCore();
        return Ok(v.CalculationKinds.Count);
    }
}
