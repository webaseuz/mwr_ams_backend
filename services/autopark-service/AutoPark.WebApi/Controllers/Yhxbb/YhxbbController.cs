
using AutoPark.Application.UseCases;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers.Yhxbb;


[Route("[controller]/[action]")]
[ApiController]
public class YhxbbController : MediatorController
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