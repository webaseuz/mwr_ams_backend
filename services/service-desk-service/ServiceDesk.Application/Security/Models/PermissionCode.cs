using Bms.Core.Domain;
using Bms.WEBASE.Authorization;
using Bms.WEBASE.Translate;

namespace ServiceDesk.Application;

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

    #region DeviceType
    [PermissionCodeDescription(PermissionSubGroupCode.DeviceType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DeviceTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    DeviceTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    DeviceTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    DeviceTypeDelete,
    #endregion

    #region DeviceModel
    [PermissionCodeDescription(PermissionSubGroupCode.DeviceModel, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DeviceModelView,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceModel, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    DeviceModelCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceModel, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    DeviceModelEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceModel, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    DeviceModelDelete,
    #endregion

    #region ApplicationPurpose
    [PermissionCodeDescription(PermissionSubGroupCode.ApplicationPurpose, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    ApplicationPurposeView,

    [PermissionCodeDescription(PermissionSubGroupCode.ApplicationPurpose, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    ApplicationPurposeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.ApplicationPurpose, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    ApplicationPurposeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.ApplicationPurpose, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    ApplicationPurposeDelete,
    #endregion
    #region DevicePart
    [PermissionCodeDescription(PermissionSubGroupCode.DevicePart, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DevicePartView,

    [PermissionCodeDescription(PermissionSubGroupCode.DevicePart, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    DDevicePartCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.DevicePart, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    DevicePartEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.DevicePart, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    DevicePartDelete,
    #endregion

    #region DeviceSpareType
    [PermissionCodeDescription(PermissionSubGroupCode.DeviceSpareType, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DeviceSpareTypeView,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceSpareType, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    DeviceSpareTypeCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceSpareType, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    DeviceSpareTypeEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.DeviceSpareType, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    DeviceSpareTypeDelete,
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

    #region Device
    [PermissionCodeDescription(PermissionSubGroupCode.Device, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View all")]
    DeviceViewAll,

    [PermissionCodeDescription(PermissionSubGroupCode.Device, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    DeviceView,

    [PermissionCodeDescription(PermissionSubGroupCode.Device, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    DeviceCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.Device, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    DeviceEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.Device, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    DeviceDelete,
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

    #endregion

    #region DOC

    #region ServiceApplication
    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View All")]
    AllViewServiceApplication,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    ServiceApplicationView,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    ServiceApplicationCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    ServiceApplicationEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    ServiceApplicationDelete,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Принятие")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [Translate(LanguageIdConst.RU, "Принятие")]
    [Translate(LanguageIdConst.EN, "Accept")]
    ServiceApplicationAccept,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Отменить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отменить")]
    [Translate(LanguageIdConst.EN, "Cancel")]
    ServiceApplicationCancel,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Oтправлять")]
    [Translate(LanguageIdConst.UZ_CYRL, "Юбориш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [Translate(LanguageIdConst.RU, "Oтправлять")]
    [Translate(LanguageIdConst.EN, "Send")]
    ServiceApplicationSend,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Отозвать ")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отозвать ")]
    [Translate(LanguageIdConst.EN, "Revoke")]
    ServiceApplicationRevoke,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "В процессе")]
    [Translate(LanguageIdConst.UZ_CYRL, "Жараёнда")]
    [Translate(LanguageIdConst.UZ_LATN, "Jarayonda")]
    [Translate(LanguageIdConst.RU, "В процессе")]
    [Translate(LanguageIdConst.EN, "In Process")]
    ServiceApplicationInProcess,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Завершено")]
    [Translate(LanguageIdConst.UZ_CYRL, "Тугалланган")]
    [Translate(LanguageIdConst.UZ_LATN, "Tugallangan")]
    [Translate(LanguageIdConst.RU, "Завершено")]
    [Translate(LanguageIdConst.EN, "Finished")]
    ServiceApplicationFinished,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Отменено исполнителем")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бажарувчи томонидан бекор қилинган")]
    [Translate(LanguageIdConst.UZ_LATN, "Bajaruvchi tomonidan bekor qilingan")]
    [Translate(LanguageIdConst.RU, "Отменено исполнителем")]
    [Translate(LanguageIdConst.EN, "Canceled by executor")]
    ServiceApplicationCancelByExecutor,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Завершено исполнителем")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бажарувчи томонидан якунланган")]
    [Translate(LanguageIdConst.UZ_LATN, "Bajaruvchi tomonidan yakunlangan")]
    [Translate(LanguageIdConst.RU, "Завершено исполнителем")]
    [Translate(LanguageIdConst.EN, "Finished by executor")]
    ServiceApplicationFinishByExecutor,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Отменено клиентом")]
    [Translate(LanguageIdConst.UZ_CYRL, "Мижоз томонидан бекор қилинган")]
    [Translate(LanguageIdConst.UZ_LATN, "Mijoz tomonidan bekor qilingan")]
    [Translate(LanguageIdConst.RU, "Отменено клиентом")]
    [Translate(LanguageIdConst.EN, "Canceled by client")]
    ServiceApplicationCancelByClient,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Ожидание запчастей")]
    [Translate(LanguageIdConst.UZ_CYRL, "Эҳтиёт қисмлар кутиляпти")]
    [Translate(LanguageIdConst.UZ_LATN, "Ehtiyot qismlar kutilyapti")]
    [Translate(LanguageIdConst.RU, "Ожидание запчастей")]
    [Translate(LanguageIdConst.EN, "Wait Spares")]
    ServiceApplicationWaitSpares,

    [PermissionCodeDescription(PermissionSubGroupCode.ServiceApplication, "Неуспешный")]
    [Translate(LanguageIdConst.UZ_CYRL, "Муваффақиятсиз")]
    [Translate(LanguageIdConst.UZ_LATN, "Muvaffaqiyatsiz")]
    [Translate(LanguageIdConst.RU, "Неуспешный")]
    [Translate(LanguageIdConst.EN, "Fail")]
    ServiceApplicationFail,
    #endregion

    #region SpareMovement
    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Просмотр все")]
    [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр все")]
    [Translate(LanguageIdConst.EN, "View all")]
    SpareMovementAllView,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Просмотр")]
    [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр")]
    [Translate(LanguageIdConst.EN, "View")]
    SpareMovementView,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Создать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [Translate(LanguageIdConst.RU, "Создать")]
    [Translate(LanguageIdConst.EN, "Create")]
    SpareMovementCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Редактировать")]
    [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать")]
    [Translate(LanguageIdConst.EN, "Edit")]
    SpareMovementEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Удалить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить")]
    [Translate(LanguageIdConst.EN, "Delete")]
    SpareMovementDelete,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Принятие")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [Translate(LanguageIdConst.RU, "Принятие")]
    [Translate(LanguageIdConst.EN, "Accept")]
    SpareMovementAccept,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Отменить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отменить")]
    [Translate(LanguageIdConst.EN, "Cancel")]
    SpareMovementCancel,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Oтправлять")]
    [Translate(LanguageIdConst.UZ_CYRL, "Юбориш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [Translate(LanguageIdConst.RU, "Oтправлять")]
    [Translate(LanguageIdConst.EN, "Send")]
    SpareMovementSend,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareMovement, "Отменить")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [Translate(LanguageIdConst.RU, "Отменить")]
    [Translate(LanguageIdConst.EN, "Revoke")]
    SpareMovementRevoke,
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

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Просмотр по подразделениям")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бўлимлар бўйича кўриш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bo'limlar bo'yicha ko'rish")]
    [Translate(LanguageIdConst.RU, "Просмотр по подразделениям")]
    [Translate(LanguageIdConst.EN, "View by branches")]
    BranchView,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Создать по подразделениям")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бўлимлар бўйича яратиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bo'limlar bo'yicha yaratish")]
    [Translate(LanguageIdConst.RU, "Создать по подразделениям")]
    [Translate(LanguageIdConst.EN, "Create by branches")]
    BranchCreate,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Редактировать по подразделениям")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бўлимлар бўйича таҳрирлаш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bo'limlar bo'yicha tahrirlash")]
    [Translate(LanguageIdConst.RU, "Редактировать по подразделениям")]
    [Translate(LanguageIdConst.EN, "Edit by branches")]
    BranchEdit,

    [PermissionCodeDescription(PermissionSubGroupCode.User, "Удалить по подразделениям")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бўлимлар бўйича ўчириш")]
    [Translate(LanguageIdConst.UZ_LATN, "Bo'limlar bo'yicha o'chirish")]
    [Translate(LanguageIdConst.RU, "Удалить по подразделениям")]
    [Translate(LanguageIdConst.EN, "Delete by branches")]
    BranchDelete,

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
    #region SpareTurnover
        [PermissionCodeDescription(PermissionSubGroupCode.SpareTurnover, "Просмотр по филиалу")]
        [Translate(LanguageIdConst.UZ_CYRL, "Филиал бўйича кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Filial bo‘yicha ko‘rish")]
        [Translate(LanguageIdConst.RU, "Просмотр по филиалу")]
        [Translate(LanguageIdConst.EN, "View by Branch")]
        SpareTurnoverReportBranchView,

    [PermissionCodeDescription(PermissionSubGroupCode.SpareTurnover, "Просмотр все")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр все")]
        [Translate(LanguageIdConst.EN, "View All")]
        SpareTurnoverReportAllView,

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