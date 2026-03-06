
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.InsuranceTypeView)]
[ApiController]
[Route("[controller]/[action]")]
public class InsuranceTypeController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] InsuranceTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] InsuranceTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] InsuranceTypeGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AutoparkPermissionCode.InsuranceTypeCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] InsuranceTypeCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AutoparkPermissionCode.InsuranceTypeEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] InsuranceTypeUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.InsuranceTypeDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] InsuranceTypeDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}


