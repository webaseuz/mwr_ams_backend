
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.CurrencyView)]
[ApiController]
[Route("[controller]/[action]")]
public class CurrencyController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] CurrencyGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] CurrencyGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] CurrencyGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.CurrencyCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CurrencyCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.CurrencyEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] CurrencyUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.CurrencyDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] CurrencyDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
