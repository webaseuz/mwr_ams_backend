using Microsoft.AspNetCore.Mvc;
using WEBASE.AspNet;
using WEBASE.LogSdk.BLL.Services;
using WEBASE.LogSdk.Core.Attributes;
using WEBASE.LogSdk.Core.Enums;
using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.Models;

namespace WEBASE.LogSdk.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AppErrorController : WebaseController
{
    private AppErrorService _appErrorService;
    private AppErrorArchiveService _appErrorArchiveService;
    private ErrorScopeService _errorScopeService;

    public AppErrorController(AppErrorService service, AppErrorArchiveService appErrorArchiveService,
        ErrorScopeService errorScopeService)
        : base(new ControllerConfig { EnableSecurityInfo = true })
    {
        _appErrorService = service;
        _appErrorArchiveService = appErrorArchiveService;
        _errorScopeService = errorScopeService;
    }


    [HttpPost]
    [LogSdkAuthorize(LogSdkPermissionCode.AppErrorView)]
    [ProducesResponseType(typeof(PagedResult<ErrorScope>), 200)]
    public IActionResult GetList([FromBody] ErrorScopeOption dto)
    {
        return Ok(_errorScopeService.GetList(dto));
    }

    [HttpPost]
    [LogSdkAuthorize(LogSdkPermissionCode.AppErrorView)]
    [ProducesResponseType(typeof(ErrorScopeDashboardDto), 200)]
    public IActionResult GetDashboard(ErrorScopeDashboardOptions options)
    {
        return Ok(_errorScopeService.GetDashboard(options));
    }

    [HttpPost]
    [LogSdkAuthorize(LogSdkPermissionCode.AppErrorView)]
    [ProducesResponseType(typeof(ErrorScopeTabDto), 200)]
    public IActionResult GetTabInfo([FromQuery] bool isDaily = false)
    {
        return Ok(_errorScopeService.GetTabInfo(isDaily));
    }

    [HttpGet("{id}")]
    [LogSdkAuthorize(LogSdkPermissionCode.AppErrorView)]
    [ProducesResponseType(typeof(AppError), 200)]
    public IActionResult Get(int id)
    {
        var dto = _errorScopeService.Get(id);

        if (_errorScopeService.IsValid)
            return Ok(dto);

        _errorScopeService.CopyErrorsToModelState(ModelState);
        return ValidationProblem(ModelState);
    }

    [HttpPost("{id}")]
    [LogSdkAuthorize(LogSdkPermissionCode.AppErrorView)]
    [ProducesResponseType(typeof(bool), 200)]
    public IActionResult Fix(int id)
    {
        _errorScopeService.Fix(id);

        if (_errorScopeService.IsValid)
            return Ok(true);

        _errorScopeService.CopyErrorsToModelState(ModelState);
        return ValidationProblem(ModelState);
    }

    [HttpPost]
    [LogSdkAuthorize(LogSdkPermissionCode.AppErrorView)]
    [ProducesResponseType(typeof(bool), 200)]
    public IActionResult ItemsList(AppErrorOption option)
    {
        var res = _appErrorService.GetListBy(option);

        if (_appErrorService.IsValid)
            return Ok(res);

        _appErrorService.CopyErrorsToModelState(ModelState);
        return ValidationProblem(ModelState);
    }

    [HttpGet("{itemId}")]
    [LogSdkAuthorize(LogSdkPermissionCode.AppErrorView)]
    [ProducesResponseType(typeof(bool), 200)]
    public IActionResult Items(int itemId)
    {
        var res = _appErrorService.Get(itemId);

        if (_appErrorService.IsValid)
            return Ok(res);

        _appErrorService.CopyErrorsToModelState(ModelState);
        return ValidationProblem(ModelState);
    }
}