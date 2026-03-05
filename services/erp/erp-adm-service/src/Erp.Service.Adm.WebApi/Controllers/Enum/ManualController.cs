using Microsoft.AspNetCore.OutputCaching;

namespace Erp.Service.Adm.WebApi;

[Authorize]
[Route("[controller]/[action]")]
[ApiController]
[OutputCache(Duration = 120, Tags = [nameof(ManualController)])]
public class ManualController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GenderSelectListAsync([FromQuery] GenderSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> CodeFromTypeSelectListAsync([FromQuery] CodeFromTypeSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> DocumentTypeSelectListAsync([FromQuery] DocumentTypeSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> LanguageSelectListAsync([FromQuery] LanguageSelectListQuery query,
                                                                CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> PlasticCardTypeSelectListAsync([FromQuery] PlasticCardTypeSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> QrCodeStateSelectListAsync([FromQuery] QrCodeStateSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> QrCodeTypeSelectListAsync([FromQuery] QrCodeTypeSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> StateSelectListListAsync([FromQuery] StateSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> StatusSelectListListAsync([FromQuery] StatusSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportTypeSelectListAsync([FromQuery] TransportTypeSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> PermissionSelectListAsync([FromQuery] PermissionSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> RegionSelectListAsync([FromQuery] RegionSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> RoleSelectListAsync([FromQuery] RoleSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> OrganizationSelectListAsync([FromQuery] OrganizationSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> CountrySelectListAsync([FromQuery] CountrySelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> DistrictSelectListAsync([FromQuery] DistrictSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> CitizenshipSelectListAsync([FromQuery] CitizenshipSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> BranchSelectListAsync([FromQuery] BranchSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> DepartmentSelectListAsync([FromQuery] DepartmentSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> PositionSelectListAsync([FromQuery] PositionSelectListQuery query, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> BankSelectListAsync([FromQuery] BankSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> PersonSelectListAsync([FromQuery] PersonSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> DriverSelectListAsync([FromQuery] DriverSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportSelectListAsync([FromQuery] TransportSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportBrandSelectListAsync([FromQuery] TransportBrandSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportColorSelectListAsync([FromQuery] TransportColorSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportModelSelectListAsync([FromQuery] TransportModelSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportUseTypeSelectListAsync([FromQuery] TransportUseTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> ContractorSelectListAsync([FromQuery] ContractorSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> ExpenseSelectListAsync([FromQuery] ExpenseSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> OilTypeSelectListAsync([FromQuery] OilTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> BatteryTypeSelectListAsync([FromQuery] BatteryTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> FuelTypeSelectListAsync([FromQuery] FuelTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> InsuranceTypeSelectListAsync([FromQuery] InsuranceTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> InspectionTypeSelectListAsync([FromQuery] InspectionTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> FuelCardSelectListAsync([FromQuery] FuelCardSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransportModelFileSelectListAsync([FromQuery] TransportModelFileSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TransmissionBoxTypeSelectListAsync([FromQuery] TransmissionBoxTypeSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> OilModelSelectListAsync([FromQuery] OilModelSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TireModelSelectListAsync([FromQuery] TireModelSelectListQuery query, CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> LiquidTypeSelectListAsync([FromQuery] LiquidTypeSelectListQuery query, CancellationToken cancellationToken)
   => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> TireSizeSelectListAsync([FromQuery] TireSizeSelectListQuery query, CancellationToken cancellationToken)
     => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> NotificationTemplateSelectListAsync([FromQuery] NotificationTemplateSelectListQuery query, CancellationToken cancellationToken)
     => Ok(await Mediator.Send(query, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UserSelectListAsync([FromBody] UserSelectListQuery query, CancellationToken cancellationToken)
     => Ok(await Mediator.Send(query, cancellationToken));
}
