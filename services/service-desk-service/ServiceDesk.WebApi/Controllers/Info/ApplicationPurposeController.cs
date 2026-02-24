using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Application;
using ServiceDesk.Application.UseCases.DeviceModels;
using ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

namespace ServiceDesk.WebApi.Controllers;

[Authorize(nameof(PermissionCode.ApplicationPurposeView))]
[ApiController]
[Route("[controller]/[action]")]
public class ApplicationPurposeController : MediatorController
{

    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetApplicationPurposeBriefPagedResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetApplicationPurposeQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetApplicationPurposeByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(nameof(PermissionCode.ApplicationPurposeCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateApplicationPurposeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(nameof(PermissionCode.ApplicationPurposeEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateApplicationPurposeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ApplicationPurposeDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteApplicationPurposeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
