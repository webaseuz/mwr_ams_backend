using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Erp.Service.Adm.Sdk;

namespace Erp.Adm.Bff.Web.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class TestController : ControllerBase
{
    private readonly IConfiguration _config;
    public TestController(IConfiguration configuration)
    {
        _config = configuration;
    }

    [HttpPost]
    public IActionResult TouchAppSettings()
    {
        var json = JsonConvert.SerializeObject(AppSettings.Instance);
        Console.Write(json);
        return Ok();
    }
}
