using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// Manual API client interface for select lists and lookup data
/// </summary>
public interface IManualApi
{
    /// <summary>
    /// Get external system select list
    /// </summary>
    [Post("/Manual/ExternalSystemSelectList")]
    Task<WbSelectList<int>> ExternalSystemSelectListAsync();

    /// <summary>
    /// Get external status select list
    /// </summary>
    [Post("/Manual/ExternalStatusSelectList")]
    Task<WbSelectList<int>> ExternalStatusSelectListAsync();

    /// <summary>
    /// Get gender select list
    /// </summary>
    [Post("/Manual/GenderSelectList")]
    Task<WbSelectList<int>> GenderSelectListAsync();

    /// <summary>
    /// Get language select list
    /// </summary>
    [Post("/Manual/LanguageSelectList")]
    Task<WbSelectList<int, LanguageSelectListDto>> LanguageSelectListAsync();

    [Post("/Manual/BankSelectList")]
    Task<WbSelectList<int>> BankSelectListAsync();

    /// <summary>
    /// Get country select list
    /// </summary>
    [Post("/Manual/CountrySelectList")]
    Task<WbSelectList<int, CountrySelectListDto>> CountrySelectListAsync();

    /// <summary>
    /// Get currency select list
    /// </summary>
    [Post("/Manual/CurrencySelectList")]
    Task<WbSelectList<int, CountrySelectListDto>> CurrencySelectListAsync();

    /// <summary>
    /// Get nationality select list
    /// </summary>
    [Post("/Manual/CitizenshipSelectList")]
    Task<WbSelectList<int, CitizenshipSelectListDto>> CitizenshipSelectListAsync();


    [Post("/Manual/NationalitySelectList")]
    Task<WbSelectList<int, NationalitySelectListDto>> NationalitySelectListAsync();

    [Post("/Manual/RegionSelectList")]
    Task<WbSelectList<int, RegionSelectListDto>> RegionSelectListAsync();

    [Post("/Manual/DistrictSelectList")]
    Task<WbSelectList<int, DistrictSelectListDto>> DistrictSelectListAsync([Body] DistrictSelectListQuery query);

    [Post("/Manual/StateSelectList")]
    Task<WbSelectList<int>> StateSelectListAsync();

    [Post("/Manual/StatusSelectList")]
    Task<WbSelectList<int>> StatusSelectListAsync();

    [Post("/Manual/AppSelectList")]
    Task<WbSelectList<int>> AppSelectListAsync();

    [Post("/Manual/PermissionGroupSelectList")]
    Task<WbSelectList<int>> PermissionGroupSelectList();

    [Post("/Manual/PermissionSelectList")]
    Task<IEnumerable<PermissionGroupDto>> PermissionSelectList([Body] PermissionSelectListQuery query);

    [Post("/SelectList/EduYearSelectList")]
    Task<WbSelectList<int, EduYearSelectListDto>> EduYearSelectListAsync();

    [Post("/Manual/OkedSelectList")]
    Task<WbSelectList<int>> OkedSelectListAsync();

    [Post("/Manual/OrganizationSelectList")]
    Task<WbSelectList<int, OrganizationSelectListDto>> OrganizationSelectListAsync();

    [Post("/Manual/OrganizationalFormSelectList")]
    Task<WbSelectList<int, OrganizationFormSelectListDto>> OrganizationalFormSelectListAsync();

    [Post("/Manual/OrganizationTypeSelectList")]
    Task<WbSelectList<int>> OrganizationTypeSelectListAsync();

    [Post("/Manual/MusicOrganizationCategorySelectList")]
    Task<WbSelectList<int>> MusicOrganizationCategorySelectListAsync();

    [Post("/Manual/InstitutionTypeSelectList")]
    Task<WbSelectList<int>> InstitutionTypeSelectListAsync([Body] InstitutionTypeSelectListQuery query);

    [Post("/Manual/KinshipDegreeSelectList")]
    Task<WbSelectList<int, KinshipDegreeSelectListDto>> KinshipDegreeSelectListAsync();

    [Post("/Manual/DocumentTypeSelectList")]
    Task<WbSelectList<int, DocumentTypeSelectListDto>> DocumnetTypeSelectListAsync();

    [Post("/Manual/IdentityDocSeriesSelectList")]
    Task<WbSelectList<int>> IdentityDocSeriesSelectListAsync();

    [Post("/Manual/DistrictGroupSelectList")]
    Task<WbSelectList<int, DistrictGroupSelectListDto>> DistrictGroupSelectListAsync();

    [Post("/Manual/UnitOfMeasureSelectList")]
    Task<WbSelectList<int, UnitOfMeasureSelectListDto>> UnitOfMeasureSelectListAsync();

    [Post("/Manual/EmploymentTypeSelectList")]
    Task<WbSelectList<int>> EmploymentTypeSelectListAsync();

    [Post("/Manual/CalculationTypeSelectList")]
    Task<WbSelectList<int>> CalculationTypeSelectListAsync();

    [Post("/Manual/CalculationMethodSelectList")]
    Task<WbSelectList<int>> CalculationMethodSelectListAsync();

    [Post("/Manual/CalculateByTimeTypeSelectList")]
    Task<WbSelectList<int>> CalculateByTimeTypeSelectListAsync();

    [Post("/Manual/TableSelectList")]
    Task<WbSelectList<int>> TableSelectListAsync();

    [Post("/Manual/TemporaryResidenceTypeSelectList")]
    Task<WbSelectList<int>> TemporaryResidenceTypeSelectListAsync();

    [Post("/Manual/MinimumValueTypeSelectList")]
    Task<WbSelectList<int>> MinimumValueTypeSelectListAsync();

    [Post("/Manual/OrganizationSelectList")]
    Task<WbSelectList<int>> OrganizationSelectListAsync([Body] OrganizationSelectListQuery query);

    [Post("/Manual/OrganizationAccountSelectList")]
    Task<WbSelectList<int, OrganizationAccountSelectListDto>> OrganizationAccountSelectListAsync([Body] OrganizationAccountSelectListQuery query);

    [Post("/Organization/GetList")]
    Task<WbPagedResult<OrganizationBriefDto>> OrganizationGetListAsync([Body] OrganizationGetListQuery query);

    [Post("/Manual/IdentityDocSeriesSelectList")]
    Task<WbSelectList<int>> IdentityDocSeriesSelectListAync();

    [Post("/Manual/FileTypeSelectList")]
    Task<WbSelectList<int>> FileTypeSelectListAsync();
}
