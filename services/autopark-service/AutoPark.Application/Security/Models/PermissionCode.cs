using Bms.Core.Domain;
using Bms.WEBASE.Authorization;
using Bms.WEBASE.Translate;

namespace AutoPark.Application;

public enum PermissionCode
{
    #region INFO

    #region Country
    [PermissionCodeDescription(PermissionSubGroupCode.Country, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    CountryView,

    [PermissionCodeDescription(PermissionSubGroupCode.Country, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    CountryCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Country, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    CountryEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Country, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    CountryDelete,
    #endregion

    #region Bank
    [PermissionCodeDescription(PermissionSubGroupCode.Bank, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    BankView,

    [PermissionCodeDescription(PermissionSubGroupCode.Bank, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    BankCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Bank, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    BankEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Bank, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    BankDelete,
    #endregion

    #region FuelType
    [PermissionCodeDescription(PermissionSubGroupCode.FuelType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    FuelTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    FuelTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    FuelTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    FuelTypeDelete,
    #endregion

    #region InsuranceType
    [PermissionCodeDescription(PermissionSubGroupCode.InsuranceType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    InsuranceTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.InsuranceType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    InsuranceTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.InsuranceType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    InsuranceTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.InsuranceType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    InsuranceTypeDelete,
    #endregion

    #region Currency
    [PermissionCodeDescription(PermissionSubGroupCode.Currency, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    CurrencyView,

    [PermissionCodeDescription(PermissionSubGroupCode.Currency, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    CurrencyCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Currency, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    CurrencyEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Currency, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    CurrencyDelete,
    #endregion

    #region Citizenship
    [PermissionCodeDescription(PermissionSubGroupCode.Citizenship, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    CitizenshipView,

    [PermissionCodeDescription(PermissionSubGroupCode.Citizenship, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    CitizenshipCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Citizenship, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    CitizenshipEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Citizenship, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    CitizenshipDelete,
    #endregion

    #region ServiceType
    [PermissionCodeDescription(PermissionSubGroupCode.ServiceType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    ServiceTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    ServiceTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    ServiceTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    ServiceTypeDelete,
    #endregion

    #region Nationality
    [PermissionCodeDescription(PermissionSubGroupCode.Nationality, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    NationalityView,

    [PermissionCodeDescription(PermissionSubGroupCode.Nationality, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    NationalityCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Nationality, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    NationalityEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Nationality, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    NationalityDelete,
    #endregion

    #region District
    [PermissionCodeDescription(PermissionSubGroupCode.District, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DistrictView,

    [PermissionCodeDescription(PermissionSubGroupCode.District, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    DistrictCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.District, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    DistrictEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.District, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    DistrictDelete,
    #endregion

    #region Organization
    [PermissionCodeDescription(PermissionSubGroupCode.Organization, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View all")]
    OrganizationAllView,

    [PermissionCodeDescription(PermissionSubGroupCode.Organization, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    OrganizationView,

    [PermissionCodeDescription(PermissionSubGroupCode.Organization, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    OrganizationCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Organization, "Создать все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    OrganizationUpsertForAll,

    [PermissionCodeDescription(PermissionSubGroupCode.Organization, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    OrganizationEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Organization, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    OrganizationDelete,
    #endregion

    #region Region
    [PermissionCodeDescription(PermissionSubGroupCode.Region, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    RegionView,

    [PermissionCodeDescription(PermissionSubGroupCode.Region, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    RegionCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Region, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    RegionEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Region, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    RegionDelete,
    #endregion

    #region BatteryType
    [PermissionCodeDescription(PermissionSubGroupCode.BatteryType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    BatteryTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.BatteryType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    BatteryTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.BatteryType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    BatteryTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.BatteryType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    BatteryTypeDelete,

    #endregion

    #region Contractor
    [PermissionCodeDescription(PermissionSubGroupCode.Contractor, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    ContractorView,

    [PermissionCodeDescription(PermissionSubGroupCode.Contractor, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    ContractorCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Contractor, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    ContractorEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Contractor, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    ContractorDelete,
    #endregion

    #region TransportBrand
    [PermissionCodeDescription(PermissionSubGroupCode.TransportBrand, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TransportBrandView,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportBrand, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TransportBrandCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportBrand, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TransportBrandEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportBrand, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TransportBrandDelete,
    #endregion

    #region TransportColor
    [PermissionCodeDescription(PermissionSubGroupCode.TransportColor, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TransportColorView,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportColor, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TransportColorCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportColor, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TransportColorEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportColor, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TransportColorDelete,
    #endregion

    #region TransportType
    [PermissionCodeDescription(PermissionSubGroupCode.TransportType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TransportTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TransportTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TransportTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TransportTypeDelete,
    #endregion

    #region TransportUseType
    [PermissionCodeDescription(PermissionSubGroupCode.TransportUseType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TransportUseTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportUseType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TransportUseTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportUseType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TransportUseTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportUseType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TransportUseTypeDelete,
    #endregion

    #region TransportModel
    [PermissionCodeDescription(PermissionSubGroupCode.TransportModel, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TransportModelView,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportModel, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TransportModelCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportModel, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TransportModelEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportModel, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TransportModelDelete,
    #endregion

    #region OilType
    [PermissionCodeDescription(PermissionSubGroupCode.OilType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    OilTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.OilType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    OilTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.OilType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    OilTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.OilType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    OilTypeDelete,
    #endregion

    #region LiquidType
    [PermissionCodeDescription(PermissionSubGroupCode.LiquidType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    LiquidTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.LiquidType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    LiquidTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.LiquidType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    LiquidTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.LiquidType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    LiquidTypeDelete,
    #endregion

    #region OilModel
    [PermissionCodeDescription(PermissionSubGroupCode.OilModel, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    OilModelView,

    [PermissionCodeDescription(PermissionSubGroupCode.OilModel, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    OilModelCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.OilModel, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    OilModelEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.OilModel, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    OilModelDelete,
    #endregion

    #region TireModel
    [PermissionCodeDescription(PermissionSubGroupCode.TireModel, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TireModelView,

    [PermissionCodeDescription(PermissionSubGroupCode.TireModel, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TireModelCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.TireModel, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TireModelEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.TireModel, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TireModelDelete,
    #endregion

    #region TireSize
    [PermissionCodeDescription(PermissionSubGroupCode.TireSize, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TireSizeView,

    [PermissionCodeDescription(PermissionSubGroupCode.TireSize, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TireSizeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.TireSize, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TireSizeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.TireSize, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TireSizeDelete,
    #endregion

    #region MobileAppVersion
    [PermissionCodeDescription(PermissionSubGroupCode.MobileAppVersion, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    MobileAppVersionView,

    [PermissionCodeDescription(PermissionSubGroupCode.MobileAppVersion, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    MobileAppVersionCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.MobileAppVersion, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    MobileAppVersionEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.MobileAppVersion, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    MobileAppVersionDelete,
    #endregion

    #endregion

    #region HL

    #region Department
    [PermissionCodeDescription(PermissionSubGroupCode.Department, "Просмотреть все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотреть все")]
    [Translate(LanguageIdConst.EN, "View all")]
    DepartmentAllView,

    [PermissionCodeDescription(PermissionSubGroupCode.Department, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DepartmentView,

    [PermissionCodeDescription(PermissionSubGroupCode.Department, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    DepartmentCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Department, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    DepartmentEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Department, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    DepartmentDelete,
    #endregion

    #region Person
    [PermissionCodeDescription(PermissionSubGroupCode.Person, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    PersonView,

    [PermissionCodeDescription(PermissionSubGroupCode.Person, "Просмотреть все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотреть все")]
    [Translate(LanguageIdConst.EN, "View all")]
    ViewAllPerson,

    [PermissionCodeDescription(PermissionSubGroupCode.Person, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    PersonCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Person, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    PersonEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Person, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    PersonDelete,
    #endregion

    #region Position
    [PermissionCodeDescription(PermissionSubGroupCode.Position, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    PositionView,

    [PermissionCodeDescription(PermissionSubGroupCode.Position, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    PositionCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Position, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    PositionEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Position, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    PositionDelete,
    #endregion

    #region Transport
    [PermissionCodeDescription(PermissionSubGroupCode.Transport, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TransportView,

    [PermissionCodeDescription(PermissionSubGroupCode.Transport, "Просмотреть все в филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Филиалдаги барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Filialdagi barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [Translate(LanguageIdConst.EN, "View all in branch")]
    TransportBranchView,

    [PermissionCodeDescription(PermissionSubGroupCode.Transport, "Просмотреть все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотреть все")]
    [Translate(LanguageIdConst.EN, "View all")]
    AllViewTransport,

    [PermissionCodeDescription(PermissionSubGroupCode.Transport, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TransportCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Transport, "Создать для всех Филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [Translate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [Translate(LanguageIdConst.EN, "Create for all branches")]
    TransportCreateForAllBranch,

    [PermissionCodeDescription(PermissionSubGroupCode.Transport, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TransportEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Transport, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TransportDelete,
    #endregion

    #region Driver
    [PermissionCodeDescription(PermissionSubGroupCode.Driver, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DriverView,

    [PermissionCodeDescription(PermissionSubGroupCode.Driver, "Просмотреть все в филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Филиалдаги барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Filialdagi barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [Translate(LanguageIdConst.EN, "View all in branch")]
    DriverBranchView,

    [PermissionCodeDescription(PermissionSubGroupCode.Driver, "Просмотреть все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотреть все")]
    [Translate(LanguageIdConst.EN, "View all")]
    AllViewDriver,

    [PermissionCodeDescription(PermissionSubGroupCode.Driver, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    DriverCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Driver, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    DriverEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Driver, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    DriverDelete,
    #endregion

    #region FuelCard
    [PermissionCodeDescription(PermissionSubGroupCode.FuelCard, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    FuelCardView,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelCard, "Просмотр всех")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasibni ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр всех")]
    [Translate(LanguageIdConst.EN, "View all")]
    FuelCardViewAll,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelCard, "Просмотр в масштабе филиала")]
    [Translate(LanguageIdConst.UZ_CYRL, "Филиал миқёсида кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Filial miqyosida ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр в масштабе филиала")]
    [Translate(LanguageIdConst.EN, "Branch View")]
    FuelCardViewBranch,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelCard, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    FuelCardCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelCard, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    FuelCardEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelCard, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    FuelCardDelete,

    [PermissionCodeDescription(PermissionSubGroupCode.FuelCard, "Создать все ветки")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барча бранчларни ярата олиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barcha branchlarni yarata olish")]
    [Translate(LanguageIdConst.RU, "Создать все ветки")]
    [Translate(LanguageIdConst.EN, "Create FuelCard For All Branch")]
    CreateFuelCardForAllBranch,

    #endregion

    #region PresentTrackingInfo
    [PermissionCodeDescription(PermissionSubGroupCode.PresentTrackingInfo, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    PresentTrackingInfoView,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentTrackingInfo, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    PresentTrackingInfoCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentTrackingInfo, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    PresentTrackingInfoEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentTrackingInfo, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    PresentTrackingInfoDelete,
    #endregion

    #region TrackingInfo
    [PermissionCodeDescription(PermissionSubGroupCode.PresentTrackingInfo, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TrackingInfoView,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentTrackingInfo, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TrackingInfoCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentTrackingInfo, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TrackingInfoEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentTrackingInfo, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TrackingInfoDelete,
    #endregion

    #region Branch


    [PermissionCodeDescription(PermissionSubGroupCode.Branch, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View all")]
    BranchAllView,


    [PermissionCodeDescription(PermissionSubGroupCode.Branch, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    BranchView,

    [PermissionCodeDescription(PermissionSubGroupCode.Branch, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    BranchCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Branch, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    BranchEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Branch, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    BranchDelete,


    #endregion

    #region Notification

    [PermissionCodeDescription(PermissionSubGroupCode.Notification, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View all")]
    AllNotificationView,

    [PermissionCodeDescription(PermissionSubGroupCode.Notification, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    NotificationView,

    [PermissionCodeDescription(PermissionSubGroupCode.Notification, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    NotificationCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Notification, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    NotificationEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Notification, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    NotificationDelete,

    #endregion

    #region PresentNotification

    [PermissionCodeDescription(PermissionSubGroupCode.PresentNotification, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View all")]
    AllPresentNotificationView,


    [PermissionCodeDescription(PermissionSubGroupCode.PresentNotification, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    PresentNotificationView,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentNotification, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    PresentNotificationCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentNotification, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    PresentNotificationEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.PresentNotification, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    PresentNotificationDelete,

    #endregion

    #endregion

    #region DOC

    #region TransportSetting
    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    TransportSettingView,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View All")]
    TransportSettingViewAll,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Просмотр филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Филлял бўйича кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Fillyal bo'yicha ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр филиал")]
    [Translate(LanguageIdConst.EN, "View by branch")]
    TransportSettingViewByBranch,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Просмотр по водителю")]
    [Translate(LanguageIdConst.UZ_CYRL, "Хайдовчи бўйича кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Xaydovchi bo‘yicha ko‘rish")]
    [Translate(LanguageIdConst.RU, "Просмотр по водителю")]
    [Translate(LanguageIdConst.EN, "View by driver")]
    TransportSettingViewByDriver,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    TransportSettingCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    TransportSettingEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Принимать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Қабул қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Qabul qilish")]
    [Translate(LanguageIdConst.RU, "Принимать")]
    [Translate(LanguageIdConst.EN, "Accept")]
    TransportSettingAccept,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Отмена")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отмена")]
    [Translate(LanguageIdConst.EN, "Cancel")]
    TransportSettingCancel,

    [PermissionCodeDescription(PermissionSubGroupCode.TransportSetting, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    TransportSettingDelete,
    #endregion


    #region Refuel
    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Просмотреть все в филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [Translate(LanguageIdConst.EN, "View All")]
    RefuelBranchView,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View All")]
    RefuelViewAll,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    RefuelView,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    RefuelCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    RefuelEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    RefuelDelete,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Принятие")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [Translate(LanguageIdConst.RU, "Принятие")]
    [Translate(LanguageIdConst.EN, "Accept")]
    RefuelAccept,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Отменить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отменить")]
    [Translate(LanguageIdConst.EN, "Cancel")]
    RefuelCancel,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Oтправлять")]
    [Translate(LanguageIdConst.UZ_CYRL, "Юбориш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [Translate(LanguageIdConst.RU, "Oтправлять")]
    [Translate(LanguageIdConst.EN, "Send")]
    RefuelSend,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Отозвать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отозвать")]
    [Translate(LanguageIdConst.EN, "Revoke")]
    RefuelRevoke,

    [PermissionCodeDescription(PermissionSubGroupCode.Refuel, "Создать для всех Филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [Translate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [Translate(LanguageIdConst.EN, "Create for all branches")]
    RefuelCreateForAllBranch,

    //.... Boshqa statuslar davom etadi shu yerdan
    #endregion

    #region Expense
    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View All")]
    AllViewExpense,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    ExpenseView,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    ExpenseCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    ExpenseEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    ExpenseDelete,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Принятие")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [Translate(LanguageIdConst.RU, "Принятие")]
    [Translate(LanguageIdConst.EN, "Accept")]
    ExpenseAccept,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Отменить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отменить")]
    [Translate(LanguageIdConst.EN, "Cancel")]
    ExpenselCancel,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Oтправлять")]
    [Translate(LanguageIdConst.UZ_CYRL, "Юбориш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [Translate(LanguageIdConst.RU, "Oтправлять")]
    [Translate(LanguageIdConst.EN, "Send")]
    ExpenseSend,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Отменить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отменить")]
    [Translate(LanguageIdConst.EN, "Revoke")]
    ExpenseRevoke,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Создать для всех Филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [Translate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [Translate(LanguageIdConst.EN, "Create for all branches")]
    ExpenseCreateForAllBranch,

    [PermissionCodeDescription(PermissionSubGroupCode.Expense, "Прикрепить счет-фактуру")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳисоб-фактура бириктириш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hisob-faktura biriktirish")]
    [Translate(LanguageIdConst.RU, "Прикрепить счет-фактуру")]
    [Translate(LanguageIdConst.EN, "Invoice attach")]
    InvoiceAttach,
    #endregion

    #region NotificationTemplateSetting
    [PermissionCodeDescription(PermissionSubGroupCode.NotificationTemplateSetting, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View All")]
    AllNotificationTemplateSettingView,

    [PermissionCodeDescription(PermissionSubGroupCode.NotificationTemplateSetting, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    NotificationTemplateSettingView,

    [PermissionCodeDescription(PermissionSubGroupCode.NotificationTemplateSetting, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    NotificationTemplateSettingCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.NotificationTemplateSetting, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    NotificationTemplateSettingEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.NotificationTemplateSetting, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    NotificationTemplateSettingDelete,

    [PermissionCodeDescription(PermissionSubGroupCode.NotificationTemplateSetting, "Принятие")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [Translate(LanguageIdConst.RU, "Принятие")]
    [Translate(LanguageIdConst.EN, "Accept")]
    NotificationTemplateSettingAccept,

    [PermissionCodeDescription(PermissionSubGroupCode.NotificationTemplateSetting, "Отменить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отменить")]
    [Translate(LanguageIdConst.EN, "Cancel")]
    NotificationTemplateSettingCancel,

    [PermissionCodeDescription(PermissionSubGroupCode.NotificationTemplateSetting, "Создать для всех Филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [Translate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [Translate(LanguageIdConst.EN, "Create for all branches")]
    NotificationTemplateSettingCreateForAllBranch,
    #endregion

    #endregion

    #region SYS

    #region Role
    [PermissionCodeDescription(PermissionSubGroupCode.Role, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    RoleView,

    [PermissionCodeDescription(PermissionSubGroupCode.Role, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    RoleCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Role, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    RoleEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Role, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    RoleDelete,
    #endregion

    #region User
    [PermissionCodeDescription(PermissionSubGroupCode.User, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    UserView,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    UserCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    UserEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    UserDelete,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View all")]
    AllUserView,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Создать все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini yaratish")]
    [Translate(LanguageIdConst.RU, "Создать все")]
    [Translate(LanguageIdConst.EN, "Create all")]
    AllUserCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Редактировать все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать все")]
    [Translate(LanguageIdConst.EN, "Edit all")]
    AllUserEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Удалить все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini o'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить все")]
    [Translate(LanguageIdConst.EN, "Delete all")]
    AllUserDelete,
    #endregion
    #endregion

    #region REPORT

    #region DriverPenalty
    [PermissionCodeDescription(PermissionSubGroupCode.DriverPenalty, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DriverPenaltyView,

    [PermissionCodeDescription(PermissionSubGroupCode.DriverPenalty, "Просмотр (Только собственный филиал)")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш (Фақат ўз филиали)")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish (Faqat o'z filiali)")]
    [Translate(LanguageIdConst.RU, "Просмотр (Только собственный филиал)")]
    [Translate(LanguageIdConst.EN, "View branch")]
    DriverPenaltyBranchView,

    [PermissionCodeDescription(PermissionSubGroupCode.DriverPenalty, "Просмотр (Все филиалы)")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш (Барча филиаллар)")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish (Barcha filiallar)")]
    [Translate(LanguageIdConst.RU, "Просмотр (Все филиалы)")]
    [Translate(LanguageIdConst.EN, "View All")]
    DriverPenaltyAllView,

    [PermissionCodeDescription(PermissionSubGroupCode.DriverPenalty, "Оплата штрафа")]
    [Translate(LanguageIdConst.UZ_CYRL, "Жарима учун тўлов")]
    [Translate(LanguageIdConst.UZ_LATN, "Jarima uchun to'lov")]
    [Translate(LanguageIdConst.RU, "Оплата штрафа")]
    [Translate(LanguageIdConst.EN, "Driver penalty pay")]
    DriverPenaltyPay,
    #endregion

    [PermissionCodeDescription(PermissionSubGroupCode.OptimalRoute, "Оплата штрафа")]
    [Translate(LanguageIdConst.UZ_CYRL, "Жарима учун тўлов")]
    [Translate(LanguageIdConst.UZ_LATN, "Jarima uchun to'lov")]
    [Translate(LanguageIdConst.RU, "Оплата штрафа")]
    [Translate(LanguageIdConst.EN, "Driver penalty pay")]
    OptimalRoute,

    #region ExpenseReport
    [PermissionCodeDescription(PermissionSubGroupCode.ExpenseReport, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    ExpenseReportView,

    [PermissionCodeDescription(PermissionSubGroupCode.DriverPenalty, "Просмотр (Только собственный филиал)")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш (Фақат ўз филиали)")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish (Faqat o'z filiali)")]
    [Translate(LanguageIdConst.RU, "Просмотр (Только собственный филиал)")]
    [Translate(LanguageIdConst.EN, "View branch")]
    ExpenseReportBranchView,

    [PermissionCodeDescription(PermissionSubGroupCode.DriverPenalty, "Просмотр (Все филиалы)")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш (Барча филиаллар)")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish (Barcha filiallar)")]
    [Translate(LanguageIdConst.RU, "Просмотр (Все филиалы)")]
    [Translate(LanguageIdConst.EN, "View All")]
    ExpenseReportAllView,
    #endregion

    #endregion


    #region For Developers
    [PermissionCodeDescription(PermissionSubGroupCode.Developer, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    AppErrorView,
    [PermissionCodeDescription(PermissionSubGroupCode.Developer, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    AppErrorEdit,
    #endregion
}