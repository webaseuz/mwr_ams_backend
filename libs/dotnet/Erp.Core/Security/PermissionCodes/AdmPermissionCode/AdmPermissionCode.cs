using WEBASE;

namespace Erp.Core;

[WbPermissionEnum(AppIdConst.ADM)]
/*public enum AdmPermissionCode
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


}*/


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
