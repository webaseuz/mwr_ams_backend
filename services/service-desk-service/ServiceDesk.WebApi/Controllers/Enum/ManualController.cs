using ServiceDesk.Application.UseCases;
using ServiceDesk.Application.UseCases.CodeFromTypes;
using ServiceDesk.Application.UseCases.DocumentTypes;
using ServiceDesk.Application.UseCases.Enum;
using ServiceDesk.Application.UseCases.Enum.QrCodeTypes;
using ServiceDesk.Application.UseCases.Genders;
using ServiceDesk.Application.UseCases.Languages;
using ServiceDesk.Application.UseCases.Permissons;
using ServiceDesk.Application.UseCases.PlasticCardTypes;
using ServiceDesk.Application.UseCases.QrCodeStates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Bms.Core.Infrastructure;
using ServiceDesk.Application.UseCases.Branches;
using ServiceDesk.Application.UseCases.Citizenships;
using ServiceDesk.Application.UseCases.Departments;
using ServiceDesk.Application.UseCases.Organizations;
using ServiceDesk.Application.UseCases.Persons;
using ServiceDesk.Application.UseCases.Positions;
using ServiceDesk.Application.UseCases.Regions;
using ServiceDesk.Application.UseCases.Roles;
using ServiceDesk.Application.UseCases.Countries;
using ServiceDesk.Application.UseCases.Districts;
using ServiceDesk.Application.UseCases.Contractors;
using ServiceDesk.Application.UseCases.Banks;
using Bms.Common.Infrastructure;
using ServiceDesk.Application.UseCases.Devices;
using ServiceDesk.Application.UseCases.DeviceTypes;
using ServiceDesk.Application.UseCases.DeviceParts;
using ServiceDesk.Application.UseCases.DeviceModels;
using ServiceDesk.Application.UseCases.ServiceTypes;
using ServiceDesk.Application.UseCases.DeviceSpareTypes;
using ServiceDesk.Application.UseCases.ApplicationPurposes;
using ServiceDesk.Application.UseCases.BaseDeviceTypes;
using ServiceDesk.Application.UseCases.ExecutorTypes;
using ServiceDesk.Application.UseCases.MovementTypes;
using ServiceDesk.Application.UseCases.NotificationTemplates;

namespace ServiceDesk.WebApi.Controllers;

[Authorize]
[Route("[controller]/[action]")]
[ApiController]
[OutputCache(Duration = 120, Tags = [nameof(ManualController)])]
public class ManualController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GenderSelectListAsync([FromQuery] GetGenderSelectListQuery query, CancellationToken cancellationToken)
       => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> CodeFromTypeSelectListAsync([FromQuery] GetCodeFromTypeBriefListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> DocumentTypeSelectListAsync([FromQuery] GetDocumentTypeSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> LanguageSelectListAsync([FromQuery] GetLanguageSelectListQuery query,CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> PlasticCardTypeSelectListAsync([FromQuery] GetPlasticCardTypeSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> QrCodeStateSelectListAsync([FromQuery] GetQrCodeStateSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> QrCodeTypeSelectListAsync([FromQuery] GetQrCodeTypeSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> StateSelectListListAsync([FromQuery] GetStateSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> StatusSelectListListAsync([FromQuery] GetStatusSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> PermissionSelectListAsync([FromQuery] GetPermissionSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> RegionSelectListAsync([FromQuery] GetRegionSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> RoleSelectListAsync([FromQuery] GetRoleSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> OrganizationSelectListAsync([FromQuery] GetOrganizationTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> CountrySelectListAsync([FromQuery] GetCountryTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> DistrictSelectListAsync([FromQuery] GetDistrictTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> CitizenshipSelectListAsync([FromQuery] GetCitizenshipSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> BranchSelectListAsync([FromQuery] GetBranchSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> DepartmentSelectListAsync([FromQuery] DepartmentSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> PositionSelectListAsync([FromQuery] PositionSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> BankSelectListAsync([FromQuery] GetBankSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> PersonSelectListAsync([FromQuery] GetPersonSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> ContractorSelectListAsync([FromQuery] GetContractorTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> DeviceSelectListAsync([FromQuery] GetDeviceSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));
	
    [HttpGet]
	public async Task<IActionResult> DeviceTypeSelectListAsync([FromQuery] GetDeviceTypeSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));

	[HttpGet]
	public async Task<IActionResult> DevicePartSelectListAsync([FromQuery] GetDevicePartSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));

	[HttpGet]
	public async Task<IActionResult> DeviceModelSelectListAsync([FromQuery] GetDeviceModelSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));

	[HttpGet]
	public async Task<IActionResult> ServiceTypeSelectListAsync([FromQuery] GetServiceTypeSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));
    [HttpGet]
	public async Task<IActionResult> DeviceSpareTypeSelectListAsync([FromQuery] GetDeviceSpareTypeSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));
    [HttpGet]
	public async Task<IActionResult> ApplicationPurposeSelectListAsync([FromQuery] GetApplicationPurposeSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));
    [HttpGet]
	public async Task<IActionResult> BaseDeviceTypeSelectListAsync([FromQuery] GetBaseDeviceTypeSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));
    [HttpGet]
	public async Task<IActionResult> ExecutorTypeSelectListAsync([FromQuery] GetExecutorTypeSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));
	[HttpGet]
	public async Task<IActionResult> MovementTypeSelectListAsync([FromQuery] GetMovementTypeSelectListQuery query, CancellationToken cancellationToken)
	=> Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> NotificationTemplateSelectListAsync([FromQuery] GetNotificationTemplateSelectListQuery query, CancellationToken cancellationToken)
     => Ok(await Mediator.Send(query, cancellationToken));
}
