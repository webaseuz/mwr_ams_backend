using AutoPark.Application;
using AutoPark.Application.UseCases.Departments;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize(nameof(PermissionCode.DepartmentView))]
[ApiController]
[Route("[controller]/[action]")]
public class DepartmentController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] GetDepartmentBriefPagedResultQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetDepartmentQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetDepartmentByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(nameof(PermissionCode.DepartmentCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateDepartmentCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(nameof(PermissionCode.DepartmentEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateDepartmentCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.DepartmentDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteDepartmentCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
