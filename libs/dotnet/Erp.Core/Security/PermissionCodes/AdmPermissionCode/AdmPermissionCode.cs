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
