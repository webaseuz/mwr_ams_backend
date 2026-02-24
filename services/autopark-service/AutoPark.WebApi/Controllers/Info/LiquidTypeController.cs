using AutoPark.Application;
using AutoPark.Application.UseCases.Info.LiquidTypes;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace AutoPark.WebApi.Controllers.Info
{
    [Authorize(nameof(PermissionCode.LiquidTypeView))]
    [ApiController]
    [Route("[controller]/[action]")]
    public class LiquidTypeController : MediatorController
    {
        [HttpGet]
        public async Task<IActionResult> GetBriefListAsync(
       [FromQuery] GetLiquidTypeBriefPagedResultQuery query,
       CancellationToken cancellationToken)
       => Ok(await Mediator.Send(query, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetLiquidTypeQuery query,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(query, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(
            [FromQuery] GetLiquidTypeByIdQuery query,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(query, cancellationToken));


        [Authorize(nameof(PermissionCode.LiquidTypeCreate))]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateLiquidTypeCommand command,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));


        [Authorize(nameof(PermissionCode.LiquidTypeEdit))]
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateLiquidTypeCommand command,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));

        [Authorize(nameof(PermissionCode.LiquidTypeDelete))]
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteLiquidTypeCommand command,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));
    }
}
