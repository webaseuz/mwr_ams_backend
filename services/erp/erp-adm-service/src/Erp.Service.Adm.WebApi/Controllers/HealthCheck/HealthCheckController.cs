
namespace Erp.Service.Adm.WebApi;

[ApiController]
[Route("[controller]/[action]")]
public class HealthCheckController : BaseController
{
    [HttpGet]
    public IActionResult Check()
        => Ok("Healthy");
}
