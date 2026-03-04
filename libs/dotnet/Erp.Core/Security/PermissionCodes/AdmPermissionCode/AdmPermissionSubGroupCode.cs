using WEBASE;

namespace Erp.Core;

public enum AdmPermissionSubGroupCode
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
}

public enum PermissionSubGroupCode
{
    #region INFO
    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РЎС‚СЂР°РЅР°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р”Р°РІР»Р°С‚")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Davlat")]
    [WbTranslate(LanguageIdConst.RU, "РЎС‚СЂР°РЅР°")]
    [WbTranslate(LanguageIdConst.EN, "Country")]
    Country,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р‘Р°РЅРє")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘Р°РЅРє")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bank")]
    [WbTranslate(LanguageIdConst.RU, "Р‘Р°РЅРє")]
    [WbTranslate(LanguageIdConst.EN, "Bank")]
    Bank,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р’Р°Р»СЋС‚Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р’Р°Р»СЋС‚Р°")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Valyuta")]
    [WbTranslate(LanguageIdConst.RU, "Р’Р°Р»СЋС‚Р°")]
    [WbTranslate(LanguageIdConst.EN, "Currency")]
    Currency,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРёРї С‚РѕРїР»РёРІР°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЃТ›РёР»Т“Рё С‚СѓСЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "YoqilgвЂi turi")]
    [WbTranslate(LanguageIdConst.RU, "РўРёРї С‚РѕРїР»РёРІР°")]
    [WbTranslate(LanguageIdConst.EN, "Fuel type")]
    FuelType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРёРї СЃС‚СЂР°С…РѕРІР°РЅРёСЏ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЎСѓТ“СѓСЂС‚Р° С‚СѓСЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "SugвЂurta turi")]
    [WbTranslate(LanguageIdConst.RU, "РўРёРї СЃС‚СЂР°С…РѕРІР°РЅРёСЏ")]
    [WbTranslate(LanguageIdConst.EN, "Insurance type")]
    InsuranceType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р“СЂР°Р¶РґР°РЅСЃС‚РІРѕ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р¤СѓРєРѕСЂРѕР»РёРє")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Fuqorolik")]
    [WbTranslate(LanguageIdConst.RU, "Р“СЂР°Р¶РґР°РЅСЃС‚РІРѕ")]
    [WbTranslate(LanguageIdConst.EN, "Citizenship")]
    Citizenship,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРёРї РјРµРґРёС†РёРЅСЃРєРѕР№ СѓСЃР»СѓРіРё")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўРёР±Р±РёР№ С…РёР·РјР°С‚ С‚СѓСЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tibbiy xizmat turi")]
    [WbTranslate(LanguageIdConst.RU, "РўРёРї РјРµРґРёС†РёРЅСЃРєРѕР№ СѓСЃР»СѓРіРё")]
    [WbTranslate(LanguageIdConst.EN, "ServiceType")]
    ServiceType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РќР°С†РёРѕРЅР°Р»СЊРЅРѕСЃС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РњРёР»Р»Р°С‚Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Millati")]
    [WbTranslate(LanguageIdConst.RU, "РќР°С†РёРѕРЅР°Р»СЊРЅРѕСЃС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Nationality")]
    Nationality,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р Р°Р№РѕРЅ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСѓРјР°РЅ")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tuman")]
    [WbTranslate(LanguageIdConst.RU, "Р Р°Р№РѕРЅ")]
    [WbTranslate(LanguageIdConst.EN, "District")]
    District,


    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РћСЂРіР°РЅРёР·Р°С†РёСЏ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўР°С€РєРёР»РѕС‚")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tashkilot")]
    [WbTranslate(LanguageIdConst.RU, "РћСЂРіР°РЅРёР·Р°С†РёСЏ")]
    [WbTranslate(LanguageIdConst.EN, "Organization")]
    Organization,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РћР±Р»Р°СЃС‚СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р’РёР»РѕСЏС‚")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Viloyat")]
    [WbTranslate(LanguageIdConst.RU, "РћР±Р»Р°СЃС‚СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Region")]
    Region,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРёРї Р±Р°С‚Р°СЂРµРё")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РђРєСѓРјР»СЏС‚РѕСЂ С‚СѓСЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Akumlyator turi")]
    [WbTranslate(LanguageIdConst.RU, "РўРёРї Р±Р°С‚Р°СЂРµРё")]
    [WbTranslate(LanguageIdConst.EN, "BatteryType")]
    BatteryType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РљРѕРЅС‚СЂР°РєС‚РѕСЂ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РљРѕРЅС‚СЂР°РєС‚РѕСЂ")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Kontraktor")]
    [WbTranslate(LanguageIdConst.RU, "РљРѕРЅС‚СЂР°РєС‚РѕСЂ")]
    [WbTranslate(LanguageIdConst.EN, "Contractor")]
    Contractor,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўСЂР°РЅСЃРїРѕСЂС‚РЅР°СЏ РјР°СЂРєР°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСЂР°РЅСЃРїРѕСЂС‚ Р±СЂРµРЅРґРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport brendi")]
    [WbTranslate(LanguageIdConst.RU, "РўСЂР°РЅСЃРїРѕСЂС‚РЅР°СЏ РјР°СЂРєР°")]
    [WbTranslate(LanguageIdConst.EN, "TransportBrand")]
    TransportBrand,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р¦РІРµС‚ С‚СЂР°РЅСЃРїРѕСЂС‚Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСЂР°РЅСЃРїРѕСЂС‚ СЂР°РЅРіРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport rangi")]
    [WbTranslate(LanguageIdConst.RU, "Р¦РІРµС‚ С‚СЂР°РЅСЃРїРѕСЂС‚Р°")]
    [WbTranslate(LanguageIdConst.EN, "TransportColor")]
    TransportColor,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРёРї С‚СЂР°РЅСЃРїРѕСЂС‚Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСЂР°РЅСЃРїРѕСЂС‚ С‚СѓСЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport turi")]
    [WbTranslate(LanguageIdConst.RU, "РўРёРї С‚СЂР°РЅСЃРїРѕСЂС‚Р°")]
    [WbTranslate(LanguageIdConst.EN, "TransportType")]
    TransportType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРёРї РёСЃРїРѕР»СЊР·РѕРІР°РЅРёСЏ С‚СЂР°РЅСЃРїРѕСЂС‚Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСЂР°РЅСЃРїРѕСЂС‚РґР°РЅ С„РѕР№РґР°Р»Р°РЅРёС€ С‚СѓСЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transportdan foydalanish turi")]
    [WbTranslate(LanguageIdConst.RU, "РўРёРї РёСЃРїРѕР»СЊР·РѕРІР°РЅРёСЏ С‚СЂР°РЅСЃРїРѕСЂС‚Р°")]
    [WbTranslate(LanguageIdConst.EN, "TransportUseType")]
    TransportUseType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РњРѕРґРµР»СЊ С‚СЂР°РЅСЃРїРѕСЂС‚Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСЂР°РЅСЃРїРѕСЂС‚ РјРѕРґРµР»Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport modeli")]
    [WbTranslate(LanguageIdConst.RU, "РњРѕРґРµР»СЊ С‚СЂР°РЅСЃРїРѕСЂС‚Р°")]
    [WbTranslate(LanguageIdConst.EN, "TransportModel")]
    TransportModel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРёРї РјР°СЃР»Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЃТ“ С‚СѓСЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yog' turi")]
    [WbTranslate(LanguageIdConst.RU, "РўРёРї РјР°СЃР»Р°")]
    [WbTranslate(LanguageIdConst.EN, "Oil Type")]
    OilType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РњРѕРґРµР»СЊ РјР°СЃР»Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЃТ“ РјРѕРґРµР»Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yog' modeli")]
    [WbTranslate(LanguageIdConst.RU, "РњРѕРґРµР»СЊ РјР°СЃР»Р°")]
    [WbTranslate(LanguageIdConst.EN, "Oil Model")]
    OilModel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РњРѕРґРµР»СЊ С€РёРЅС‹")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЁРёРЅР° РјРѕРґРµР»Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shina modeli")]
    [WbTranslate(LanguageIdConst.RU, "РњРѕРґРµР»СЊ С€РёРЅС‹")]
    [WbTranslate(LanguageIdConst.EN, "Tire Model")]
    TireModel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРёРї Р¶РёРґРєРѕСЃС‚Рё")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЃРєРёР»РіРё С‚СѓСЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yoqilg'i turi")]
    [WbTranslate(LanguageIdConst.RU, "РўРёРї Р¶РёРґРєРѕСЃС‚Рё")]
    [WbTranslate(LanguageIdConst.EN, "Liquid Type")]
    LiquidType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р Р°Р·РјРµСЂ С€РёРЅ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЁРёРЅР° СћР»С‡Р°РјРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shina oвЂlchami")]
    [WbTranslate(LanguageIdConst.RU, "Р Р°Р·РјРµСЂ С€РёРЅ")]
    [WbTranslate(LanguageIdConst.EN, "Tire Size")]
    TireSize,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р’РµСЂСЃРёСЏ РјРѕР±РёР»СЊРЅРѕРіРѕ РїСЂРёР»РѕР¶РµРЅРёСЏ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РњРѕР±РёР» РёР»РѕРІР° РІРµСЂСЃРёСЏСЃРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Mobil ilova versiyasi")]
    [WbTranslate(LanguageIdConst.RU, "Р’РµСЂСЃРёСЏ РјРѕР±РёР»СЊРЅРѕРіРѕ РїСЂРёР»РѕР¶РµРЅРёСЏ")]
    [WbTranslate(LanguageIdConst.EN, "Mobile App Version")]
    MobileAppVersion,
    #endregion

    #region HL


    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РћС‚РґРµР»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘СћР»РёРј")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bo'lim")]
    [WbTranslate(LanguageIdConst.RU, "РћС‚РґРµР»")]
    [WbTranslate(LanguageIdConst.EN, "Department")]
    Department,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РџРѕР·РёС†РёСЏ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р›Р°РІРѕР·РёРј")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Lavozim")]
    [WbTranslate(LanguageIdConst.RU, "РџРѕР·РёС†РёСЏ")]
    [WbTranslate(LanguageIdConst.EN, "Position")]
    Position,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РџРµСЂСЃРѕРЅР°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЁР°С…СЃ")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shaxs")]
    [WbTranslate(LanguageIdConst.RU, "РџРµСЂСЃРѕРЅР°")]
    [WbTranslate(LanguageIdConst.EN, "Person")]
    Person,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўСЂР°РЅСЃРїРѕСЂС‚")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСЂР°РЅСЃРїРѕСЂС‚")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport")]
    [WbTranslate(LanguageIdConst.RU, "РўСЂР°РЅСЃРїРѕСЂС‚")]
    [WbTranslate(LanguageIdConst.EN, "Transport")]
    Transport,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРѕРїР»РёРІРЅР°СЏ РєР°СЂС‚Р°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЃТ›РёР»Т“Рё РєР°СЂС‚Р°СЃРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yoqilg'i kartasi")]
    [WbTranslate(LanguageIdConst.RU, "РўРѕРїР»РёРІРЅР°СЏ РєР°СЂС‚Р°")]
    [WbTranslate(LanguageIdConst.EN, "Fuel Card")]
    FuelCard,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р’РѕРґРёС‚РµР»СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°Р№РґРѕРІС‡Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Haydovchi")]
    [WbTranslate(LanguageIdConst.RU, "Р’РѕРґРёС‚РµР»СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Driver")]
    Driver,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filial")]
    [WbTranslate(LanguageIdConst.RU, "Р¤РёР»РёР°Р»")]
    [WbTranslate(LanguageIdConst.EN, "Branch")]
    Branch,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРµРєСѓС‰Р°СЏ Р»РѕРєР°С†РёСЏ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р–РѕСЂРёР№ Р¶РѕР№Р»Р°С€СѓРІ")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Joriy joylashuv")]
    [WbTranslate(LanguageIdConst.RU, "РўРµРєСѓС‰Р°СЏ Р»РѕРєР°С†РёСЏ")]
    [WbTranslate(LanguageIdConst.EN, "Present Location")]
    PresentTrackingInfo,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РСЃС‚РѕСЂРёСЏ РјРµСЃС‚РѕРїРѕР»РѕР¶РµРЅРёР№")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р–РѕР№Р»Р°С€СѓРІ С‚Р°СЂРёС…Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Joylashuv tarixi")]
    [WbTranslate(LanguageIdConst.RU, "РСЃС‚РѕСЂРёСЏ РјРµСЃС‚РѕРїРѕР»РѕР¶РµРЅРёР№")]
    [WbTranslate(LanguageIdConst.EN, "The history is mestopologenic")]
    TrackingInfo,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РЈРІРµРґРѕРјР»РµРЅРёРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘РёР»РґРёСЂРёС€РЅРѕРјР°")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bildirishnoma")]
    [WbTranslate(LanguageIdConst.RU, "РЈРІРµРґРѕРјР»РµРЅРёРµ")]
    [WbTranslate(LanguageIdConst.EN, "Notification")]
    Notification,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "РўРµРєСѓС‰РµРµ СѓРІРµРґРѕРјР»РµРЅРёРµ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РњР°РІР¶СѓРґ Р±РёР»РґРёСЂРёС€РЅРѕРјР°")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Mavjud bildirishnoma")]
    [WbTranslate(LanguageIdConst.RU, "РўРµРєСѓС‰РµРµ СѓРІРµРґРѕРјР»РµРЅРёРµ")]
    [WbTranslate(LanguageIdConst.EN, "Present Notification")]
    PresentNotification,

    #endregion

    #region DOC
    [WbPermissionSubGroupField(PermissionGroupIdConst.DOCUMENTS, "РќР°СЃС‚СЂРѕР№РєРё С‚СЂР°РЅСЃРїРѕСЂС‚")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСЂР°РЅСЃРїРѕСЂС‚ СЃРѕР·Р»Р°РјР°Р»Р°СЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport sozlamalari")]
    [WbTranslate(LanguageIdConst.RU, "РќР°СЃС‚СЂРѕР№РєРё С‚СЂР°РЅСЃРїРѕСЂС‚")]
    [WbTranslate(LanguageIdConst.EN, "Transport settings")]
    TransportSetting,

    [WbPermissionSubGroupField(PermissionGroupIdConst.DOCUMENTS, "Р—Р°РїСЂР°РІРєР°")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РЃТ›РёР»Т“Рё Т›СѓР№РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yoqilg'i quyish")]
    [WbTranslate(LanguageIdConst.RU, "Р—Р°РїСЂР°РІРєР°")]
    [WbTranslate(LanguageIdConst.EN, "Refueling")]
    Refuel,

    [WbPermissionSubGroupField(PermissionGroupIdConst.DOCUMENTS, "Р Р°СЃС…РѕРґС‹ РЅР° С‚СЂР°РЅСЃРїРѕСЂС‚")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РўСЂР°РЅСЃРїРѕСЂС‚ С…Р°СЂР°Р¶Р°С‚Р»Р°СЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Transport xarajatlari")]
    [WbTranslate(LanguageIdConst.RU, "Р Р°СЃС…РѕРґС‹ РЅР° С‚СЂР°РЅСЃРїРѕСЂС‚")]
    [WbTranslate(LanguageIdConst.EN, "Transport expenses")]
    Expense,

    [WbPermissionSubGroupField(PermissionGroupIdConst.DOCUMENTS, "РќР°СЃС‚СЂРѕР№РєРё С€Р°Р±Р»РѕРЅР° СѓРІРµРґРѕРјР»РµРЅРёР№")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р‘РёР»РґРёСЂРёС€РЅРѕРјР° С€Р°Р±Р»РѕРЅРё СЃРѕР·Р»Р°РјР°Р»Р°СЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bildirishnoma shabloni sozlamalari")]
    [WbTranslate(LanguageIdConst.RU, "РќР°СЃС‚СЂРѕР№РєРё С€Р°Р±Р»РѕРЅР° СѓРІРµРґРѕРјР»РµРЅРёР№")]
    [WbTranslate(LanguageIdConst.EN, "Notification Template Setting")]
    NotificationTemplateSetting,

    #endregion

    #region SYS

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Р РѕР»СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р РѕР»СЊ")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Rol")]
    [WbTranslate(LanguageIdConst.RU, "Р РѕР»СЊ")]
    [WbTranslate(LanguageIdConst.EN, "Role")]
    Role,

    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "РџРѕР»СЊР·РѕРІР°С‚РµР»СЊ")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р¤РѕР№РґР°Р»Р°РЅСѓРІС‡Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Foydalanuvchi")]
    [WbTranslate(LanguageIdConst.RU, "РџРѕР»СЊР·РѕРІР°С‚РµР»СЊ")]
    [WbTranslate(LanguageIdConst.EN, "User")]
    User,
    #endregion

    #region REPORT
    [WbPermissionSubGroupField(PermissionGroupIdConst.REPORTS, "РЁС‚СЂР°С„С‹ РІРѕРґРёС‚РµР»РµР№")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "ТІР°Р№РґРѕРІС‡Рё Р¶Р°СЂРёРјР°Р»Р°СЂРё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Haydovchi jarimalari")]
    [WbTranslate(LanguageIdConst.RU, "РЁС‚СЂР°С„С‹ РІРѕРґРёС‚РµР»РµР№")]
    [WbTranslate(LanguageIdConst.EN, "Driver penalties")]
    DriverPenalty,

    [WbPermissionSubGroupField(PermissionGroupIdConst.REPORTS, "РћРїС‚РёРјР°Р»СЊРЅС‹Р№ РјР°СЂС€СЂСѓС‚")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р­РЅРі Т›СѓР»Р°Р№ Р№СћРЅР°Р»РёС€")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Eng qulay yo'nalish")]
    [WbTranslate(LanguageIdConst.RU, "РћРїС‚РёРјР°Р»СЊРЅС‹Р№ РјР°СЂС€СЂСѓС‚")]
    [WbTranslate(LanguageIdConst.EN, "Optimal route")]
    OptimalRoute,

    [WbPermissionSubGroupField(PermissionGroupIdConst.REPORTS, "РћС‚С‡РµС‚ Рѕ СЂР°СЃС…РѕРґР°С…")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "РҐР°СЂР°Р¶Р°С‚Р»Р°СЂ ТіРёСЃРѕР±РѕС‚Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Xarajatlar hisoboti")]
    [WbTranslate(LanguageIdConst.RU, "РћС‚С‡РµС‚ Рѕ СЂР°СЃС…РѕРґР°С…")]
    [WbTranslate(LanguageIdConst.EN, "Expense report")]
    ExpenseReport,

    #endregion

    #region FOR_DEVELOPERS
    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Р Р°Р·СЂР°Р±РѕС‚С‡РёРє")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Р”Р°СЃС‚СѓСЂС‡Рё")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Dasturchi")]
    [WbTranslate(LanguageIdConst.RU, "Р Р°Р·СЂР°Р±РѕС‚С‡РёРє")]
    [WbTranslate(LanguageIdConst.EN, "Developer")]
    Developer
    #endregion
}
