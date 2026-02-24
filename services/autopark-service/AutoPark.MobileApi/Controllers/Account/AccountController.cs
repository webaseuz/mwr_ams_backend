using AutoPark.Application.UseCases.Accounts;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.MobileApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class AccountController :
    MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetUserInfo(
        [FromQuery] GetUserInfoQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GenerateToken(
        [FromBody] GenerateTokenCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken(
        [FromBody] RefreshTokenCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> Logout(
        [FromBody] LogoutCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
