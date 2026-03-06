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
