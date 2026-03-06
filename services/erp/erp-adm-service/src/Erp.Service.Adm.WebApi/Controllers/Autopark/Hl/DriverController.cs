
using WEBASE.Storage;

namespace Erp.Service.Adm.WebApi;

//[Authorize(AutoparkPermissionCode.DriverView)]
[ApiController]
[Route("[controller]/[action]")]
public class DriverController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] DriverGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] DriverGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] DriverGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetDocumentByIdAsync(
        [FromQuery] DriverDocumentGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AutoparkPermissionCode.DriverCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] DriverCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.DriverEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] DriverUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.DriverDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DriverDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.DriverView)]
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<StorageFileInfoDto>), 200)]
    public async Task<IActionResult> UploadFileAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
    {
        WbStorageFile[] wbStorageFile = files.Select(a => new WbStorageFile(a.FileName, a.OpenReadStream())).ToArray();

        return Ok(await Mediator.Send(new DriverDocumentUploadCommand { Files = wbStorageFile }, cancellationToken));
    }

    [Authorize(AutoparkPermissionCode.DriverView)]
    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] DriverDocumentDownloadCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.DriverView)]
    [HttpGet]
    public async Task<IActionResult> DownloadExcelForInsertAsync(
    [FromQuery] DriverGetExcelTemplateQuery command,
    CancellationToken cancellationToken)
    {
        var stream = await Mediator.Send(command, cancellationToken);

        return File(
            fileStream: stream,
            contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            fileDownloadName: "driver_template.xlsx"
        );
    }

    ////[Authorize(AutoparkPermissionCode.DriverView)]
    //[HttpPost]
    //[Consumes("multipart/form-data")]
    //public async Task<IActionResult> InsertFromExcelAsync(
    //[FromForm] InsertFromExcelQuery query,
    //CancellationToken cancellationToken)
    //=> Ok(await Mediator.Send(query, cancellationToken));

}
