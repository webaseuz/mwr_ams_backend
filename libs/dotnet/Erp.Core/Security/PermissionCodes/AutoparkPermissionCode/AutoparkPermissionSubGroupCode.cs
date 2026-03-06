using WEBASE;

namespace Erp.Core;

public enum AutoparkPermissionSubGroupCode
{
    #region INFO
    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип топлива")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ёқилғи тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yoqilg'i turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип топлива")]
    [WbTranslate(LanguageIdConst.EN, "Fuel type")]
    FuelType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип страхования")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Суғурта тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Sug'urta turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип страхования")]
    [WbTranslate(LanguageIdConst.EN, "Insurance type")]
    InsuranceType,

    [WbPermissionSubGroupField(PermissionGroupIdConst.MANUALS, "Тип батареи")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Акумлятор тури")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Akumlyator turi")]
    [WbTranslate(LanguageIdConst.RU, "Тип батареи")]
    [WbTranslate(LanguageIdConst.EN, "BatteryType")]
    BatteryType,

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
    [WbTranslate(LanguageIdConst.UZ_LATN, "Shina o'lchami")]
    [WbTranslate(LanguageIdConst.RU, "Размер шин")]
    [WbTranslate(LanguageIdConst.EN, "Tire Size")]
    TireSize,
    #endregion

    #region HL
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
}
