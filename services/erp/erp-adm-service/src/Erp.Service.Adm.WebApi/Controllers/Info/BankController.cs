
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.BankView)]
[ApiController]
[Route("[controller]/[action]")]
public class BankController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] BankGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] BankGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] BankGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.BankCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] BankCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.BankEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] BankUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.BankDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] BankDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
