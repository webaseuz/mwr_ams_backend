using AutoPark.Application;
using AutoPark.Application.UseCases.MobileAppVersions;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Bms.WEBASE.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AutoPark.MobileApi.Controllers;

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

    [HttpGet("{fileId}")]
    public async Task<IActionResult> DownloadFileAsync(
        Guid fileId,
        CancellationToken cancellationToken)
    {
        StorageFile file = await Mediator.Send(new DownloadMobileAppVersionCommand(fileId), cancellationToken);
        var res = new FileExtensionContentTypeProvider();
        if (!res.TryGetContentType(file.FileName, out string contentType))
        {
            contentType = "application/octet-stream"; // .apk uchun specific MIME type
            if (file.FileName.EndsWith(".apk", StringComparison.OrdinalIgnoreCase))
            {
                contentType = "application/vnd.android.package-archive";
            }
        }

        return File(file.GetStream(), contentType);
    }
}
