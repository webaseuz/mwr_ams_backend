using AutoPark.Application.UseCases;
using AutoPark.Application.UseCases.Banks;
using AutoPark.Application.UseCases.BatteryTypes;
using AutoPark.Application.UseCases.Branches;
using AutoPark.Application.UseCases.Citizenships;
using AutoPark.Application.UseCases.CodeFromTypes;
using AutoPark.Application.UseCases.Contractors;
using AutoPark.Application.UseCases.Countries;
using AutoPark.Application.UseCases.Departments;
using AutoPark.Application.UseCases.Districts;
using AutoPark.Application.UseCases.DocumentTypes;
using AutoPark.Application.UseCases.Drivers;
using AutoPark.Application.UseCases.Enum;
using AutoPark.Application.UseCases.Enum.QrCodeTypes;
using AutoPark.Application.UseCases.Expenses;
using AutoPark.Application.UseCases.FuelCards;
using AutoPark.Application.UseCases.FuelTypes;
using AutoPark.Application.UseCases.Genders;
using AutoPark.Application.UseCases.InsuranceTypes;
using AutoPark.Application.UseCases.Languages;
using AutoPark.Application.UseCases.NotificationTemplates;
using AutoPark.Application.UseCases.OilModels;
using AutoPark.Application.UseCases.OilTypes;
using AutoPark.Application.UseCases.Organizations;
using AutoPark.Application.UseCases.Permissons;
using AutoPark.Application.UseCases.Persons;
using AutoPark.Application.UseCases.PlasticCardTypes;
using AutoPark.Application.UseCases.Positions;
using AutoPark.Application.UseCases.QrCodeStates;
using AutoPark.Application.UseCases.Regions;
using AutoPark.Application.UseCases.Roles;
using AutoPark.Application.UseCases.TireModels;
using AutoPark.Application.UseCases.TireSizes;
using AutoPark.Application.UseCases.TransmissionBoxTypes;
using AutoPark.Application.UseCases.TransportBrands;
using AutoPark.Application.UseCases.TransportColors;
using AutoPark.Application.UseCases.TransportModelFiles;
using AutoPark.Application.UseCases.TransportModels;
using AutoPark.Application.UseCases.Transports;
using AutoPark.Application.UseCases.TransportUseTypes;
using AutoPark.Application.UseCases.Users;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace AutoPark.MobileApi.Controllers;

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
    public async Task<IActionResult> LanguageSelectListAsync([FromQuery] GetLanguageSelectListQuery query,
                                                                CancellationToken cancellationToken)
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
    public async Task<IActionResult> TransportTypeSelectListAsync([FromQuery] GetTransportTypeSelectListQuery query, CancellationToken cancellationToken)
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
    public async Task<IActionResult> DriverSelectListAsync([FromQuery] GetDriverSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportSelectListAsync([FromQuery] GetTransportSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportBrandSelectListAsync([FromQuery] GetTransportBrandSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportColorSelectListAsync([FromQuery] GetTransportColorSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportModelSelectListAsync([FromQuery] GetTransportModelSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportUseTypeSelectListAsync([FromQuery] GetTransportUseTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> ContractorSelectListAsync([FromQuery] GetContractorTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> ExpenseSelectListAsync([FromQuery] GetExpenseSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> OilTypeSelectListAsync([FromQuery] GetOilTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> BatteryTypeSelectListAsync([FromQuery] GetBatteryTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> FuelTypeSelectListAsync([FromQuery] GetFuelTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> InsuranceTypeSelectListAsync([FromQuery] GetInsuranceTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> InspectionTypeSelectListAsync([FromQuery] GetInspectionTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> FuelCardSelectListAsync([FromQuery] GetFuelCardSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportModelFileSelectListAsync([FromQuery] GetTransportModelFileSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransmissionBoxTypeSelectListAsync([FromQuery] GetTransmissionBoxTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> OilModelSelectListAsync([FromQuery] GetOilModelSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TireModelSelectListAsync([FromQuery] GetTireModelSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> LiquidTypeSelectListAsync([FromQuery] GetLiquidTypeSelectListQuery query, CancellationToken cancellationToken)
   => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TireSizeSelectListAsync([FromQuery] GetTireSizeSelectListQuery query, CancellationToken cancellationToken)
     => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> NotificationTemplateSelectListAsync([FromQuery] GetNotificationTemplateSelectListQuery query, CancellationToken cancellationToken)
     => Ok(await Mediator.Send(query, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UserSelectListAsync([FromBody] GetUserSelectListQuery query, CancellationToken cancellationToken)
     => Ok(await Mediator.Send(query, cancellationToken));
}
