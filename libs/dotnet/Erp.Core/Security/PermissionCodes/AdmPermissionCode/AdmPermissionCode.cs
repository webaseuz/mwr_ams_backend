using WEBASE;

namespace Erp.Core;

[WbPermissionEnum(AppIdConst.ADM)]
public enum AdmPermissionCode
{
    #region INFO

    #region Country
    [WbPermissionField(AdmPermissionSubGroupCode.Country, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CountryView,

    [WbPermissionField(AdmPermissionSubGroupCode.Country, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CountryCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Country, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CountryEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Country, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CountryDelete,
    #endregion

    #region Bank
    [WbPermissionField(AdmPermissionSubGroupCode.Bank, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    BankView,

    [WbPermissionField(AdmPermissionSubGroupCode.Bank, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    BankCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Bank, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    BankEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Bank, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    BankDelete,
    #endregion

    #region FuelType
    [WbPermissionField(AdmPermissionSubGroupCode.FuelType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    FuelTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    FuelTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    FuelTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    FuelTypeDelete,
    #endregion

    #region InsuranceType
    [WbPermissionField(AdmPermissionSubGroupCode.InsuranceType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    InsuranceTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.InsuranceType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    InsuranceTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.InsuranceType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    InsuranceTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.InsuranceType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    InsuranceTypeDelete,
    #endregion

    #region Currency
    [WbPermissionField(AdmPermissionSubGroupCode.Currency, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CurrencyView,

    [WbPermissionField(AdmPermissionSubGroupCode.Currency, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CurrencyCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Currency, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CurrencyEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Currency, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CurrencyDelete,
    #endregion

    #region Citizenship
    [WbPermissionField(AdmPermissionSubGroupCode.Citizenship, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CitizenshipView,

    [WbPermissionField(AdmPermissionSubGroupCode.Citizenship, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CitizenshipCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Citizenship, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CitizenshipEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Citizenship, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CitizenshipDelete,
    #endregion

    #region ServiceType
    [WbPermissionField(AdmPermissionSubGroupCode.ServiceType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ServiceTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.ServiceType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ServiceTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.ServiceType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ServiceTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.ServiceType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ServiceTypeDelete,
    #endregion

    #region Nationality
    [WbPermissionField(AdmPermissionSubGroupCode.Nationality, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    NationalityView,

    [WbPermissionField(AdmPermissionSubGroupCode.Nationality, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    NationalityCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Nationality, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    NationalityEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Nationality, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    NationalityDelete,
    #endregion

    #region District
    [WbPermissionField(AdmPermissionSubGroupCode.District, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DistrictView,

    [WbPermissionField(AdmPermissionSubGroupCode.District, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DistrictCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.District, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DistrictEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.District, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DistrictDelete,
    #endregion

    #region Organization
    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    OrganizationAllView,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OrganizationView,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Создать все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationUpsertForAll,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OrganizationEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OrganizationDelete,
    #endregion

    #region Region
    [WbPermissionField(AdmPermissionSubGroupCode.Region, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RegionView,

    [WbPermissionField(AdmPermissionSubGroupCode.Region, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RegionCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Region, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RegionEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Region, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RegionDelete,
    #endregion

    #region BatteryType
    [WbPermissionField(AdmPermissionSubGroupCode.BatteryType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    BatteryTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.BatteryType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    BatteryTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.BatteryType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    BatteryTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.BatteryType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    BatteryTypeDelete,

    #endregion

    #region Contractor
    [WbPermissionField(AdmPermissionSubGroupCode.Contractor, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ContractorView,

    [WbPermissionField(AdmPermissionSubGroupCode.Contractor, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ContractorCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Contractor, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ContractorEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Contractor, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ContractorDelete,
    #endregion

    #region TransportBrand
    [WbPermissionField(AdmPermissionSubGroupCode.TransportBrand, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportBrandView,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportBrand, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportBrandCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportBrand, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportBrandEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportBrand, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportBrandDelete,
    #endregion

    #region TransportColor
    [WbPermissionField(AdmPermissionSubGroupCode.TransportColor, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportColorView,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportColor, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportColorCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportColor, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportColorEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportColor, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportColorDelete,
    #endregion

    #region TransportType
    [WbPermissionField(AdmPermissionSubGroupCode.TransportType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportTypeDelete,
    #endregion

    #region TransportUseType
    [WbPermissionField(AdmPermissionSubGroupCode.TransportUseType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportUseTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportUseType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportUseTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportUseType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportUseTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportUseType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportUseTypeDelete,
    #endregion

    #region TransportModel
    [WbPermissionField(AdmPermissionSubGroupCode.TransportModel, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportModelView,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportModel, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportModelCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportModel, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportModelEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportModel, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportModelDelete,
    #endregion

    #region OilType
    [WbPermissionField(AdmPermissionSubGroupCode.OilType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OilTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.OilType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OilTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.OilType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OilTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.OilType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OilTypeDelete,
    #endregion

    #region LiquidType
    [WbPermissionField(AdmPermissionSubGroupCode.LiquidType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    LiquidTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.LiquidType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    LiquidTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.LiquidType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    LiquidTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.LiquidType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    LiquidTypeDelete,
    #endregion

    #region OilModel
    [WbPermissionField(AdmPermissionSubGroupCode.OilModel, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OilModelView,

    [WbPermissionField(AdmPermissionSubGroupCode.OilModel, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OilModelCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.OilModel, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OilModelEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.OilModel, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OilModelDelete,
    #endregion

    #region TireModel
    [WbPermissionField(AdmPermissionSubGroupCode.TireModel, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TireModelView,

    [WbPermissionField(AdmPermissionSubGroupCode.TireModel, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TireModelCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.TireModel, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TireModelEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.TireModel, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TireModelDelete,
    #endregion

    #region TireSize
    [WbPermissionField(AdmPermissionSubGroupCode.TireSize, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TireSizeView,

    [WbPermissionField(AdmPermissionSubGroupCode.TireSize, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TireSizeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.TireSize, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TireSizeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.TireSize, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TireSizeDelete,
    #endregion

    #region MobileAppVersion
    [WbPermissionField(AdmPermissionSubGroupCode.MobileAppVersion, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    MobileAppVersionView,

    [WbPermissionField(AdmPermissionSubGroupCode.MobileAppVersion, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    MobileAppVersionCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.MobileAppVersion, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    MobileAppVersionEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.MobileAppVersion, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    MobileAppVersionDelete,
    #endregion

    #endregion

    #region HL

    #region Department
    [WbPermissionField(AdmPermissionSubGroupCode.Department, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    DepartmentAllView,

    [WbPermissionField(AdmPermissionSubGroupCode.Department, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DepartmentView,

    [WbPermissionField(AdmPermissionSubGroupCode.Department, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DepartmentCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Department, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DepartmentEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Department, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DepartmentDelete,
    #endregion

    #region Person
    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PersonView,

    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    ViewAllPerson,

    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PersonCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PersonEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PersonDelete,
    #endregion

    #region Position
    [WbPermissionField(AdmPermissionSubGroupCode.Position, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PositionView,

    [WbPermissionField(AdmPermissionSubGroupCode.Position, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PositionCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Position, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PositionEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Position, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PositionDelete,
    #endregion

    #region Transport
    [WbPermissionField(AdmPermissionSubGroupCode.Transport, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportView,

    [WbPermissionField(AdmPermissionSubGroupCode.Transport, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филиалдаги барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filialdagi barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.EN, "View all in branch")]
    TransportBranchView,

    [WbPermissionField(AdmPermissionSubGroupCode.Transport, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllViewTransport,

    [WbPermissionField(AdmPermissionSubGroupCode.Transport, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Transport, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    TransportCreateForAllBranch,

    [WbPermissionField(AdmPermissionSubGroupCode.Transport, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Transport, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportDelete,
    #endregion

    #region Driver
    [WbPermissionField(AdmPermissionSubGroupCode.Driver, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DriverView,

    [WbPermissionField(AdmPermissionSubGroupCode.Driver, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филиалдаги барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filialdagi barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.EN, "View all in branch")]
    DriverBranchView,

    [WbPermissionField(AdmPermissionSubGroupCode.Driver, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllViewDriver,

    [WbPermissionField(AdmPermissionSubGroupCode.Driver, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DriverCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Driver, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DriverEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Driver, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DriverDelete,
    #endregion

    #region FuelCard
    [WbPermissionField(AdmPermissionSubGroupCode.FuelCard, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    FuelCardView,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelCard, "Просмотр всех")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasibni ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр всех")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    FuelCardViewAll,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelCard, "Просмотр в масштабе филиала")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филиал миқёсида кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filial miqyosida ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр в масштабе филиала")]
    [WbTranslate(LanguageIdConst.EN, "Branch View")]
    FuelCardViewBranch,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelCard, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    FuelCardCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelCard, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    FuelCardEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelCard, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    FuelCardDelete,

    [WbPermissionField(AdmPermissionSubGroupCode.FuelCard, "Создать все ветки")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барча бранчларни ярата олиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barcha branchlarni yarata olish")]
    [WbTranslate(LanguageIdConst.RU, "Создать все ветки")]
    [WbTranslate(LanguageIdConst.EN, "Create FuelCard For All Branch")]
    CreateFuelCardForAllBranch,

    #endregion

    #region PresentTrackingInfo
    [WbPermissionField(AdmPermissionSubGroupCode.PresentTrackingInfo, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PresentTrackingInfoView,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentTrackingInfo, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PresentTrackingInfoCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentTrackingInfo, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PresentTrackingInfoEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentTrackingInfo, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PresentTrackingInfoDelete,
    #endregion

    #region TrackingInfo
    [WbPermissionField(AdmPermissionSubGroupCode.PresentTrackingInfo, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TrackingInfoView,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentTrackingInfo, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TrackingInfoCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentTrackingInfo, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TrackingInfoEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentTrackingInfo, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TrackingInfoDelete,
    #endregion

    #region Branch


    [WbPermissionField(AdmPermissionSubGroupCode.Branch, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    BranchAllView,


    [WbPermissionField(AdmPermissionSubGroupCode.Branch, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    BranchView,

    [WbPermissionField(AdmPermissionSubGroupCode.Branch, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    BranchCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Branch, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    BranchEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Branch, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    BranchDelete,


    #endregion

    #region Notification

    [WbPermissionField(AdmPermissionSubGroupCode.Notification, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllNotificationView,

    [WbPermissionField(AdmPermissionSubGroupCode.Notification, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    NotificationView,

    [WbPermissionField(AdmPermissionSubGroupCode.Notification, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    NotificationCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Notification, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    NotificationEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Notification, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    NotificationDelete,

    #endregion

    #region PresentNotification

    [WbPermissionField(AdmPermissionSubGroupCode.PresentNotification, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllPresentNotificationView,


    [WbPermissionField(AdmPermissionSubGroupCode.PresentNotification, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PresentNotificationView,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentNotification, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PresentNotificationCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentNotification, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PresentNotificationEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.PresentNotification, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PresentNotificationDelete,

    #endregion

    #endregion

    #region DOC

    #region TransportSetting
    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportSettingView,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    TransportSettingViewAll,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Просмотр филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филлял бўйича кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Fillyal bo'yicha ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр филиал")]
    [WbTranslate(LanguageIdConst.EN, "View by branch")]
    TransportSettingViewByBranch,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Просмотр по водителю")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Хайдовчи бўйича кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Xaydovchi bo‘yicha ko‘rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр по водителю")]
    [WbTranslate(LanguageIdConst.EN, "View by driver")]
    TransportSettingViewByDriver,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportSettingCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportSettingEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Принимать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Қабул қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Qabul qilish")]
    [WbTranslate(LanguageIdConst.RU, "Принимать")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    TransportSettingAccept,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Отмена")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отмена")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    TransportSettingCancel,

    [WbPermissionField(AdmPermissionSubGroupCode.TransportSetting, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportSettingDelete,
    #endregion


    #region Refuel
    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    RefuelBranchView,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    RefuelViewAll,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RefuelView,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RefuelCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RefuelEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RefuelDelete,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Принятие")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [WbTranslate(LanguageIdConst.RU, "Принятие")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    RefuelAccept,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Отменить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отменить")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    RefuelCancel,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Oтправлять")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Юбориш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [WbTranslate(LanguageIdConst.RU, "Oтправлять")]
    [WbTranslate(LanguageIdConst.EN, "Send")]
    RefuelSend,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Отозвать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отозвать")]
    [WbTranslate(LanguageIdConst.EN, "Revoke")]
    RefuelRevoke,

    [WbPermissionField(AdmPermissionSubGroupCode.Refuel, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    RefuelCreateForAllBranch,

    //.... Boshqa statuslar davom etadi shu yerdan
    #endregion

    #region Expense
    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    AllViewExpense,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ExpenseView,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ExpenseCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ExpenseEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ExpenseDelete,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Принятие")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [WbTranslate(LanguageIdConst.RU, "Принятие")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    ExpenseAccept,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Отменить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отменить")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    ExpenselCancel,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Oтправлять")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Юбориш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [WbTranslate(LanguageIdConst.RU, "Oтправлять")]
    [WbTranslate(LanguageIdConst.EN, "Send")]
    ExpenseSend,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Отменить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отменить")]
    [WbTranslate(LanguageIdConst.EN, "Revoke")]
    ExpenseRevoke,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    ExpenseCreateForAllBranch,

    [WbPermissionField(AdmPermissionSubGroupCode.Expense, "Прикрепить счет-фактуру")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳисоб-фактура бириктириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hisob-faktura biriktirish")]
    [WbTranslate(LanguageIdConst.RU, "Прикрепить счет-фактуру")]
    [WbTranslate(LanguageIdConst.EN, "Invoice attach")]
    InvoiceAttach,
    #endregion

    #region NotificationTemplateSetting
    [WbPermissionField(AdmPermissionSubGroupCode.NotificationTemplateSetting, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    AllNotificationTemplateSettingView,

    [WbPermissionField(AdmPermissionSubGroupCode.NotificationTemplateSetting, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    NotificationTemplateSettingView,

    [WbPermissionField(AdmPermissionSubGroupCode.NotificationTemplateSetting, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    NotificationTemplateSettingCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.NotificationTemplateSetting, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    NotificationTemplateSettingEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.NotificationTemplateSetting, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    NotificationTemplateSettingDelete,

    [WbPermissionField(AdmPermissionSubGroupCode.NotificationTemplateSetting, "Принятие")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [WbTranslate(LanguageIdConst.RU, "Принятие")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    NotificationTemplateSettingAccept,

    [WbPermissionField(AdmPermissionSubGroupCode.NotificationTemplateSetting, "Отменить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отменить")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    NotificationTemplateSettingCancel,

    [WbPermissionField(AdmPermissionSubGroupCode.NotificationTemplateSetting, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    NotificationTemplateSettingCreateForAllBranch,
    #endregion

    #endregion

    #region SYS

    #region Role
    [WbPermissionField(AdmPermissionSubGroupCode.Role, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RoleView,

    [WbPermissionField(AdmPermissionSubGroupCode.Role, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RoleCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Role, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RoleEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Role, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RoleDelete,
    #endregion

    #region User
    [WbPermissionField(AdmPermissionSubGroupCode.User, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    UserView,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    UserCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    UserEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    UserDelete,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllUserView,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Создать все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать все")]
    [WbTranslate(LanguageIdConst.EN, "Create all")]
    AllUserCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Редактировать все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать все")]
    [WbTranslate(LanguageIdConst.EN, "Edit all")]
    AllUserEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Удалить все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini o'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить все")]
    [WbTranslate(LanguageIdConst.EN, "Delete all")]
    AllUserDelete,
    #endregion
    #endregion

    #region REPORT

    #region DriverPenalty
    [WbPermissionField(AdmPermissionSubGroupCode.DriverPenalty, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DriverPenaltyView,

    [WbPermissionField(AdmPermissionSubGroupCode.DriverPenalty, "Просмотр (Только собственный филиал)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш (Фақат ўз филиали)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Faqat o'z filiali)")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр (Только собственный филиал)")]
    [WbTranslate(LanguageIdConst.EN, "View branch")]
    DriverPenaltyBranchView,

    [WbPermissionField(AdmPermissionSubGroupCode.DriverPenalty, "Просмотр (Все филиалы)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш (Барча филиаллар)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Barcha filiallar)")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр (Все филиалы)")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    DriverPenaltyAllView,

    [WbPermissionField(AdmPermissionSubGroupCode.DriverPenalty, "Оплата штрафа")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Жарима учун тўлов")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Jarima uchun to'lov")]
    [WbTranslate(LanguageIdConst.RU, "Оплата штрафа")]
    [WbTranslate(LanguageIdConst.EN, "Driver penalty pay")]
    DriverPenaltyPay,
    #endregion

    [WbPermissionField(AdmPermissionSubGroupCode.OptimalRoute, "Оплата штрафа")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Жарима учун тўлов")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Jarima uchun to'lov")]
    [WbTranslate(LanguageIdConst.RU, "Оплата штрафа")]
    [WbTranslate(LanguageIdConst.EN, "Driver penalty pay")]
    OptimalRoute,

    #region ExpenseReport
    [WbPermissionField(AdmPermissionSubGroupCode.ExpenseReport, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ExpenseReportView,

    [WbPermissionField(AdmPermissionSubGroupCode.DriverPenalty, "Просмотр (Только собственный филиал)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш (Фақат ўз филиали)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Faqat o'z filiali)")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр (Только собственный филиал)")]
    [WbTranslate(LanguageIdConst.EN, "View branch")]
    ExpenseReportBranchView,

    [WbPermissionField(AdmPermissionSubGroupCode.DriverPenalty, "Просмотр (Все филиалы)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш (Барча филиаллар)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Barcha filiallar)")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр (Все филиалы)")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    ExpenseReportAllView,
    #endregion

    #endregion


    #region For Developers
    [WbPermissionField(AdmPermissionSubGroupCode.Developer, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    AppErrorView,
    [WbPermissionField(AdmPermissionSubGroupCode.Developer, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    AppErrorEdit,
    #endregion
}
