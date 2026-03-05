
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.ContractorView)]
[ApiController]
[Route("[controller]/[action]")]
public class ContractorController : BaseController
{

    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
      [FromQuery] ContractorGetListQuery query,
      CancellationToken cancellationToken)
      => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] ContractorGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] ContractorGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.ContractorCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] ContractorCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.ContractorEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] ContractorUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.ContractorDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] ContractorDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
