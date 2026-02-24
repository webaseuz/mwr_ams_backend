using AutoPark.Application;
using AutoPark.Application.UseCases.Drivers;
using AutoPark.Application.UseCases.Hl.Driver.Excel.Query.GetExcelForInsert;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

//[Authorize(nameof(PermissionCode.DriverView))]
[ApiController]
[Route("[controller]/[action]")]
public class DriverController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetDriverBriefPagedResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetDriverQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetDriverByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetDocumentByIdAsync(
        [FromQuery] GetDriverDocumentByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.DriverCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateDriverCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.DriverEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateDriverCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.DriverDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteDriverCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.DriverView))]
    [HttpPost]
    public async Task<IActionResult> UploadFileAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new UploadDriverDocumentFileCommand(files), cancellationToken));

    [Authorize(nameof(PermissionCode.DriverView))]
    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] DownloadDriverDocumentFileCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.DriverView))]
    [HttpGet]
    public async Task<IActionResult> DownloadExcelForInsertAsync(
    [FromQuery] GetExcelForInsertQuery command,
    CancellationToken cancellationToken)
    {
        var stream = await Mediator.Send(command, cancellationToken);

        return File(
            fileStream: stream,
            contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            fileDownloadName: "driver_template.xlsx"
        );
    }

    ////[Authorize(nameof(PermissionCode.DriverView))]
    //[HttpPost]
    //[Consumes("multipart/form-data")]
    //public async Task<IActionResult> InsertFromExcelAsync(
    //[FromForm] InsertFromExcelQuery query,
    //CancellationToken cancellationToken)
    //=> Ok(await Mediator.Send(query, cancellationToken));

}
