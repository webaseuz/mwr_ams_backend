using WEBASE;

namespace Erp.Core;

/*public enum AdmPermissionSubGroupCode
{
    #region SYSTEM

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Роль уровень")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Рол даражаси")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Rol darajasi")]
    [WbTranslate(LanguageIdConst.RU, "Роль уровень")]
    [WbTranslate(LanguageIdConst.EN, "Role Level")]
    RoleLevel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Системные ошибки")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Рол даражаси")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Тизимдаги хатоликлар")]
    [WbTranslate(LanguageIdConst.RU, "Системные ошибки")]
    [WbTranslate(LanguageIdConst.EN, "AppError")]
    AppError,

    #endregion

    #region SYSTEM

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Пользователь")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Фойдаланувчи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Foydalanuvchi")]
    [WbTranslate(LanguageIdConst.RU, "Пользователь")]
    [WbTranslate(LanguageIdConst.EN, "User")]
    User,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Ҳуқуқлар кичик гуруҳи")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳуқуқлар кичик гуруҳи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Huquqlar kichik guruhi")]
    [WbTranslate(LanguageIdConst.RU, "Подгруппа разрешений")]
    [WbTranslate(LanguageIdConst.EN, "Permission SubGroup")]
    PermissionSubGroup,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Роли пользователей")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Фойдаланувчи роллари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Foydalanuvchi rollari")]
    [WbTranslate(LanguageIdConst.RU, "Роли пользователей")]
    [WbTranslate(LanguageIdConst.EN, "User Roles")]
    UserRole,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Организации пользователей")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Фойдаланувчи ташкилотлари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Foydalanuvchi tashkilotlari")]
    [WbTranslate(LanguageIdConst.RU, "Организации пользователей")]
    [WbTranslate(LanguageIdConst.EN, "User Organizations")]
    UserOrganization,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Роли")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Роллар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Rollar")]
    [WbTranslate(LanguageIdConst.RU, "Роли")]
    [WbTranslate(LanguageIdConst.EN, "Roles")]
    Role,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Жадвал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Жадвал")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Jadval")]
    [WbTranslate(LanguageIdConst.RU, "Таблица")]
    [WbTranslate(LanguageIdConst.EN, "Table")]
    Table,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Ҳуқуқлар гуруҳи")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳуқуқлар гуруҳи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Huquqlar guruhi")]
    [WbTranslate(LanguageIdConst.RU, "Группа разрешений")]
    [WbTranslate(LanguageIdConst.EN, "Permission Group")]
    PermissionGroup,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Ҳуқуқ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳуқуқ")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Huquq")]
    [WbTranslate(LanguageIdConst.RU, "Разрешение")]
    [WbTranslate(LanguageIdConst.EN, "Permission")]
    Permission,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Конфигурации файлов")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Файл конфигуратсияси")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Fayl konfiguratsiyasi")]
    [WbTranslate(LanguageIdConst.RU, "Конфигурации файлов")]
    [WbTranslate(LanguageIdConst.EN, "File Configs")]
    FileConfig,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Специальная Работа")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Махсус Иш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Maxsus Ish")]
    [WbTranslate(LanguageIdConst.RU, "Специальная Работа")]
    [WbTranslate(LanguageIdConst.EN, "Custom Job")]
    CustomJob,

    #endregion

    #region MANUALS

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Ташқи тизимнинг охирги нуқтаси")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташқи тизимнинг охирги нуқтаси")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashqi tizimning oxirgi nuqtasi")]
    [WbTranslate(LanguageIdConst.RU, "Конечная точка внешней системы")]
    [WbTranslate(LanguageIdConst.EN, "External System Endpoint")]
    ExternalSystemEndpoint,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Банк")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Банк")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bank")]
    [WbTranslate(LanguageIdConst.RU, "Банк")]
    [WbTranslate(LanguageIdConst.EN, "Bank")]
    Bank,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Гражданство")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Фуқаролик")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Fuqarolik")]
    [WbTranslate(LanguageIdConst.RU, "Гражданство")]
    [WbTranslate(LanguageIdConst.EN, "Citizenship")]
    Citizenship,


    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Страны")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Давлатлар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Davlatlar")]
    [WbTranslate(LanguageIdConst.RU, "Страны")]
    [WbTranslate(LanguageIdConst.EN, "Countries")]
    Country,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Валюты")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Валюталар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Valyutalar")]
    [WbTranslate(LanguageIdConst.RU, "Валюты")]
    [WbTranslate(LanguageIdConst.EN, "Currencies")]
    Currency,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Национальности")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Миллатлар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Millatlar")]
    [WbTranslate(LanguageIdConst.RU, "Национальности")]
    [WbTranslate(LanguageIdConst.EN, "Nationalities")]
    Nationality,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Махаллялар")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Маҳаллалар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Mahallalar")]
    [WbTranslate(LanguageIdConst.RU, "Махаллялар")]
    [WbTranslate(LanguageIdConst.EN, "Neighborhoods")]
    Mfy,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Языки")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Тиллар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tillar")]
    [WbTranslate(LanguageIdConst.RU, "Языки")]
    [WbTranslate(LanguageIdConst.EN, "Languages")]
    Language,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Типы учреждений")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Муассаса турлари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Muassasa turlari")]
    [WbTranslate(LanguageIdConst.RU, "Типы учреждений")]
    [WbTranslate(LanguageIdConst.EN, "Institution Types")]
    InstitutionType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Пол")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Жинс")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Jins")]
    [WbTranslate(LanguageIdConst.RU, "Пол")]
    [WbTranslate(LanguageIdConst.EN, "Gender")]
    Gender,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Учебные года")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўқув йиллари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O‘quv yillari")]
    [WbTranslate(LanguageIdConst.RU, "Учебные года")]
    [WbTranslate(LanguageIdConst.EN, "Educational Years")]
    EduYear,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Направления образования")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таълим йўналишлари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ta'lim yo'nalishlari")]
    [WbTranslate(LanguageIdConst.RU, "Направления образования")]
    [WbTranslate(LanguageIdConst.EN, "Education Directions")]
    EduDirection,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Районы")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Туманлар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tumanlar")]
    [WbTranslate(LanguageIdConst.RU, "Районы")]
    [WbTranslate(LanguageIdConst.EN, "Districts")]
    District,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Статусы документов")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳужжат ҳолатлари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hujjat holatlari")]
    [WbTranslate(LanguageIdConst.RU, "Статусы документов")]
    [WbTranslate(LanguageIdConst.EN, "Document statuses")]
    DocumentStatus,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Специальности")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Мутахассисликлар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Mutaxassisliklar")]
    [WbTranslate(LanguageIdConst.RU, "Специальности")]
    [WbTranslate(LanguageIdConst.EN, "Specialties")]
    Specialty,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Статусы")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Статуслар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Statuslar")]
    [WbTranslate(LanguageIdConst.RU, "Статусы")]
    [WbTranslate(LanguageIdConst.EN, "Statuses")]
    Status,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Состояния")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳолатлар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Holatlar")]
    [WbTranslate(LanguageIdConst.RU, "Состояния")]
    [WbTranslate(LanguageIdConst.EN, "States")]
    State,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Регионы")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳудудлар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hududlar")]
    [WbTranslate(LanguageIdConst.RU, "Регионы")]
    [WbTranslate(LanguageIdConst.EN, "Regions")]
    Region,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "История личности")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Шахс тарихи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shaxs tarixi")]
    [WbTranslate(LanguageIdConst.RU, "История личности")]
    [WbTranslate(LanguageIdConst.EN, "Person History")]
    PersonHistory,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "История адресов личности")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Шахс манзили тарихи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shaxs manzili tarixi")]
    [WbTranslate(LanguageIdConst.RU, "История адресов личности")]
    [WbTranslate(LanguageIdConst.EN, "Person Address History")]
    PersonAddressHistory,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Адреса личности")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Шахс манзиллари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shaxs manzillari")]
    [WbTranslate(LanguageIdConst.RU, "Адреса личности")]
    [WbTranslate(LanguageIdConst.EN, "Person Addresses")]
    PersonAddress,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Личности")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Шахслар")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shaxslar")]
    [WbTranslate(LanguageIdConst.RU, "Личности")]
    [WbTranslate(LanguageIdConst.EN, "Persons")]
    Person,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Типы организаций")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташкилот турлари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkilot turlari")]
    [WbTranslate(LanguageIdConst.RU, "Типы организаций")]
    [WbTranslate(LanguageIdConst.EN, "Organization Types")]
    OrganizationType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "ОКЭД")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ОКЭД")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "OKED")]
    [WbTranslate(LanguageIdConst.RU, "ОКЭД")]
    [WbTranslate(LanguageIdConst.EN, "OKED")]
    Oked,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Счета организаций")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташкилот ҳисоб рақамлари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkilot hisob raqamlari")]
    [WbTranslate(LanguageIdConst.RU, "Счета организаций")]
    [WbTranslate(LanguageIdConst.EN, "Organization Accounts")]
    OrganizationAccount,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Организация")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташкилот")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkilot")]
    [WbTranslate(LanguageIdConst.RU, "Организация")]
    [WbTranslate(LanguageIdConst.EN, "Organization")]
    Organization,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Ташкилий-ҳуқуқий шакл")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташкилий-ҳуқуқий шакл")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkiliy-huquqiy shakl")]
    [WbTranslate(LanguageIdConst.RU, "Организационно-правовая форма")]
    [WbTranslate(LanguageIdConst.EN, "Organizational Form")]
    OrganizationalForm,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Илова")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Илова")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ilova")]
    [WbTranslate(LanguageIdConst.RU, "Приложение")]
    [WbTranslate(LanguageIdConst.EN, "App")]
    App,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип платежа")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Тўлов тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "To'lov turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип платежа")]
    [WbTranslate(LanguageIdConst.EN, "Calculation kind")]
    CalculationKind,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Статья расходов")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаражатлар моддаси")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Harajatlar moddasi")]
    [WbTranslate(LanguageIdConst.RU, "Статья расходов")]
    [WbTranslate(LanguageIdConst.EN, "Item of expense")]
    ItemOfExpense,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Фиксированное минимальное значение")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Рухсат этилган минимал қиймат")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ruxsat etilgan minimal qiymat")]
    [WbTranslate(LanguageIdConst.RU, "Фиксированное минимальное значение")]
    [WbTranslate(LanguageIdConst.EN, "FixedMinimumValue")]
    FixedMinimumValue,

    #endregion

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Специализации организаций")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташкилот ихтисослашувлари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkilot ixtisoslashuvlari")]
    [WbTranslate(LanguageIdConst.RU, "Специализации организаций")]
    [WbTranslate(LanguageIdConst.EN, "Organization Specializations")]
    OrganizationSpecialization,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Кадастровые свидетельства организаций")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташкилот кадастр гувоҳномалари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkilot kadastr guvohnomalari")]
    [WbTranslate(LanguageIdConst.RU, "Кадастровые свидетельства организаций")]
    [WbTranslate(LanguageIdConst.EN, "Organization Cadastre Certificates")]
    OrganizationCadastreCertificate
}*/

