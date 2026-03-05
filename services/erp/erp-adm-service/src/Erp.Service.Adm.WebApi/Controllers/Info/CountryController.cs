
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.CountryView)]
[ApiController]
[Route("[controller]/[action]")]
public class CountryController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] CountryGetListQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] CountryGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] CountryGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.CountryCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CountryCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.CountryEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] CountryUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.CountryDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] CountryDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
