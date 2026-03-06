
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.TransportColorView)]
[ApiController]
[Route("[controller]/[action]")]
public class TransportColorController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] TransportColorGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] TransportColorGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TransportColorGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.TransportColorCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TransportColorCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.TransportColorEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TransportColorUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TransportColorDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] TransportColorDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
