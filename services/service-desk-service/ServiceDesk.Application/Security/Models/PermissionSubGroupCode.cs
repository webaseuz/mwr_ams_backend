using Bms.Core.Domain;
using Bms.WEBASE.Authorization;
using Bms.WEBASE.Translate;

namespace ServiceDesk.Application;

public enum PermissionSubGroupCode
{
    #region INFO
    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Страна")]
    [Translate(LanguageIdConst.UZ_CYRL, "Давлат")]
    [Translate(LanguageIdConst.UZ_LATN, "Davlat")]
    [Translate(LanguageIdConst.RU, "Страна")]
    [Translate(LanguageIdConst.EN, "Country")]
    Country,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Банк")]
    [Translate(LanguageIdConst.UZ_CYRL, "Банк")]
    [Translate(LanguageIdConst.UZ_LATN, "Bank")]
    [Translate(LanguageIdConst.RU, "Банк")]
    [Translate(LanguageIdConst.EN, "Bank")]
    Bank,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Валюта")]
    [Translate(LanguageIdConst.UZ_CYRL, "Валюта")]
    [Translate(LanguageIdConst.UZ_LATN, "Valyuta")]
    [Translate(LanguageIdConst.RU, "Валюта")]
    [Translate(LanguageIdConst.EN, "Currency")]
    Currency,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Гражданство")]
    [Translate(LanguageIdConst.UZ_CYRL, "Фукоролик")]
    [Translate(LanguageIdConst.UZ_LATN, "Fuqorolik")]
    [Translate(LanguageIdConst.RU, "Гражданство")]
    [Translate(LanguageIdConst.EN, "Citizenship")]
    Citizenship,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип медицинской услуги")]
    [Translate(LanguageIdConst.UZ_CYRL, "Тиббий хизмат тури")]
    [Translate(LanguageIdConst.UZ_LATN, "Tibbiy xizmat turi")]
    [Translate(LanguageIdConst.RU, "Тип медицинской услуги")]
    [Translate(LanguageIdConst.EN, "ServiceType")]
    ServiceType,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Национальность")]
    [Translate(LanguageIdConst.UZ_CYRL, "Миллати")]
    [Translate(LanguageIdConst.UZ_LATN, "Millati")]
    [Translate(LanguageIdConst.RU, "Национальность")]
    [Translate(LanguageIdConst.EN, "Nationality")]
    Nationality,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Район")]
    [Translate(LanguageIdConst.UZ_CYRL, "Туман")]
    [Translate(LanguageIdConst.UZ_LATN, "Tuman")]
    [Translate(LanguageIdConst.RU, "Район")]
    [Translate(LanguageIdConst.EN, "District")]
    District,


    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Организация")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ташкилот")]
    [Translate(LanguageIdConst.UZ_LATN, "Tashkilot")]
    [Translate(LanguageIdConst.RU, "Организация")]
    [Translate(LanguageIdConst.EN, "Organization")]
    Organization,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Область")]
    [Translate(LanguageIdConst.UZ_CYRL, "Вилоят")]
    [Translate(LanguageIdConst.UZ_LATN, "Viloyat")]
    [Translate(LanguageIdConst.RU, "Область")]
    [Translate(LanguageIdConst.EN, "Region")]
    Region,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Контрактор")]
    [Translate(LanguageIdConst.UZ_CYRL, "Контрактор")]
    [Translate(LanguageIdConst.UZ_LATN, "Kontraktor")]
    [Translate(LanguageIdConst.RU, "Контрактор")]
    [Translate(LanguageIdConst.EN, "Contractor")]
    Contractor,

	[PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип устройства")]
	[Translate(LanguageIdConst.UZ_CYRL, "Қурилма тури")]
	[Translate(LanguageIdConst.UZ_LATN, "Qurilma turi")]
	[Translate(LanguageIdConst.RU, "Тип устройства")]
	[Translate(LanguageIdConst.EN, "Device Type")]
	DeviceType,

	[PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип запасного устройства")]
	[Translate(LanguageIdConst.UZ_CYRL, "Қурилманинг захира тури")]
	[Translate(LanguageIdConst.UZ_LATN, "Qurilmaning zaxira turi")]
	[Translate(LanguageIdConst.RU, "Тип запасного устройства")]
	[Translate(LanguageIdConst.EN, "Device Spare Type")]
	DeviceSpareType,

	[PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Модель устройства")]
	[Translate(LanguageIdConst.UZ_CYRL, "Қурилма модели")]
	[Translate(LanguageIdConst.UZ_LATN, "Qurilma modeli")]
	[Translate(LanguageIdConst.RU, "Модель устройства")]
	[Translate(LanguageIdConst.EN, "Device Type")]
	DeviceModel,

	[PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Часть устройства")]
	[Translate(LanguageIdConst.UZ_CYRL, "Қурилма қисми")]
	[Translate(LanguageIdConst.UZ_LATN, "Qurilma qismi")]
	[Translate(LanguageIdConst.RU, "Часть устройства")]
	[Translate(LanguageIdConst.EN, "Device Part")]
	DevicePart,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Версия мобильного приложения")]
    [Translate(LanguageIdConst.UZ_CYRL, "Мобил илова версияси")]
    [Translate(LanguageIdConst.UZ_LATN, "Mobil ilova versiyasi")]
    [Translate(LanguageIdConst.RU, "Версия мобильного приложения")]
    [Translate(LanguageIdConst.EN, "Mobile App Version")]
    MobileAppVersion,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Цель применения")]
    [Translate(LanguageIdConst.UZ_CYRL, "Куллаш максади")]
    [Translate(LanguageIdConst.UZ_LATN, "Qo'llash maqsadi")]
    [Translate(LanguageIdConst.RU, "Цель применения")]
    [Translate(LanguageIdConst.EN, "Application purpose")]
    ApplicationPurpose,

    #endregion

    #region HL


    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Отдел")]
    [Translate(LanguageIdConst.UZ_CYRL, "Бўлим")]
    [Translate(LanguageIdConst.UZ_LATN, "Bo'lim")]
    [Translate(LanguageIdConst.RU, "Отдел")]
    [Translate(LanguageIdConst.EN, "Department")]
    Department,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Позиция")]
    [Translate(LanguageIdConst.UZ_CYRL, "Лавозим")]
    [Translate(LanguageIdConst.UZ_LATN, "Lavozim")]
    [Translate(LanguageIdConst.RU, "Позиция")]
    [Translate(LanguageIdConst.EN, "Position")]
    Position,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Персона")]
    [Translate(LanguageIdConst.UZ_CYRL, "Шахс")]
    [Translate(LanguageIdConst.UZ_LATN, "Shaxs")]
    [Translate(LanguageIdConst.RU, "Персона")]
    [Translate(LanguageIdConst.EN, "Person")]
    Person,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Устройство")]
    [Translate(LanguageIdConst.UZ_CYRL, "Қурилма")]
    [Translate(LanguageIdConst.UZ_LATN, "Qurilma")]
    [Translate(LanguageIdConst.RU, "Устройство")]
    [Translate(LanguageIdConst.EN, "Device")]
    Device,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Уведомление")]
    [Translate(LanguageIdConst.UZ_CYRL, "Билдиришнома")]
    [Translate(LanguageIdConst.UZ_LATN, "Bildirishnoma")]
    [Translate(LanguageIdConst.RU, "Уведомление")]
    [Translate(LanguageIdConst.EN, "Notification")]
    Notification,

    #endregion

    #region DOC
    [PermissionSubGroupDescription(PermissionGroupIdConst.DOCUMENTS, "Заявка на обслуживание")]
    [Translate(LanguageIdConst.UZ_CYRL, "Хизмат аризаси")]
    [Translate(LanguageIdConst.UZ_LATN, "Xizmat arizasi")]
    [Translate(LanguageIdConst.RU, "Заявка на обслуживание")]
    [Translate(LanguageIdConst.EN, "Service Application")]
    ServiceApplication,

	[PermissionSubGroupDescription(PermissionGroupIdConst.DOCUMENTS, "Запасное движение")]
	[Translate(LanguageIdConst.UZ_CYRL, "Захира ҳаракат")]
	[Translate(LanguageIdConst.UZ_LATN, "Zaxira harakat")]
	[Translate(LanguageIdConst.RU, "Запасное движение")]
	[Translate(LanguageIdConst.EN, "Spare Movement")]
	SpareMovement,

    [PermissionSubGroupDescription(PermissionGroupIdConst.DOCUMENTS, "Настройки шаблона уведомлений")]
    [Translate(LanguageIdConst.UZ_CYRL, "Билдиришнома шаблони созламалари")]
    [Translate(LanguageIdConst.UZ_LATN, "Bildirishnoma shabloni sozlamalari")]
    [Translate(LanguageIdConst.RU, "Настройки шаблона уведомлений")]
    [Translate(LanguageIdConst.EN, "Notification Template Setting")]
    NotificationTemplateSetting,

    #endregion

    #region SYS

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Роль")]
    [Translate(LanguageIdConst.UZ_CYRL, "Роль")]
    [Translate(LanguageIdConst.UZ_LATN, "Rol")]
    [Translate(LanguageIdConst.RU, "Роль")]
    [Translate(LanguageIdConst.EN, "Role")]
    Role,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Пользователь")]
    [Translate(LanguageIdConst.UZ_CYRL, "Фойдаланувчи")]
    [Translate(LanguageIdConst.UZ_LATN, "Foydalanuvchi")]
    [Translate(LanguageIdConst.RU, "Пользователь")]
    [Translate(LanguageIdConst.EN, "User")]
    User,
    #endregion

    #region REPORT
    [PermissionSubGroupDescription(PermissionGroupIdConst.REPORTS, "Отчёт об обороте запасных частей")]
    [Translate(LanguageIdConst.UZ_CYRL, "Захира айланмаси ҳисоботи")]
    [Translate(LanguageIdConst.UZ_LATN, "Zaxira aylanmasi hisoboti")]
    [Translate(LanguageIdConst.RU, "Отчёт об обороте запасных частей")]
    [Translate(LanguageIdConst.EN, "Spare Turnover report")]
    SpareTurnover,
    #endregion

    #region FOR_DEVELOPERS
    [PermissionSubGroupDescription(PermissionGroupIdConst.SYSTEM, "Разработчик")]
    [Translate(LanguageIdConst.UZ_CYRL, "Дастурчи")]
    [Translate(LanguageIdConst.UZ_LATN, "Dasturchi")]
    [Translate(LanguageIdConst.RU, "Разработчик")]
    [Translate(LanguageIdConst.EN, "Developer")]
    Developer
    #endregion
}
