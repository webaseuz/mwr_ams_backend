using ServiceDesk.Application.UseCases.Positions;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Application;
using Bms.Core.Infrastructure;
using Bms.Common.Infrastructure;

namespace ServiceDesk.WebApi.Controllers;

[Authorize(nameof(PermissionCode.PositionView))]
[ApiController]
[Route("[controller]/[action]")]
public class PositionController : MediatorController
{
	[HttpGet]
	public async Task<IActionResult> GetBriefListAsync(
		[FromQuery] GetPositionBriefPagedResultQuery query,
		CancellationToken cancellationToken)
		=> Ok(await Mediator.Send(query, cancellationToken));

	[HttpGet]
	public async Task<IActionResult> GetAsync(
		[FromQuery] GetPositionQuery query,
		CancellationToken cancellationToken)
		=> Ok(await Mediator.Send(query, cancellationToken));

	[HttpGet]
	public async Task<IActionResult> GetByIdAsync(
		[FromQuery] GetPositionByIdQuery query,
		CancellationToken cancellationToken)
		=> Ok(await Mediator.Send(query, cancellationToken));


	[Authorize(nameof(PermissionCode.PositionCreate))]
	[HttpPost]
	public async Task<IActionResult> CreateAsync(
		[FromBody] CreatePositionCommand command,
		CancellationToken cancellationToken)
		=> Ok(await Mediator.Send(command, cancellationToken));


	[Authorize(nameof(PermissionCode.PositionEdit))]
	[HttpPost]
	public async Task<IActionResult> UpdateAsync(
		[FromBody] UpdatePositionCommand command,
		CancellationToken cancellationToken)
		=> Ok(await Mediator.Send(command, cancellationToken));

	[Authorize(nameof(PermissionCode.PositionDelete))]
	[HttpPost]
	public async Task<IActionResult> DeleteAsync(
		[FromBody] DeletePositionCommand command,
		CancellationToken cancellationToken)
		=> Ok(await Mediator.Send(command, cancellationToken));
}
