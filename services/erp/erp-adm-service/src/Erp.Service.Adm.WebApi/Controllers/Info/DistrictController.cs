
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.DistrictView)]
[ApiController]
[Route("[controller]/[action]")]
public class DistrictController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] DistrictGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] DistrictGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] DistrictGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.DistrictCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] DistrictCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.DistrictEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] DistrictUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.DistrictDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DistrictDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
