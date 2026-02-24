using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ServiceDesk.MobileApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HealthCheckController : MediatorController
{
    [HttpGet]
    public IActionResult Check()
        => Ok("Healthy");
}
