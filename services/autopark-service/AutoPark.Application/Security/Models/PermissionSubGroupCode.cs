using Bms.Core.Domain;
using Bms.WEBASE.Authorization;
using Bms.WEBASE.Translate;

namespace AutoPark.Application;

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

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип топлива")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ёқилғи тури")]
    [Translate(LanguageIdConst.UZ_LATN, "Yoqilg‘i turi")]
    [Translate(LanguageIdConst.RU, "Тип топлива")]
    [Translate(LanguageIdConst.EN, "Fuel type")]
    FuelType,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип страхования")]
    [Translate(LanguageIdConst.UZ_CYRL, "Суғурта тури")]
    [Translate(LanguageIdConst.UZ_LATN, "Sug‘urta turi")]
    [Translate(LanguageIdConst.RU, "Тип страхования")]
    [Translate(LanguageIdConst.EN, "Insurance type")]
    InsuranceType,

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

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип батареи")]
    [Translate(LanguageIdConst.UZ_CYRL, "Акумлятор тури")]
    [Translate(LanguageIdConst.UZ_LATN, "Akumlyator turi")]
    [Translate(LanguageIdConst.RU, "Тип батареи")]
    [Translate(LanguageIdConst.EN, "BatteryType")]
    BatteryType,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Контрактор")]
    [Translate(LanguageIdConst.UZ_CYRL, "Контрактор")]
    [Translate(LanguageIdConst.UZ_LATN, "Kontraktor")]
    [Translate(LanguageIdConst.RU, "Контрактор")]
    [Translate(LanguageIdConst.EN, "Contractor")]
    Contractor,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Транспортная марка")]
    [Translate(LanguageIdConst.UZ_CYRL, "Транспорт бренди")]
    [Translate(LanguageIdConst.UZ_LATN, "Transport brendi")]
    [Translate(LanguageIdConst.RU, "Транспортная марка")]
    [Translate(LanguageIdConst.EN, "TransportBrand")]
    TransportBrand,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Цвет транспорта")]
    [Translate(LanguageIdConst.UZ_CYRL, "Транспорт ранги")]
    [Translate(LanguageIdConst.UZ_LATN, "Transport rangi")]
    [Translate(LanguageIdConst.RU, "Цвет транспорта")]
    [Translate(LanguageIdConst.EN, "TransportColor")]
    TransportColor,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип транспорта")]
    [Translate(LanguageIdConst.UZ_CYRL, "Транспорт тури")]
    [Translate(LanguageIdConst.UZ_LATN, "Transport turi")]
    [Translate(LanguageIdConst.RU, "Тип транспорта")]
    [Translate(LanguageIdConst.EN, "TransportType")]
    TransportType,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип использования транспорта")]
    [Translate(LanguageIdConst.UZ_CYRL, "Транспортдан фойдаланиш тури")]
    [Translate(LanguageIdConst.UZ_LATN, "Transportdan foydalanish turi")]
    [Translate(LanguageIdConst.RU, "Тип использования транспорта")]
    [Translate(LanguageIdConst.EN, "TransportUseType")]
    TransportUseType,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Модель транспорта")]
    [Translate(LanguageIdConst.UZ_CYRL, "Транспорт модели")]
    [Translate(LanguageIdConst.UZ_LATN, "Transport modeli")]
    [Translate(LanguageIdConst.RU, "Модель транспорта")]
    [Translate(LanguageIdConst.EN, "TransportModel")]
    TransportModel,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип масла")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ёғ тури")]
    [Translate(LanguageIdConst.UZ_LATN, "Yog' turi")]
    [Translate(LanguageIdConst.RU, "Тип масла")]
    [Translate(LanguageIdConst.EN, "Oil Type")]
    OilType,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Модель масла")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ёғ модели")]
    [Translate(LanguageIdConst.UZ_LATN, "Yog' modeli")]
    [Translate(LanguageIdConst.RU, "Модель масла")]
    [Translate(LanguageIdConst.EN, "Oil Model")]
    OilModel,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Модель шины")]
    [Translate(LanguageIdConst.UZ_CYRL, "Шина модели")]
    [Translate(LanguageIdConst.UZ_LATN, "Shina modeli")]
    [Translate(LanguageIdConst.RU, "Модель шины")]
    [Translate(LanguageIdConst.EN, "Tire Model")]
    TireModel,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Тип жидкости")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ёкилги тури")]
    [Translate(LanguageIdConst.UZ_LATN, "Yoqilg'i turi")]
    [Translate(LanguageIdConst.RU, "Тип жидкости")]
    [Translate(LanguageIdConst.EN, "Liquid Type")]
    LiquidType,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Размер шин")]
    [Translate(LanguageIdConst.UZ_CYRL, "Шина ўлчами")]
    [Translate(LanguageIdConst.UZ_LATN, "Shina o‘lchami")]
    [Translate(LanguageIdConst.RU, "Размер шин")]
    [Translate(LanguageIdConst.EN, "Tire Size")]
    TireSize,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Версия мобильного приложения")]
    [Translate(LanguageIdConst.UZ_CYRL, "Мобил илова версияси")]
    [Translate(LanguageIdConst.UZ_LATN, "Mobil ilova versiyasi")]
    [Translate(LanguageIdConst.RU, "Версия мобильного приложения")]
    [Translate(LanguageIdConst.EN, "Mobile App Version")]
    MobileAppVersion,
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

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Транспорт")]
    [Translate(LanguageIdConst.UZ_CYRL, "Транспорт")]
    [Translate(LanguageIdConst.UZ_LATN, "Transport")]
    [Translate(LanguageIdConst.RU, "Транспорт")]
    [Translate(LanguageIdConst.EN, "Transport")]
    Transport,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Топливная карта")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ёқилғи картаси")]
    [Translate(LanguageIdConst.UZ_LATN, "Yoqilg'i kartasi")]
    [Translate(LanguageIdConst.RU, "Топливная карта")]
    [Translate(LanguageIdConst.EN, "Fuel Card")]
    FuelCard,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Водитель")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳайдовчи")]
    [Translate(LanguageIdConst.UZ_LATN, "Haydovchi")]
    [Translate(LanguageIdConst.RU, "Водитель")]
    [Translate(LanguageIdConst.EN, "Driver")]
    Driver,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Филиал")]
    [Translate(LanguageIdConst.UZ_CYRL, "Филиал")]
    [Translate(LanguageIdConst.UZ_LATN, "Filial")]
    [Translate(LanguageIdConst.RU, "Филиал")]
    [Translate(LanguageIdConst.EN, "Branch")]
    Branch,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Текущая локация")]
    [Translate(LanguageIdConst.UZ_CYRL, "Жорий жойлашув")]
    [Translate(LanguageIdConst.UZ_LATN, "Joriy joylashuv")]
    [Translate(LanguageIdConst.RU, "Текущая локация")]
    [Translate(LanguageIdConst.EN, "Present Location")]
    PresentTrackingInfo,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "История местоположений")]
    [Translate(LanguageIdConst.UZ_CYRL, "Жойлашув тарихи")]
    [Translate(LanguageIdConst.UZ_LATN, "Joylashuv tarixi")]
    [Translate(LanguageIdConst.RU, "История местоположений")]
    [Translate(LanguageIdConst.EN, "The history is mestopologenic")]
    TrackingInfo,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Уведомление")]
    [Translate(LanguageIdConst.UZ_CYRL, "Билдиришнома")]
    [Translate(LanguageIdConst.UZ_LATN, "Bildirishnoma")]
    [Translate(LanguageIdConst.RU, "Уведомление")]
    [Translate(LanguageIdConst.EN, "Notification")]
    Notification,

    [PermissionSubGroupDescription(PermissionGroupIdConst.MANUALS, "Текущее уведомление")]
    [Translate(LanguageIdConst.UZ_CYRL, "Мавжуд билдиришнома")]
    [Translate(LanguageIdConst.UZ_LATN, "Mavjud bildirishnoma")]
    [Translate(LanguageIdConst.RU, "Текущее уведомление")]
    [Translate(LanguageIdConst.EN, "Present Notification")]
    PresentNotification,

    #endregion

    #region DOC
    [PermissionSubGroupDescription(PermissionGroupIdConst.DOCUMENTS, "Настройки транспорт")]
    [Translate(LanguageIdConst.UZ_CYRL, "Транспорт созламалари")]
    [Translate(LanguageIdConst.UZ_LATN, "Transport sozlamalari")]
    [Translate(LanguageIdConst.RU, "Настройки транспорт")]
    [Translate(LanguageIdConst.EN, "Transport settings")]
    TransportSetting,

    [PermissionSubGroupDescription(PermissionGroupIdConst.DOCUMENTS, "Заправка")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ёқилғи қуйиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Yoqilg'i quyish")]
    [Translate(LanguageIdConst.RU, "Заправка")]
    [Translate(LanguageIdConst.EN, "Refueling")]
    Refuel,

    [PermissionSubGroupDescription(PermissionGroupIdConst.DOCUMENTS, "Расходы на транспорт")]
    [Translate(LanguageIdConst.UZ_CYRL, "Транспорт харажатлари")]
    [Translate(LanguageIdConst.UZ_LATN, "Transport xarajatlari")]
    [Translate(LanguageIdConst.RU, "Расходы на транспорт")]
    [Translate(LanguageIdConst.EN, "Transport expenses")]
    Expense,

    [PermissionSubGroupDescription(PermissionGroupIdConst.DOCUMENTS, "Настройки шаблона уведомлений")]
    [Translate(LanguageIdConst.UZ_CYRL, "Билдиришнома шаблони созламалари")]
    [Translate(LanguageIdConst.UZ_LATN, "Bildirishnoma shabloni sozlamalari")]
    [Translate(LanguageIdConst.RU, "Настройки шаблона уведомлений")]
    [Translate(LanguageIdConst.EN, "Notification Template Setting")]
    NotificationTemplateSetting,

    #endregion

    #region SYS

    [PermissionSubGroupDescription(PermissionGroupIdConst.SYSTEM, "Роль")]
    [Translate(LanguageIdConst.UZ_CYRL, "Роль")]
    [Translate(LanguageIdConst.UZ_LATN, "Rol")]
    [Translate(LanguageIdConst.RU, "Роль")]
    [Translate(LanguageIdConst.EN, "Role")]
    Role,

    [PermissionSubGroupDescription(PermissionGroupIdConst.SYSTEM, "Пользователь")]
    [Translate(LanguageIdConst.UZ_CYRL, "Фойдаланувчи")]
    [Translate(LanguageIdConst.UZ_LATN, "Foydalanuvchi")]
    [Translate(LanguageIdConst.RU, "Пользователь")]
    [Translate(LanguageIdConst.EN, "User")]
    User,
    #endregion

    #region REPORT
    [PermissionSubGroupDescription(PermissionGroupIdConst.REPORTS, "Штрафы водителей")]
    [Translate(LanguageIdConst.UZ_CYRL, "Ҳайдовчи жарималари")]
    [Translate(LanguageIdConst.UZ_LATN, "Haydovchi jarimalari")]
    [Translate(LanguageIdConst.RU, "Штрафы водителей")]
    [Translate(LanguageIdConst.EN, "Driver penalties")]
    DriverPenalty,

    [PermissionSubGroupDescription(PermissionGroupIdConst.REPORTS, "Оптимальный маршрут")]
    [Translate(LanguageIdConst.UZ_CYRL, "Энг қулай йўналиш")]
    [Translate(LanguageIdConst.UZ_LATN, "Eng qulay yo'nalish")]
    [Translate(LanguageIdConst.RU, "Оптимальный маршрут")]
    [Translate(LanguageIdConst.EN, "Optimal route")]
    OptimalRoute,

    [PermissionSubGroupDescription(PermissionGroupIdConst.REPORTS, "Отчет о расходах")]
    [Translate(LanguageIdConst.UZ_CYRL, "Харажатлар ҳисоботи")]
    [Translate(LanguageIdConst.UZ_LATN, "Xarajatlar hisoboti")]
    [Translate(LanguageIdConst.RU, "Отчет о расходах")]
    [Translate(LanguageIdConst.EN, "Expense report")]
    ExpenseReport,

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
