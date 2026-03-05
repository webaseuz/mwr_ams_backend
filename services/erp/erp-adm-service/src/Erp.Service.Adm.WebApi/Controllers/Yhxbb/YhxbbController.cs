

using Erp.Service.Adm.Application.UseCases;

namespace Erp.Service.Adm.WebApi;


[Route("[controller]/[action]")]
[ApiController]
public class YhxbbController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetDriverLicenseInfoAsync(
        [FromQuery] DriverLicenseQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetVehicleInfoAsync(
        [FromQuery] VehicleLicenseQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetVehicleInfoBySearchAsync(
        [FromQuery] VehicleSearchQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}