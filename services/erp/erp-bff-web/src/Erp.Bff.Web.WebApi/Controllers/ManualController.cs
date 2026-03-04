using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;
using WEBASE;
namespace Erp.Adm.Bff.Web.WebApi;

[ApiController]
[Route("[controller]/[action]")]
public class ManualController : ControllerBase
{
    private readonly IManualApi _manualApi;

    public ManualController(IManualApi manualApi)
    {
        _manualApi = manualApi;
    }

    [HttpGet]
    public async Task<IActionResult> ExternalSystemSelectList()
        => Ok(await _manualApi.ExternalSystemSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> ExternalStatusSelectList()
        => Ok(await _manualApi.ExternalStatusSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> GenderSelectList()
        => Ok(await _manualApi.GenderSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> LanguageSelectList()
        => Ok(await _manualApi.LanguageSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> BankSelectList()
        => Ok(await _manualApi.BankSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> StateSelectList()
        => Ok(await _manualApi.StateSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> StatusSelectList()
        => Ok(await _manualApi.StatusSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> CountrySelectList()
        => Ok(await _manualApi.CountrySelectListAsync());

    [HttpGet]
    public async Task<IActionResult> NationalitySelectList()
        => Ok(await _manualApi.NationalitySelectListAsync());

    [HttpGet]
    public async Task<IActionResult> CitizenshipSelectList()
        => Ok(await _manualApi.CitizenshipSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> CurrencySelectList()
        => Ok(await _manualApi.CurrencySelectListAsync());

    [HttpGet]
    public async Task<IActionResult> RegionSelectList(int? countryId = null)
        => Ok(await _manualApi.RegionSelectListAsync(/*countryId*/));

    [HttpGet]
    public async Task<IActionResult> DistrictSelectList([FromQuery] int regionId)
        => Ok(await _manualApi.DistrictSelectListAsync(new DistrictSelectListQuery
        {
            RegionId = regionId
        }));

    [HttpGet]
    public async Task<IActionResult> AppSelectList()
        => Ok(await _manualApi.AppSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> PermissionGroupSelectList()
        => Ok(await _manualApi.PermissionGroupSelectList());

    [HttpGet]
    public async Task<IActionResult> PermissionSelectList(int? appId)
        => Ok(await _manualApi.PermissionSelectList(new PermissionSelectListQuery { AppId = appId }));

    [HttpGet]
    public async Task<IActionResult> OrganizationTypeAsSelectList([FromQuery] OrganizationTypeSelectListQuery query)
        => Ok(await _manualApi.OrganizationTypeSelectListAsync(query)
            );

    [HttpGet]
    public async Task<IActionResult> MusicOrganizationCategoryAsSelectList([FromQuery] MusicOrganizationCategorySelectListQuery query)
        => Ok(await _manualApi.MusicOrganizationCategorySelectListAsync(query));

    [HttpGet]
    public async Task<IActionResult> KinshipDegreeAsSelectList()
        => Ok(await _manualApi.KinshipDegreeSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> DocumentTypeSelectList([FromQuery] DocumentTypeSelectListQuery query)
        => Ok(await _manualApi.DocumnetTypeSelectListAsync(query));

    [HttpGet]
    public async Task<IActionResult> DistrictGroupSelectList()
        => Ok(await _manualApi.DistrictGroupSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> OrganizationalFormSelectList()
        => Ok(await _manualApi.OrganizationalFormSelectListAsync());

    [HttpGet]
    public async Task<IActionResult> UnitOfMeasureSelectList()
        => Ok(await _manualApi.UnitOfMeasureSelectListAsync());


    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> InstitutionTypeSelectList([FromQuery] InstitutionTypeSelectListQuery query)
        => Ok(await _manualApi.InstitutionTypeSelectListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> EmploymentTypeSelectList()
        => Ok(await _manualApi.EmploymentTypeSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> IdentityDocSeriesSelectList()
    => Ok(await _manualApi.IdentityDocSeriesSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> CalculationTypeSelectList()
        => Ok(await _manualApi.CalculationTypeSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> CalculationMethodSelectList()
        => Ok(await _manualApi.CalculationMethodSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> CalculateByTimeTypeSelectList()
        => Ok(await _manualApi.CalculateByTimeTypeSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> TableSelectList()
        => Ok(await _manualApi.TableSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> MinimumValueTypeSelectList()
        => Ok(await _manualApi.MinimumValueTypeSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> FileTypeSelectList()
        => Ok(await _manualApi.FileTypeSelectListAsync());

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, OrganizationAccountSelectListDto>), 200)]
    public async Task<IActionResult> OrganizationAccountSelectList([FromQuery] OrganizationAccountSelectListQuery query)
        => Ok(await _manualApi.OrganizationAccountSelectListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int, CustomJobTypeSelectListDto>), 200)]
    public async Task<IActionResult> CustomJobTypeSelectList([FromQuery] CustomJobTypeSelectListQuery query)
        => Ok(await _manualApi.CustomJobTypeSelectListAsync(query));

    [HttpGet]
    [ProducesResponseType(typeof(WbSelectList<int>), 200)]
    public async Task<IActionResult> EndpointTypeSelectList([FromQuery] EndpointTypeSelectListQuery query)
        => Ok(await _manualApi.EndpointTypeSelectListAsync(query));
}
