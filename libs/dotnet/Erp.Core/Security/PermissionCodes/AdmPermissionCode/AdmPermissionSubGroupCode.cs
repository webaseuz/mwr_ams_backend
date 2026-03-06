using WEBASE;

namespace Erp.Core;

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

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Контрактор")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Контрактор")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Kontraktor")]
    [WbTranslate(LanguageIdConst.RU, "Контрактор")]
    [WbTranslate(LanguageIdConst.EN, "Contractor")]
    Contractor,

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

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филиал")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filial")]
    [WbTranslate(LanguageIdConst.RU, "Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Branch")]
    Branch,

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

    #region FOR_DEVELOPERS
    [WbPermissionSubGroupField(PermissionGroupIdConst.SYSTEM, "Разработчик")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Дастурчи")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Dasturchi")]
    [WbTranslate(LanguageIdConst.RU, "Разработчик")]
    [WbTranslate(LanguageIdConst.EN, "Developer")]
    Developer
    #endregion
}
