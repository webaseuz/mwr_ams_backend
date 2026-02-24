//using AutoPark.Application;
//using AutoPark.Application.UseCases.TransportSettings;
//using Bms.Common.Infrastructure;
//using Bms.Core.Infrastructure;
//using Microsoft.AspNetCore.Mvc;

//namespace AutoPark.MobileApi.Controllers;

//[Authorize(nameof(PermissionCode.TransportSettingView))]
//[ApiController]
//[Route("[controller]/[action]")]
//public class TransportSettingController : MediatorController
//{
//    [Authorize(nameof(PermissionCode.TransportSettingView))]
//    [HttpGet]
//    public async Task<IActionResult> GetByIdAsync(
//        [FromQuery] GetTransportSettingByIdQuery query,
//        CancellationToken cancellationToken)
//        => Ok(await Mediator.Send(query, cancellationToken));

//    [Authorize(nameof(PermissionCode.TransportSettingView))]
//    [HttpGet]
//    public async Task<IActionResult> GetBriefListAsync(
//        [FromQuery] GetTransportSettingBriefAsPageResultQuery query,
//        CancellationToken cancellationToken)
//        => Ok(await Mediator.Send(query, cancellationToken));
//}
