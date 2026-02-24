using ServiceDesk.Application;
using ServiceDesk.Application.UseCases.MobileAppVersions;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ServiceDesk.MobileApi.Controllers;

[Authorize(nameof(PermissionCode.MobileAppVersionView))]
[ApiController]
[Route("[controller]/[action]")]
public class MobileAppVersionController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetLastVersionAsync(
        [FromQuery] GetLastMobileAppVersionQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] DownloadMobileAppVersionCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
