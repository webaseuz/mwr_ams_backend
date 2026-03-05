
using WEBASE.Storage;

namespace Erp.Service.Adm.WebApi;

//[Authorize(AdmPermissionCode.DriverView)]
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

    [Authorize(AdmPermissionCode.DriverCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] DriverCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.DriverEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] DriverUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.DriverDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DriverDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.DriverView)]
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<StorageFileInfoDto>), 200)]
    public async Task<IActionResult> UploadFileAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
    {
        WbStorageFile[] wbStorageFile = files.Select(a => new WbStorageFile(a.FileName, a.OpenReadStream())).ToArray();

        return Ok(await Mediator.Send(new DriverDocumentUploadCommand { Files = wbStorageFile }, cancellationToken));
    }

    [Authorize(AdmPermissionCode.DriverView)]
    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] DriverDocumentDownloadCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.DriverView)]
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

    ////[Authorize(AdmPermissionCode.DriverView)]
    //[HttpPost]
    //[Consumes("multipart/form-data")]
    //public async Task<IActionResult> InsertFromExcelAsync(
    //[FromForm] InsertFromExcelQuery query,
    //CancellationToken cancellationToken)
    //=> Ok(await Mediator.Send(query, cancellationToken));

}
