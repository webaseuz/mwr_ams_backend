
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.UserView)]
[ApiController]
[Route("[controller]/[action]")]
public class UserController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] UserGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] UserGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] UserGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.UserCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] UserCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.UserEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UserUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.UserDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] UserDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    // TODO: UpdateStateUserCommand not in new Models — implement when needed
    // [Authorize(AdmPermissionCode.AllUserEdit)]
    // [HttpPost]
    // public async Task<IActionResult> UpdateStateAsync(
    //     [FromBody] UpdateStateUserCommand command,
    //     CancellationToken cancellationToken)
    //     => Ok(await Mediator.Send(command, cancellationToken));
}