public enum AdmPermissionSubGroupCode
{
    #region INFO
    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Страна")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Давлат")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Davlat")]
    [WbTranslate(LanguageIdConst.RU, "Страна")]
    [WbTranslate(LanguageIdConst.EN, "Country")]
    Country,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Банк")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Банк")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bank")]
    [WbTranslate(LanguageIdConst.RU, "Банк")]
    [WbTranslate(LanguageIdConst.EN, "Bank")]
    Bank,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Валюта")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Валюта")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Valyuta")]
    [WbTranslate(LanguageIdConst.RU, "Валюта")]
    [WbTranslate(LanguageIdConst.EN, "Currency")]
    Currency,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип топлива")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ёқилғи тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yoqilg‘i turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип топлива")]
    [WbTranslate(LanguageIdConst.EN, "Fuel type")]
    FuelType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип страхования")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Суғурта тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Sug‘urta turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип страхования")]
    [WbTranslate(LanguageIdConst.EN, "Insurance type")]
    InsuranceType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Гражданство")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Фукоролик")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Fuqorolik")]
    [WbTranslate(LanguageIdConst.RU, "Гражданство")]
    [WbTranslate(LanguageIdConst.EN, "Citizenship")]
    Citizenship,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип медицинской услуги")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Тиббий хизмат тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tibbiy xizmat turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип медицинской услуги")]
    [WbTranslate(LanguageIdConst.EN, "ServiceType")]
    ServiceType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Национальность")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Миллати")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Millati")]
    [WbTranslate(LanguageIdConst.RU, "Национальность")]
    [WbTranslate(LanguageIdConst.EN, "Nationality")]
    Nationality,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Район")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Туман")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tuman")]
    [WbTranslate(LanguageIdConst.RU, "Район")]
    [WbTranslate(LanguageIdConst.EN, "District")]
    District,


    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Организация")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ташкилот")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkilot")]
    [WbTranslate(LanguageIdConst.RU, "Организация")]
    [WbTranslate(LanguageIdConst.EN, "Organization")]
    Organization,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Область")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Вилоят")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Viloyat")]
    [WbTranslate(LanguageIdConst.RU, "Область")]
    [WbTranslate(LanguageIdConst.EN, "Region")]
    Region,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип батареи")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Акумлятор тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Akumlyator turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип батареи")]
    [WbTranslate(LanguageIdConst.EN, "BatteryType")]
    BatteryType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Контрактор")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Контрактор")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Kontraktor")]
    [WbTranslate(LanguageIdConst.RU, "Контрактор")]
    [WbTranslate(LanguageIdConst.EN, "Contractor")]
    Contractor,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Транспортная марка")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Транспорт бренди")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport brendi")]
    [WbTranslate(LanguageIdConst.RU, "Транспортная марка")]
    [WbTranslate(LanguageIdConst.EN, "TransportBrand")]
    TransportBrand,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Цвет транспорта")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Транспорт ранги")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport rangi")]
    [WbTranslate(LanguageIdConst.RU, "Цвет транспорта")]
    [WbTranslate(LanguageIdConst.EN, "TransportColor")]
    TransportColor,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип транспорта")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Транспорт тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип транспорта")]
    [WbTranslate(LanguageIdConst.EN, "TransportType")]
    TransportType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип использования транспорта")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Транспортдан фойдаланиш тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transportdan foydalanish turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип использования транспорта")]
    [WbTranslate(LanguageIdConst.EN, "TransportUseType")]
    TransportUseType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Модель транспорта")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Транспорт модели")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport modeli")]
    [WbTranslate(LanguageIdConst.RU, "Модель транспорта")]
    [WbTranslate(LanguageIdConst.EN, "TransportModel")]
    TransportModel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип масла")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ёғ тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yog' turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип масла")]
    [WbTranslate(LanguageIdConst.EN, "Oil Type")]
    OilType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Модель масла")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ёғ модели")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yog' modeli")]
    [WbTranslate(LanguageIdConst.RU, "Модель масла")]
    [WbTranslate(LanguageIdConst.EN, "Oil Model")]
    OilModel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Модель шины")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Шина модели")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shina modeli")]
    [WbTranslate(LanguageIdConst.RU, "Модель шины")]
    [WbTranslate(LanguageIdConst.EN, "Tire Model")]
    TireModel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип жидкости")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ёкилги тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yoqilg'i turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип жидкости")]
    [WbTranslate(LanguageIdConst.EN, "Liquid Type")]
    LiquidType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Размер шин")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Шина ўлчами")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shina o‘lchami")]
    [WbTranslate(LanguageIdConst.RU, "Размер шин")]
    [WbTranslate(LanguageIdConst.EN, "Tire Size")]
    TireSize,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Версия мобильного приложения")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Мобил илова версияси")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Mobil ilova versiyasi")]
    [WbTranslate(LanguageIdConst.RU, "Версия мобильного приложения")]
    [WbTranslate(LanguageIdConst.EN, "Mobile App Version")]
    MobileAppVersion,
    #endregion

    #region HL


    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Отдел")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бўлим")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bo'lim")]
    [WbTranslate(LanguageIdConst.RU, "Отдел")]
    [WbTranslate(LanguageIdConst.EN, "Department")]
    Department,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Позиция")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Лавозим")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Lavozim")]
    [WbTranslate(LanguageIdConst.RU, "Позиция")]
    [WbTranslate(LanguageIdConst.EN, "Position")]
    Position,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Персона")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Шахс")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shaxs")]
    [WbTranslate(LanguageIdConst.RU, "Персона")]
    [WbTranslate(LanguageIdConst.EN, "Person")]
    Person,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Транспорт")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Транспорт")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport")]
    [WbTranslate(LanguageIdConst.RU, "Транспорт")]
    [WbTranslate(LanguageIdConst.EN, "Transport")]
    Transport,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Топливная карта")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ёқилғи картаси")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yoqilg'i kartasi")]
    [WbTranslate(LanguageIdConst.RU, "Топливная карта")]
    [WbTranslate(LanguageIdConst.EN, "Fuel Card")]
    FuelCard,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Водитель")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳайдовчи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Haydovchi")]
    [WbTranslate(LanguageIdConst.RU, "Водитель")]
    [WbTranslate(LanguageIdConst.EN, "Driver")]
    Driver,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филиал")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filial")]
    [WbTranslate(LanguageIdConst.RU, "Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Branch")]
    Branch,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Текущая локация")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Жорий жойлашув")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Joriy joylashuv")]
    [WbTranslate(LanguageIdConst.RU, "Текущая локация")]
    [WbTranslate(LanguageIdConst.EN, "Present Location")]
    PresentTrackingInfo,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "История местоположений")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Жойлашув тарихи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Joylashuv tarixi")]
    [WbTranslate(LanguageIdConst.RU, "История местоположений")]
    [WbTranslate(LanguageIdConst.EN, "The history is mestopologenic")]
    TrackingInfo,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Уведомление")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Билдиришнома")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bildirishnoma")]
    [WbTranslate(LanguageIdConst.RU, "Уведомление")]
    [WbTranslate(LanguageIdConst.EN, "Notification")]
    Notification,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Текущее уведомление")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Мавжуд билдиришнома")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Mavjud bildirishnoma")]
    [WbTranslate(LanguageIdConst.RU, "Текущее уведомление")]
    [WbTranslate(LanguageIdConst.EN, "Present Notification")]
    PresentNotification,

    #endregion

    #region DOC
    [WbPermissionSubGroupField(PermissionGroupIdConst.DOCUMENTS, "Настройки транспорт")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Транспорт созламалари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport sozlamalari")]
    [WbTranslate(LanguageIdConst.RU, "Настройки транспорт")]
    [WbTranslate(LanguageIdConst.EN, "Transport settings")]
    TransportSetting,

    [WbPermissionSubGroupField(PermissionGroupIdConst.DOCUMENTS, "Заправка")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ёқилғи қуйиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yoqilg'i quyish")]
    [WbTranslate(LanguageIdConst.RU, "Заправка")]
    [WbTranslate(LanguageIdConst.EN, "Refueling")]
    Refuel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.DOCUMENTS, "Расходы на транспорт")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Транспорт харажатлари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport xarajatlari")]
    [WbTranslate(LanguageIdConst.RU, "Расходы на транспорт")]
    [WbTranslate(LanguageIdConst.EN, "Transport expenses")]
    Expense,

    [WbPermissionSubGroupField(PermissionGroupIdConst.DOCUMENTS, "Настройки шаблона уведомлений")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Билдиришнома шаблони созламалари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bildirishnoma shabloni sozlamalari")]
    [WbTranslate(LanguageIdConst.RU, "Настройки шаблона уведомлений")]
    [WbTranslate(LanguageIdConst.EN, "Notification Template Setting")]
    NotificationTemplateSetting,

    #endregion

    #region SYS

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Роль")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Роль")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Rol")]
    [WbTranslate(LanguageIdConst.RU, "Роль")]
    [WbTranslate(LanguageIdConst.EN, "Role")]
    Role,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Пользователь")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Фойдаланувчи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Foydalanuvchi")]
    [WbTranslate(LanguageIdConst.RU, "Пользователь")]
    [WbTranslate(LanguageIdConst.EN, "User")]
    User,
    #endregion

    #region REPORT
    [WbPermissionSubGroupField(PermissionGroupIdConst.REPORTS, "Штрафы водителей")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳайдовчи жарималари")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Haydovchi jarimalari")]
    [WbTranslate(LanguageIdConst.RU, "Штрафы водителей")]
    [WbTranslate(LanguageIdConst.EN, "Driver penalties")]
    DriverPenalty,

    [WbPermissionSubGroupField(PermissionGroupIdConst.REPORTS, "Оптимальный маршрут")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Энг қулай йўналиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Eng qulay yo'nalish")]
    [WbTranslate(LanguageIdConst.RU, "Оптимальный маршрут")]
    [WbTranslate(LanguageIdConst.EN, "Optimal route")]
    OptimalRoute,

    [WbPermissionSubGroupField(PermissionGroupIdConst.REPORTS, "Отчет о расходах")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Харажатлар ҳисоботи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Xarajatlar hisoboti")]
    [WbTranslate(LanguageIdConst.RU, "Отчет о расходах")]
    [WbTranslate(LanguageIdConst.EN, "Expense report")]
    ExpenseReport,

    #endregion

    #region FOR_DEVELOPERS
    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Разработчик")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Дастурчи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Dasturchi")]
    [WbTranslate(LanguageIdConst.RU, "Разработчик")]
    [WbTranslate(LanguageIdConst.EN, "Developer")]
    Developer
    #endregion
}
