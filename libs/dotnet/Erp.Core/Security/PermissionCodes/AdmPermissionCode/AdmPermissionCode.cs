using WEBASE;

namespace Erp.Core;

[WbPermissionEnum(AppIdConst.ADM)]
public enum AdmPermissionCode
{
    #region AppError
    [WbPermissionField(AdmPermissionSubGroupCode.AppError, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    AppErrorView,
    #endregion

    #region RepublicLevel

    [WbPermissionField(AdmPermissionSubGroupCode.RoleLevel, "Республика даражасини кўриш Admin")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Республика даражасини кўриш Admin")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Respublika darajasini ko‘rish Admin")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр уровня республики (Admin)")]
    [WbTranslate(LanguageIdConst.EN, "Admin — Republic Level")]
    RepublicLevelAdmin,

    [WbPermissionField(AdmPermissionSubGroupCode.RoleLevel, "Республика даражасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Республика даражасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Respublika darajasini ko‘rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр уровня республики")]
    [WbTranslate(LanguageIdConst.EN, "View Republic Level")]
    RepublicLevelView,
    #endregion


    #region RegionLevel

    [WbPermissionField(AdmPermissionSubGroupCode.RoleLevel, "Вилоят даражасини кўриш Admin")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Вилоят даражасини кўриш Admin")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Viloyat darajasini ko‘rish Admin")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр уровня региона (Admin)")]
    [WbTranslate(LanguageIdConst.EN, "Admin — Region Level")]
    RegionLevelAdmin,

    [WbPermissionField(AdmPermissionSubGroupCode.RoleLevel, "Вилоят даражасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Вилоят даражасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Viloyat darajasini ko‘rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр уровня региона")]
    [WbTranslate(LanguageIdConst.EN, "View Region Level")]
    RegionLevelView,
    #endregion

    #region DistrictLevel

    [WbPermissionField(AdmPermissionSubGroupCode.RoleLevel, "Туман даражасини кўриш Admin")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Туман даражасини кўриш Admin")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tuman darajasini ko‘rish Admin")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр уровня района (Admin)")]
    [WbTranslate(LanguageIdConst.EN, "Admin — District Level")]
    DistrictLevelAdmin,

    [WbPermissionField(AdmPermissionSubGroupCode.RoleLevel, "Туман даражасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Туман даражасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tuman darajasini ko‘rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр уровня района")]
    [WbTranslate(LanguageIdConst.EN, "View District Level")]
    DistrictLevelView,
    #endregion

    #region OrganizationLevel

    [WbPermissionField(AdmPermissionSubGroupCode.RoleLevel, "Ташкилот даражасини кўриш Admin")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташкилот даражасини кўриш Admin")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkilot darajasini ko‘rish Admin")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр уровня организации (Admin)")]
    [WbTranslate(LanguageIdConst.EN, "Admin — Organization Level")]
    OrganizationLevelAdmin,

    #endregion


    #region User
    [WbPermissionField(AdmPermissionSubGroupCode.User, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    UserView,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    UserCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    UserEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.User, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    UserDelete,
    #endregion

    #region Bank
    [WbPermissionField(AdmPermissionSubGroupCode.Bank, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    BankView,

    [WbPermissionField(AdmPermissionSubGroupCode.Bank, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    BankCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Bank, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    BankEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Bank, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    BankDelete,

    #endregion

    #region Citizenship
    [WbPermissionField(AdmPermissionSubGroupCode.Citizenship, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CitizenshipView,

    [WbPermissionField(AdmPermissionSubGroupCode.Citizenship, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CitizenshipCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Citizenship, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CitizenshipEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Citizenship, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CitizenshipDelete,
    #endregion

    #region Country
    [WbPermissionField(AdmPermissionSubGroupCode.Country, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CountryView,

    [WbPermissionField(AdmPermissionSubGroupCode.Country, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CountryCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Country, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CountryEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Country, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CountryDelete,
    #endregion

    #region District
    [WbPermissionField(AdmPermissionSubGroupCode.District, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DistrictView,

    [WbPermissionField(AdmPermissionSubGroupCode.District, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DistrictCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.District, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DistrictEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.District, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DistrictDelete,
    #endregion

    #region DocumentStatus
    [WbPermissionField(AdmPermissionSubGroupCode.DocumentStatus, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DocumentStatusView,

    [WbPermissionField(AdmPermissionSubGroupCode.DocumentStatus, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DocumentStatusCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.DocumentStatus, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DocumentStatusEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.DocumentStatus, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DocumentStatusDelete,
    #endregion

    #region EduDirection
    [WbPermissionField(AdmPermissionSubGroupCode.EduDirection, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    EduDirectionView,

    [WbPermissionField(AdmPermissionSubGroupCode.EduDirection, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    EduDirectionCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.EduDirection, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    EduDirectionEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.EduDirection, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    EduDirectionDelete,
    #endregion

    #region EduYear
    [WbPermissionField(AdmPermissionSubGroupCode.EduYear, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    EduYearView,

    [WbPermissionField(AdmPermissionSubGroupCode.EduYear, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    EduYearCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.EduYear, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]


    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    EduYearEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.EduYear, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    EduYearDelete,
    #endregion

    #region Gender
    [WbPermissionField(AdmPermissionSubGroupCode.Gender, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    GenderView,

    [WbPermissionField(AdmPermissionSubGroupCode.Gender, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    GenderCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Gender, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    GenderEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Gender, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    GenderDelete,
    #endregion

    #region InstitutionType
    [WbPermissionField(AdmPermissionSubGroupCode.InstitutionType, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    InstitutionTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.InstitutionType, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    InstitutionTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.InstitutionType, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    InstitutionTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.InstitutionType, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    InstitutionTypeDelete,
    #endregion

    #region Language
    [WbPermissionField(AdmPermissionSubGroupCode.Language, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    LanguageView,

    [WbPermissionField(AdmPermissionSubGroupCode.Language, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    LanguageCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Language, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    LanguageEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Language, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    LanguageDelete,
    #endregion

    #region Mfy
    [WbPermissionField(AdmPermissionSubGroupCode.Mfy, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    MfyView,

    [WbPermissionField(AdmPermissionSubGroupCode.Mfy, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    MfyCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Mfy, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    MfyEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Mfy, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    MfyDelete,
    #endregion

    #region Nationality
    [WbPermissionField(AdmPermissionSubGroupCode.Nationality, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    NationalityView,

    [WbPermissionField(AdmPermissionSubGroupCode.Nationality, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    NationalityCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Nationality, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    NationalityEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Nationality, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    NationalityDelete,
    #endregion

    #region Oked
    [WbPermissionField(AdmPermissionSubGroupCode.Oked, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OkedView,

    [WbPermissionField(AdmPermissionSubGroupCode.Oked, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OkedCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Oked, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OkedEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Oked, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OkedDelete,
    #endregion

    #region Organization
    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OrganizationView,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OrganizationEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OrganizationDelete,

    [WbPermissionField(AdmPermissionSubGroupCode.Organization, "Ҳисобот")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳисобот")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hisobot")]
    [WbTranslate(LanguageIdConst.RU, "Отчет")]
    [WbTranslate(LanguageIdConst.EN, "Report")]
    OrganizationReportView,
    #endregion


    #region OrganizationAccount
    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationAccount, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OrganizationAccountView,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationAccount, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationAccountCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationAccount, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OrganizationAccountEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationAccount, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OrganizationAccountDelete,
    #endregion

    #region OrganizationalForm
    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationalForm, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OrganizationalFormView,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationalForm, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationalFormCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationalForm, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OrganizationalFormEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationalForm, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OrganizationalFormDelete,
    #endregion

    #region OrganizationCadastreCertificate
    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationCadastreCertificate, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OrganizationCadastreCertificateView,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationCadastreCertificate, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationCadastreCertificateCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationCadastreCertificate, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OrganizationCadastreCertificateEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationCadastreCertificate, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OrganizationCadastreCertificateDelete,
    #endregion



    #region OrganizationSpecialization

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationSpecialization, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OrganizationSpecializationView,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationSpecialization, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationSpecializationCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationSpecialization, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OrganizationSpecializationEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationSpecialization, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OrganizationSpecializationDelete,
    #endregion

    #region OrganizationType
    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationType, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OrganizationTypeView,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationType, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationTypeCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationType, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OrganizationTypeEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.OrganizationType, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OrganizationTypeDelete,
    #endregion

    #region Person
    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PersonView,

    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PersonCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PersonEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Person, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PersonDelete,
    #endregion

    #region State
    [WbPermissionField(AdmPermissionSubGroupCode.State, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    StateView,

    [WbPermissionField(AdmPermissionSubGroupCode.State, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    StateCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.State, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    StateEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.State, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    StateDelete,
    #endregion

    #region Status
    [WbPermissionField(AdmPermissionSubGroupCode.Status, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    StatusView,

    [WbPermissionField(AdmPermissionSubGroupCode.Status, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    StatusCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Status, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    StatusEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Status, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    StatusDelete,
    #endregion

    #region Table
    [WbPermissionField(AdmPermissionSubGroupCode.Table, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TableView,

    [WbPermissionField(AdmPermissionSubGroupCode.Table, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TableCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Table, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TableEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Table, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TableDelete,
    #endregion

    #region Role
    [WbPermissionField(AdmPermissionSubGroupCode.Role, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RoleView,

    [WbPermissionField(AdmPermissionSubGroupCode.Role, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RoleCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Role, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RoleEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Role, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RoleDelete,
    #endregion

    #region Specialty
    [WbPermissionField(AdmPermissionSubGroupCode.Specialty, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    SpecialtyView,

    [WbPermissionField(AdmPermissionSubGroupCode.Specialty, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    SpecialtyCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Specialty, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    SpecialtyEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Specialty, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    SpecialtyDelete,
    #endregion

    #region Region
    [WbPermissionField(AdmPermissionSubGroupCode.Region, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RegionView,

    [WbPermissionField(AdmPermissionSubGroupCode.Region, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RegionCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Region, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RegionEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Region, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RegionDelete,
    #endregion

    #region PersonHistory
    [WbPermissionField(AdmPermissionSubGroupCode.PersonHistory, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PersonHistoryView,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonHistory, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PersonHistoryCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonHistory, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PersonHistoryEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonHistory, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PersonHistoryDelete,
    #endregion

    #region PersonAddressHistory
    [WbPermissionField(AdmPermissionSubGroupCode.PersonAddressHistory, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PersonAddressHistoryView,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonAddressHistory, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PersonAddressHistoryCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonAddressHistory, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PersonAddressHistoryEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonAddressHistory, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PersonAddressHistoryDelete,
    #endregion

    #region PersonAddress
    [WbPermissionField(AdmPermissionSubGroupCode.PersonAddress, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PersonAddressView,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonAddress, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PersonAddressCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonAddress, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PersonAddressEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.PersonAddress, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PersonAddressDelete,
    #endregion

    #region Permission
    [WbPermissionField(AdmPermissionSubGroupCode.Permission, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PermissionView,

    [WbPermissionField(AdmPermissionSubGroupCode.Permission, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PermissionCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.Permission, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PermissionEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.Permission, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PermissionDelete,
    #endregion

    #region App
    [WbPermissionField(AdmPermissionSubGroupCode.App, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    AppView,

    [WbPermissionField(AdmPermissionSubGroupCode.App, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    AppCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.App, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    AppEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.App, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    AppDelete,
    #endregion

    #region PermissionSubGroup
    [WbPermissionField(AdmPermissionSubGroupCode.PermissionSubGroup, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PermissionSubGroupView,

    [WbPermissionField(AdmPermissionSubGroupCode.PermissionSubGroup, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PermissionSubGroupCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.PermissionSubGroup, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PermissionSubGroupEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.PermissionSubGroup, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PermissionSubGroupDelete,
    #endregion

    #region PermissionGroup
    [WbPermissionField(AdmPermissionSubGroupCode.PermissionGroup, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PermissionGroupView,

    [WbPermissionField(AdmPermissionSubGroupCode.PermissionGroup, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PermissionGroupCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.PermissionGroup, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PermissionGroupEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.PermissionGroup, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PermissionGroupDelete,
    #endregion

    #region CalculationKind
    [WbPermissionField(AdmPermissionSubGroupCode.CalculationKind, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CalculationKindView,

    [WbPermissionField(AdmPermissionSubGroupCode.CalculationKind, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CalculationKindCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.CalculationKind, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CalculationKindEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.CalculationKind, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CalculationKindDelete,
    #endregion

    #region ItemOfExpense
    [WbPermissionField(AdmPermissionSubGroupCode.ItemOfExpense, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ItemOfExpenseView,

    [WbPermissionField(AdmPermissionSubGroupCode.ItemOfExpense, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ItemOfExpenseCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.ItemOfExpense, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ItemOfExpenseEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.ItemOfExpense, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ItemOfExpenseDelete,
    #endregion

    #region FixedMinimumValue
    [WbPermissionField(AdmPermissionSubGroupCode.FixedMinimumValue, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    FixedMinimumValueView,

    [WbPermissionField(AdmPermissionSubGroupCode.FixedMinimumValue, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    FixedMinimumValueCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.FixedMinimumValue, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    FixedMinimumValueEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.FixedMinimumValue, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    FixedMinimumValueDelete,
    #endregion

    #region FileConfig
    [WbPermissionField(AdmPermissionSubGroupCode.FileConfig, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    FileConfigView,

    [WbPermissionField(AdmPermissionSubGroupCode.FileConfig, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    FileConfigCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.FileConfig, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    FileConfigEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.FileConfig, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    FileConfigDelete,
    #endregion

    #region CustomJob
    [WbPermissionField(AdmPermissionSubGroupCode.CustomJob, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CustomJobView,

    [WbPermissionField(AdmPermissionSubGroupCode.CustomJob, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CustomJobCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.CustomJob, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CustomJobEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.CustomJob, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CustomJobDelete,


    [WbPermissionField(AdmPermissionSubGroupCode.CustomJob, "Тасдиқлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Тасдиқлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tasdiqlash")]
    [WbTranslate(LanguageIdConst.RU, "Утвердить")]
    [WbTranslate(LanguageIdConst.EN, "Approve")]
    CustomJobApprove,
    #endregion

    #region ExternalSystemEndpoint
    [WbPermissionField(AdmPermissionSubGroupCode.ExternalSystemEndpoint, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ExternalSystemEndpointView,

    [WbPermissionField(AdmPermissionSubGroupCode.ExternalSystemEndpoint, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ExternalSystemEndpointCreate,

    [WbPermissionField(AdmPermissionSubGroupCode.ExternalSystemEndpoint, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ExternalSystemEndpointEdit,

    [WbPermissionField(AdmPermissionSubGroupCode.ExternalSystemEndpoint, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ExternalSystemEndpointDelete,

    #endregion


}


public enum PermissionCode
{
    #region INFO

    #region Country
    [WbPermissionField(PermissionSubGroupCode.Country, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CountryView,

    [WbPermissionField(PermissionSubGroupCode.Country, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CountryCreate,

    [WbPermissionField(PermissionSubGroupCode.Country, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CountryEdit,

    [WbPermissionField(PermissionSubGroupCode.Country, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CountryDelete,
    #endregion

    #region Bank
    [WbPermissionField(PermissionSubGroupCode.Bank, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    BankView,

    [WbPermissionField(PermissionSubGroupCode.Bank, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    BankCreate,

    [WbPermissionField(PermissionSubGroupCode.Bank, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    BankEdit,

    [WbPermissionField(PermissionSubGroupCode.Bank, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    BankDelete,
    #endregion

    #region FuelType
    [WbPermissionField(PermissionSubGroupCode.FuelType, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    FuelTypeView,

    [WbPermissionField(PermissionSubGroupCode.FuelType, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    FuelTypeCreate,

    [WbPermissionField(PermissionSubGroupCode.FuelType, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    FuelTypeEdit,

    [WbPermissionField(PermissionSubGroupCode.FuelType, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    FuelTypeDelete,
    #endregion

    #region InsuranceType
    [WbPermissionField(PermissionSubGroupCode.InsuranceType, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    InsuranceTypeView,

    [WbPermissionField(PermissionSubGroupCode.InsuranceType, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    InsuranceTypeCreate,

    [WbPermissionField(PermissionSubGroupCode.InsuranceType, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    InsuranceTypeEdit,

    [WbPermissionField(PermissionSubGroupCode.InsuranceType, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    InsuranceTypeDelete,
    #endregion

    #region Currency
    [WbPermissionField(PermissionSubGroupCode.Currency, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CurrencyView,

    [WbPermissionField(PermissionSubGroupCode.Currency, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CurrencyCreate,

    [WbPermissionField(PermissionSubGroupCode.Currency, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CurrencyEdit,

    [WbPermissionField(PermissionSubGroupCode.Currency, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CurrencyDelete,
    #endregion

    #region Citizenship
    [WbPermissionField(PermissionSubGroupCode.Citizenship, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    CitizenshipView,

    [WbPermissionField(PermissionSubGroupCode.Citizenship, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    CitizenshipCreate,

    [WbPermissionField(PermissionSubGroupCode.Citizenship, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    CitizenshipEdit,

    [WbPermissionField(PermissionSubGroupCode.Citizenship, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    CitizenshipDelete,
    #endregion

    #region ServiceType
    [WbPermissionField(PermissionSubGroupCode.ServiceType, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ServiceTypeView,

    [WbPermissionField(PermissionSubGroupCode.ServiceType, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ServiceTypeCreate,

    [WbPermissionField(PermissionSubGroupCode.ServiceType, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ServiceTypeEdit,

    [WbPermissionField(PermissionSubGroupCode.ServiceType, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ServiceTypeDelete,
    #endregion

    #region Nationality
    [WbPermissionField(PermissionSubGroupCode.Nationality, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    NationalityView,

    [WbPermissionField(PermissionSubGroupCode.Nationality, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    NationalityCreate,

    [WbPermissionField(PermissionSubGroupCode.Nationality, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    NationalityEdit,

    [WbPermissionField(PermissionSubGroupCode.Nationality, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    NationalityDelete,
    #endregion

    #region District
    [WbPermissionField(PermissionSubGroupCode.District, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DistrictView,

    [WbPermissionField(PermissionSubGroupCode.District, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DistrictCreate,

    [WbPermissionField(PermissionSubGroupCode.District, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DistrictEdit,

    [WbPermissionField(PermissionSubGroupCode.District, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DistrictDelete,
    #endregion

    #region Organization
    [WbPermissionField(PermissionSubGroupCode.Organization, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    OrganizationAllView,

    [WbPermissionField(PermissionSubGroupCode.Organization, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OrganizationView,

    [WbPermissionField(PermissionSubGroupCode.Organization, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationCreate,

    [WbPermissionField(PermissionSubGroupCode.Organization, "РЎРѕР·РґР°С‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OrganizationUpsertForAll,

    [WbPermissionField(PermissionSubGroupCode.Organization, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OrganizationEdit,

    [WbPermissionField(PermissionSubGroupCode.Organization, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OrganizationDelete,
    #endregion

    #region Region
    [WbPermissionField(PermissionSubGroupCode.Region, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RegionView,

    [WbPermissionField(PermissionSubGroupCode.Region, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RegionCreate,

    [WbPermissionField(PermissionSubGroupCode.Region, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RegionEdit,

    [WbPermissionField(PermissionSubGroupCode.Region, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RegionDelete,
    #endregion

    #region BatteryType
    [WbPermissionField(PermissionSubGroupCode.BatteryType, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    BatteryTypeView,

    [WbPermissionField(PermissionSubGroupCode.BatteryType, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    BatteryTypeCreate,

    [WbPermissionField(PermissionSubGroupCode.BatteryType, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    BatteryTypeEdit,

    [WbPermissionField(PermissionSubGroupCode.BatteryType, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    BatteryTypeDelete,

    #endregion

    #region Contractor
    [WbPermissionField(PermissionSubGroupCode.Contractor, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ContractorView,

    [WbPermissionField(PermissionSubGroupCode.Contractor, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ContractorCreate,

    [WbPermissionField(PermissionSubGroupCode.Contractor, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ContractorEdit,

    [WbPermissionField(PermissionSubGroupCode.Contractor, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ContractorDelete,
    #endregion

    #region TransportBrand
    [WbPermissionField(PermissionSubGroupCode.TransportBrand, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportBrandView,

    [WbPermissionField(PermissionSubGroupCode.TransportBrand, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportBrandCreate,

    [WbPermissionField(PermissionSubGroupCode.TransportBrand, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportBrandEdit,

    [WbPermissionField(PermissionSubGroupCode.TransportBrand, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportBrandDelete,
    #endregion

    #region TransportColor
    [WbPermissionField(PermissionSubGroupCode.TransportColor, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportColorView,

    [WbPermissionField(PermissionSubGroupCode.TransportColor, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportColorCreate,

    [WbPermissionField(PermissionSubGroupCode.TransportColor, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportColorEdit,

    [WbPermissionField(PermissionSubGroupCode.TransportColor, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportColorDelete,
    #endregion

    #region TransportType
    [WbPermissionField(PermissionSubGroupCode.TransportType, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportTypeView,

    [WbPermissionField(PermissionSubGroupCode.TransportType, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportTypeCreate,

    [WbPermissionField(PermissionSubGroupCode.TransportType, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportTypeEdit,

    [WbPermissionField(PermissionSubGroupCode.TransportType, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportTypeDelete,
    #endregion

    #region TransportUseType
    [WbPermissionField(PermissionSubGroupCode.TransportUseType, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportUseTypeView,

    [WbPermissionField(PermissionSubGroupCode.TransportUseType, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportUseTypeCreate,

    [WbPermissionField(PermissionSubGroupCode.TransportUseType, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportUseTypeEdit,

    [WbPermissionField(PermissionSubGroupCode.TransportUseType, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportUseTypeDelete,
    #endregion

    #region TransportModel
    [WbPermissionField(PermissionSubGroupCode.TransportModel, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportModelView,

    [WbPermissionField(PermissionSubGroupCode.TransportModel, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportModelCreate,

    [WbPermissionField(PermissionSubGroupCode.TransportModel, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportModelEdit,

    [WbPermissionField(PermissionSubGroupCode.TransportModel, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportModelDelete,
    #endregion

    #region OilType
    [WbPermissionField(PermissionSubGroupCode.OilType, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OilTypeView,

    [WbPermissionField(PermissionSubGroupCode.OilType, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OilTypeCreate,

    [WbPermissionField(PermissionSubGroupCode.OilType, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OilTypeEdit,

    [WbPermissionField(PermissionSubGroupCode.OilType, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OilTypeDelete,
    #endregion

    #region LiquidType
    [WbPermissionField(PermissionSubGroupCode.LiquidType, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    LiquidTypeView,

    [WbPermissionField(PermissionSubGroupCode.LiquidType, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    LiquidTypeCreate,

    [WbPermissionField(PermissionSubGroupCode.LiquidType, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    LiquidTypeEdit,

    [WbPermissionField(PermissionSubGroupCode.LiquidType, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    LiquidTypeDelete,
    #endregion

    #region OilModel
    [WbPermissionField(PermissionSubGroupCode.OilModel, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OilModelView,

    [WbPermissionField(PermissionSubGroupCode.OilModel, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OilModelCreate,

    [WbPermissionField(PermissionSubGroupCode.OilModel, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OilModelEdit,

    [WbPermissionField(PermissionSubGroupCode.OilModel, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OilModelDelete,
    #endregion

    #region TireModel
    [WbPermissionField(PermissionSubGroupCode.TireModel, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TireModelView,

    [WbPermissionField(PermissionSubGroupCode.TireModel, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TireModelCreate,

    [WbPermissionField(PermissionSubGroupCode.TireModel, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TireModelEdit,

    [WbPermissionField(PermissionSubGroupCode.TireModel, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TireModelDelete,
    #endregion

    #region TireSize
    [WbPermissionField(PermissionSubGroupCode.TireSize, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TireSizeView,

    [WbPermissionField(PermissionSubGroupCode.TireSize, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TireSizeCreate,

    [WbPermissionField(PermissionSubGroupCode.TireSize, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TireSizeEdit,

    [WbPermissionField(PermissionSubGroupCode.TireSize, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TireSizeDelete,
    #endregion

    #region MobileAppVersion
    [WbPermissionField(PermissionSubGroupCode.MobileAppVersion, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    MobileAppVersionView,

    [WbPermissionField(PermissionSubGroupCode.MobileAppVersion, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    MobileAppVersionCreate,

    [WbPermissionField(PermissionSubGroupCode.MobileAppVersion, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    MobileAppVersionEdit,

    [WbPermissionField(PermissionSubGroupCode.MobileAppVersion, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    MobileAppVersionDelete,
    #endregion

    #endregion

    #region HL

    #region Department
    [WbPermissionField(PermissionSubGroupCode.Department, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    DepartmentAllView,

    [WbPermissionField(PermissionSubGroupCode.Department, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DepartmentView,

    [WbPermissionField(PermissionSubGroupCode.Department, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DepartmentCreate,

    [WbPermissionField(PermissionSubGroupCode.Department, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DepartmentEdit,

    [WbPermissionField(PermissionSubGroupCode.Department, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DepartmentDelete,
    #endregion

    #region Person
    [WbPermissionField(PermissionSubGroupCode.Person, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PersonView,

    [WbPermissionField(PermissionSubGroupCode.Person, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    ViewAllPerson,

    [WbPermissionField(PermissionSubGroupCode.Person, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PersonCreate,

    [WbPermissionField(PermissionSubGroupCode.Person, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PersonEdit,

    [WbPermissionField(PermissionSubGroupCode.Person, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PersonDelete,
    #endregion

    #region Position
    [WbPermissionField(PermissionSubGroupCode.Position, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PositionView,

    [WbPermissionField(PermissionSubGroupCode.Position, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PositionCreate,

    [WbPermissionField(PermissionSubGroupCode.Position, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PositionEdit,

    [WbPermissionField(PermissionSubGroupCode.Position, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PositionDelete,
    #endregion

    #region Transport
    [WbPermissionField(PermissionSubGroupCode.Transport, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportView,

    [WbPermissionField(PermissionSubGroupCode.Transport, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ РІ С„РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р¤РёР»РёР°Р»РґР°РіРё Р±Р°СЂС‡Р°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filialdagi barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ РІ С„РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "View all in branch")]
    TransportBranchView,

    [WbPermissionField(PermissionSubGroupCode.Transport, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllViewTransport,

    [WbPermissionField(PermissionSubGroupCode.Transport, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportCreate,

    [WbPermissionField(PermissionSubGroupCode.Transport, "РЎРѕР·РґР°С‚СЊ РґР»СЏ РІСЃРµС… Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР° С„РёР»РёР°Р»Р»Р°СЂ СѓС‡СѓРЅ СЏСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ РґР»СЏ РІСЃРµС… Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    TransportCreateForAllBranch,

    [WbPermissionField(PermissionSubGroupCode.Transport, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportEdit,

    [WbPermissionField(PermissionSubGroupCode.Transport, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportDelete,
    #endregion

    #region Driver
    [WbPermissionField(PermissionSubGroupCode.Driver, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DriverView,

    [WbPermissionField(PermissionSubGroupCode.Driver, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ РІ С„РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р¤РёР»РёР°Р»РґР°РіРё Р±Р°СЂС‡Р°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filialdagi barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ РІ С„РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "View all in branch")]
    DriverBranchView,

    [WbPermissionField(PermissionSubGroupCode.Driver, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllViewDriver,

    [WbPermissionField(PermissionSubGroupCode.Driver, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DriverCreate,

    [WbPermissionField(PermissionSubGroupCode.Driver, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DriverEdit,

    [WbPermissionField(PermissionSubGroupCode.Driver, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DriverDelete,
    #endregion

    #region FuelCard
    [WbPermissionField(PermissionSubGroupCode.FuelCard, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    FuelCardView,

    [WbPermissionField(PermissionSubGroupCode.FuelCard, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµС…")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasibni ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµС…")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    FuelCardViewAll,

    [WbPermissionField(PermissionSubGroupCode.FuelCard, "РџСЂРѕСЃРјРѕС‚СЂ РІ РјР°СЃС€С‚Р°Р±Рµ С„РёР»РёР°Р»Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р¤РёР»РёР°Р» РјРёТ›С‘СЃРёРґР° РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filial miqyosida ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІ РјР°СЃС€С‚Р°Р±Рµ С„РёР»РёР°Р»Р°")]
    [WbTranslate(LanguageIdConst.EN, "Branch View")]
    FuelCardViewBranch,

    [WbPermissionField(PermissionSubGroupCode.FuelCard, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    FuelCardCreate,

    [WbPermissionField(PermissionSubGroupCode.FuelCard, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    FuelCardEdit,

    [WbPermissionField(PermissionSubGroupCode.FuelCard, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    FuelCardDelete,

    [WbPermissionField(PermissionSubGroupCode.FuelCard, "РЎРѕР·РґР°С‚СЊ РІСЃРµ РІРµС‚РєРё")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р° Р±СЂР°РЅС‡Р»Р°СЂРЅРё СЏСЂР°С‚Р° РѕР»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barcha branchlarni yarata olish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ РІСЃРµ РІРµС‚РєРё")]
    [WbTranslate(LanguageIdConst.EN, "Create FuelCard For All Branch")]
    CreateFuelCardForAllBranch,

    #endregion

    #region PresentTrackingInfo
    [WbPermissionField(PermissionSubGroupCode.PresentTrackingInfo, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PresentTrackingInfoView,

    [WbPermissionField(PermissionSubGroupCode.PresentTrackingInfo, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PresentTrackingInfoCreate,

    [WbPermissionField(PermissionSubGroupCode.PresentTrackingInfo, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PresentTrackingInfoEdit,

    [WbPermissionField(PermissionSubGroupCode.PresentTrackingInfo, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PresentTrackingInfoDelete,
    #endregion

    #region TrackingInfo
    [WbPermissionField(PermissionSubGroupCode.PresentTrackingInfo, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TrackingInfoView,

    [WbPermissionField(PermissionSubGroupCode.PresentTrackingInfo, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TrackingInfoCreate,

    [WbPermissionField(PermissionSubGroupCode.PresentTrackingInfo, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TrackingInfoEdit,

    [WbPermissionField(PermissionSubGroupCode.PresentTrackingInfo, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TrackingInfoDelete,
    #endregion

    #region Branch


    [WbPermissionField(PermissionSubGroupCode.Branch, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    BranchAllView,


    [WbPermissionField(PermissionSubGroupCode.Branch, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    BranchView,

    [WbPermissionField(PermissionSubGroupCode.Branch, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    BranchCreate,

    [WbPermissionField(PermissionSubGroupCode.Branch, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    BranchEdit,

    [WbPermissionField(PermissionSubGroupCode.Branch, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    BranchDelete,


    #endregion

    #region Notification

    [WbPermissionField(PermissionSubGroupCode.Notification, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllNotificationView,

    [WbPermissionField(PermissionSubGroupCode.Notification, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    NotificationView,

    [WbPermissionField(PermissionSubGroupCode.Notification, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    NotificationCreate,

    [WbPermissionField(PermissionSubGroupCode.Notification, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    NotificationEdit,

    [WbPermissionField(PermissionSubGroupCode.Notification, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    NotificationDelete,

    #endregion

    #region PresentNotification

    [WbPermissionField(PermissionSubGroupCode.PresentNotification, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllPresentNotificationView,


    [WbPermissionField(PermissionSubGroupCode.PresentNotification, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PresentNotificationView,

    [WbPermissionField(PermissionSubGroupCode.PresentNotification, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PresentNotificationCreate,

    [WbPermissionField(PermissionSubGroupCode.PresentNotification, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PresentNotificationEdit,

    [WbPermissionField(PermissionSubGroupCode.PresentNotification, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PresentNotificationDelete,

    #endregion

    #endregion

    #region DOC

    #region TransportSetting
    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportSettingView,

    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    TransportSettingViewAll,

    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "РџСЂРѕСЃРјРѕС‚СЂ С„РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р¤РёР»Р»СЏР» Р±СћР№РёС‡Р° РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Fillyal bo'yicha ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ С„РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "View by branch")]
    TransportSettingViewByBranch,

    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "РџСЂРѕСЃРјРѕС‚СЂ РїРѕ РІРѕРґРёС‚РµР»СЋ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РҐР°Р№РґРѕРІС‡Рё Р±СћР№РёС‡Р° РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Xaydovchi boвЂyicha koвЂrish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РїРѕ РІРѕРґРёС‚РµР»СЋ")]
    [WbTranslate(LanguageIdConst.EN, "View by driver")]
    TransportSettingViewByDriver,

    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportSettingCreate,

    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportSettingEdit,

    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "РџСЂРёРЅРёРјР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТљР°Р±СѓР» Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Qabul qilish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРёРЅРёРјР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    TransportSettingAccept,

    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "РћС‚РјРµРЅР°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘РµРєРѕСЂ Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "РћС‚РјРµРЅР°")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    TransportSettingCancel,

    [WbPermissionField(PermissionSubGroupCode.TransportSetting, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportSettingDelete,
    #endregion


    #region Refuel
    [WbPermissionField(PermissionSubGroupCode.Refuel, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ РІ С„РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂРµС‚СЊ РІСЃРµ РІ С„РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    RefuelBranchView,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    RefuelViewAll,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RefuelView,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RefuelCreate,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RefuelEdit,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RefuelDelete,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "РџСЂРёРЅСЏС‚РёРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "ТљР°Р±СѓР» Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРёРЅСЏС‚РёРµ")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    RefuelAccept,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "РћС‚РјРµРЅРёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘РµРєРѕСЂ Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "РћС‚РјРµРЅРёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    RefuelCancel,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "OС‚РїСЂР°РІР»СЏС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р®Р±РѕСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [WbTranslate(LanguageIdConst.RU, "OС‚РїСЂР°РІР»СЏС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Send")]
    RefuelSend,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "РћС‚РѕР·РІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘РµРєРѕСЂ Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "РћС‚РѕР·РІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Revoke")]
    RefuelRevoke,

    [WbPermissionField(PermissionSubGroupCode.Refuel, "РЎРѕР·РґР°С‚СЊ РґР»СЏ РІСЃРµС… Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР° С„РёР»РёР°Р»Р»Р°СЂ СѓС‡СѓРЅ СЏСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ РґР»СЏ РІСЃРµС… Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    RefuelCreateForAllBranch,

    //.... Boshqa statuslar davom etadi shu yerdan
    #endregion

    #region Expense
    [WbPermissionField(PermissionSubGroupCode.Expense, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    AllViewExpense,

    [WbPermissionField(PermissionSubGroupCode.Expense, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ExpenseView,

    [WbPermissionField(PermissionSubGroupCode.Expense, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ExpenseCreate,

    [WbPermissionField(PermissionSubGroupCode.Expense, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ExpenseEdit,

    [WbPermissionField(PermissionSubGroupCode.Expense, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ExpenseDelete,

    [WbPermissionField(PermissionSubGroupCode.Expense, "РџСЂРёРЅСЏС‚РёРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "ТљР°Р±СѓР» Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРёРЅСЏС‚РёРµ")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    ExpenseAccept,

    [WbPermissionField(PermissionSubGroupCode.Expense, "РћС‚РјРµРЅРёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘РµРєРѕСЂ Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "РћС‚РјРµРЅРёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    ExpenselCancel,

    [WbPermissionField(PermissionSubGroupCode.Expense, "OС‚РїСЂР°РІР»СЏС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р®Р±РѕСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [WbTranslate(LanguageIdConst.RU, "OС‚РїСЂР°РІР»СЏС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Send")]
    ExpenseSend,

    [WbPermissionField(PermissionSubGroupCode.Expense, "РћС‚РјРµРЅРёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘РµРєРѕСЂ Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "РћС‚РјРµРЅРёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Revoke")]
    ExpenseRevoke,

    [WbPermissionField(PermissionSubGroupCode.Expense, "РЎРѕР·РґР°С‚СЊ РґР»СЏ РІСЃРµС… Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР° С„РёР»РёР°Р»Р»Р°СЂ СѓС‡СѓРЅ СЏСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ РґР»СЏ РІСЃРµС… Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    ExpenseCreateForAllBranch,

    [WbPermissionField(PermissionSubGroupCode.Expense, "РџСЂРёРєСЂРµРїРёС‚СЊ СЃС‡РµС‚-С„Р°РєС‚СѓСЂСѓ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІРёСЃРѕР±-С„Р°РєС‚СѓСЂР° Р±РёСЂРёРєС‚РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hisob-faktura biriktirish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРёРєСЂРµРїРёС‚СЊ СЃС‡РµС‚-С„Р°РєС‚СѓСЂСѓ")]
    [WbTranslate(LanguageIdConst.EN, "Invoice attach")]
    InvoiceAttach,
    #endregion

    #region NotificationTemplateSetting
    [WbPermissionField(PermissionSubGroupCode.NotificationTemplateSetting, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    AllNotificationTemplateSettingView,

    [WbPermissionField(PermissionSubGroupCode.NotificationTemplateSetting, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    NotificationTemplateSettingView,

    [WbPermissionField(PermissionSubGroupCode.NotificationTemplateSetting, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    NotificationTemplateSettingCreate,

    [WbPermissionField(PermissionSubGroupCode.NotificationTemplateSetting, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    NotificationTemplateSettingEdit,

    [WbPermissionField(PermissionSubGroupCode.NotificationTemplateSetting, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    NotificationTemplateSettingDelete,

    [WbPermissionField(PermissionSubGroupCode.NotificationTemplateSetting, "РџСЂРёРЅСЏС‚РёРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "ТљР°Р±СѓР» Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРёРЅСЏС‚РёРµ")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    NotificationTemplateSettingAccept,

    [WbPermissionField(PermissionSubGroupCode.NotificationTemplateSetting, "РћС‚РјРµРЅРёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘РµРєРѕСЂ Т›РёР»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "РћС‚РјРµРЅРёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    NotificationTemplateSettingCancel,

    [WbPermissionField(PermissionSubGroupCode.NotificationTemplateSetting, "РЎРѕР·РґР°С‚СЊ РґР»СЏ РІСЃРµС… Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°РјРјР° С„РёР»РёР°Р»Р»Р°СЂ СѓС‡СѓРЅ СЏСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ РґР»СЏ РІСЃРµС… Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    NotificationTemplateSettingCreateForAllBranch,
    #endregion

    #endregion

    #region SYS

    #region Role
    [WbPermissionField(PermissionSubGroupCode.Role, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RoleView,

    [WbPermissionField(PermissionSubGroupCode.Role, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RoleCreate,

    [WbPermissionField(PermissionSubGroupCode.Role, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RoleEdit,

    [WbPermissionField(PermissionSubGroupCode.Role, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RoleDelete,
    #endregion

    #region User
    [WbPermissionField(PermissionSubGroupCode.User, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    UserView,

    [WbPermissionField(PermissionSubGroupCode.User, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЇСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    UserCreate,

    [WbPermissionField(PermissionSubGroupCode.User, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    UserEdit,

    [WbPermissionField(PermissionSubGroupCode.User, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЋС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    UserDelete,

    [WbPermissionField(PermissionSubGroupCode.User, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё РєСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllUserView,

    [WbPermissionField(PermissionSubGroupCode.User, "РЎРѕР·РґР°С‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё СЏСЂР°С‚РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini yaratish")]
    [WbTranslate(LanguageIdConst.RU, "РЎРѕР·РґР°С‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "Create all")]
    AllUserCreate,

    [WbPermissionField(PermissionSubGroupCode.User, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё С‚Р°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "Edit all")]
    AllUserEdit,

    [WbPermissionField(PermissionSubGroupCode.User, "РЈРґР°Р»РёС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°СЂС‡Р°СЃРёРЅРё СћС‡РёСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasini o'chirish")]
    [WbTranslate(LanguageIdConst.RU, "РЈРґР°Р»РёС‚СЊ РІСЃРµ")]
    [WbTranslate(LanguageIdConst.EN, "Delete all")]
    AllUserDelete,
    #endregion
    #endregion

    #region REPORT

    #region DriverPenalty
    [WbPermissionField(PermissionSubGroupCode.DriverPenalty, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DriverPenaltyView,

    [WbPermissionField(PermissionSubGroupCode.DriverPenalty, "РџСЂРѕСЃРјРѕС‚СЂ (РўРѕР»СЊРєРѕ СЃРѕР±СЃС‚РІРµРЅРЅС‹Р№ С„РёР»РёР°Р»)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€ (Р¤Р°Т›Р°С‚ СћР· С„РёР»РёР°Р»Рё)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Faqat o'z filiali)")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ (РўРѕР»СЊРєРѕ СЃРѕР±СЃС‚РІРµРЅРЅС‹Р№ С„РёР»РёР°Р»)")]
    [WbTranslate(LanguageIdConst.EN, "View branch")]
    DriverPenaltyBranchView,

    [WbPermissionField(PermissionSubGroupCode.DriverPenalty, "РџСЂРѕСЃРјРѕС‚СЂ (Р’СЃРµ С„РёР»РёР°Р»С‹)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€ (Р‘Р°СЂС‡Р° С„РёР»РёР°Р»Р»Р°СЂ)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Barcha filiallar)")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ (Р’СЃРµ С„РёР»РёР°Р»С‹)")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    DriverPenaltyAllView,

    [WbPermissionField(PermissionSubGroupCode.DriverPenalty, "РћРїР»Р°С‚Р° С€С‚СЂР°С„Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р–Р°СЂРёРјР° СѓС‡СѓРЅ С‚СћР»РѕРІ")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Jarima uchun to'lov")]
    [WbTranslate(LanguageIdConst.RU, "РћРїР»Р°С‚Р° С€С‚СЂР°С„Р°")]
    [WbTranslate(LanguageIdConst.EN, "Driver penalty pay")]
    DriverPenaltyPay,
    #endregion

    [WbPermissionField(PermissionSubGroupCode.OptimalRoute, "РћРїР»Р°С‚Р° С€С‚СЂР°С„Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р–Р°СЂРёРјР° СѓС‡СѓРЅ С‚СћР»РѕРІ")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Jarima uchun to'lov")]
    [WbTranslate(LanguageIdConst.RU, "РћРїР»Р°С‚Р° С€С‚СЂР°С„Р°")]
    [WbTranslate(LanguageIdConst.EN, "Driver penalty pay")]
    OptimalRoute,

    #region ExpenseReport
    [WbPermissionField(PermissionSubGroupCode.ExpenseReport, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ExpenseReportView,

    [WbPermissionField(PermissionSubGroupCode.DriverPenalty, "РџСЂРѕСЃРјРѕС‚СЂ (РўРѕР»СЊРєРѕ СЃРѕР±СЃС‚РІРµРЅРЅС‹Р№ С„РёР»РёР°Р»)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€ (Р¤Р°Т›Р°С‚ СћР· С„РёР»РёР°Р»Рё)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Faqat o'z filiali)")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ (РўРѕР»СЊРєРѕ СЃРѕР±СЃС‚РІРµРЅРЅС‹Р№ С„РёР»РёР°Р»)")]
    [WbTranslate(LanguageIdConst.EN, "View branch")]
    ExpenseReportBranchView,

    [WbPermissionField(PermissionSubGroupCode.DriverPenalty, "РџСЂРѕСЃРјРѕС‚СЂ (Р’СЃРµ С„РёР»РёР°Р»С‹)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€ (Р‘Р°СЂС‡Р° С„РёР»РёР°Р»Р»Р°СЂ)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Barcha filiallar)")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ (Р’СЃРµ С„РёР»РёР°Р»С‹)")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    ExpenseReportAllView,
    #endregion

    #endregion


    #region For Developers
    [WbPermissionField(PermissionSubGroupCode.Developer, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљСћСЂРёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "РџСЂРѕСЃРјРѕС‚СЂ")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    AppErrorView,
    [WbPermissionField(PermissionSubGroupCode.Developer, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°ТіСЂРёСЂР»Р°С€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Р РµРґР°РєС‚РёСЂРѕРІР°С‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    AppErrorEdit,
    #endregion
}
