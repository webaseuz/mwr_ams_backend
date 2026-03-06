using WEBASE;

namespace Erp.Core;

[WbPermissionEnum(AppIdConst.AUTOPARK)]
public enum AutoparkPermissionCode
{
    #region INFO

    #region FuelType
    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    FuelTypeView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    FuelTypeCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    FuelTypeEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    FuelTypeDelete,
    #endregion

    #region InsuranceType
    [WbPermissionField(AutoparkPermissionSubGroupCode.InsuranceType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    InsuranceTypeView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.InsuranceType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    InsuranceTypeCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.InsuranceType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    InsuranceTypeEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.InsuranceType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    InsuranceTypeDelete,
    #endregion

    #region BatteryType
    [WbPermissionField(AutoparkPermissionSubGroupCode.BatteryType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    BatteryTypeView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.BatteryType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    BatteryTypeCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.BatteryType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    BatteryTypeEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.BatteryType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    BatteryTypeDelete,
    #endregion

    #region TransportBrand
    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportBrand, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportBrandView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportBrand, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportBrandCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportBrand, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportBrandEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportBrand, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportBrandDelete,
    #endregion

    #region TransportColor
    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportColor, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportColorView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportColor, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportColorCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportColor, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportColorEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportColor, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportColorDelete,
    #endregion

    #region TransportType
    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportTypeView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportTypeCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportTypeEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportTypeDelete,
    #endregion

    #region TransportUseType
    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportUseType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportUseTypeView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportUseType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportUseTypeCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportUseType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportUseTypeEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportUseType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportUseTypeDelete,
    #endregion

    #region TransportModel
    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportModel, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportModelView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportModel, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportModelCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportModel, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportModelEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportModel, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportModelDelete,
    #endregion

    #region OilType
    [WbPermissionField(AutoparkPermissionSubGroupCode.OilType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OilTypeView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.OilType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OilTypeCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.OilType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OilTypeEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.OilType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OilTypeDelete,
    #endregion

    #region LiquidType
    [WbPermissionField(AutoparkPermissionSubGroupCode.LiquidType, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    LiquidTypeView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.LiquidType, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    LiquidTypeCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.LiquidType, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    LiquidTypeEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.LiquidType, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    LiquidTypeDelete,
    #endregion

    #region OilModel
    [WbPermissionField(AutoparkPermissionSubGroupCode.OilModel, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    OilModelView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.OilModel, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    OilModelCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.OilModel, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    OilModelEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.OilModel, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    OilModelDelete,
    #endregion

    #region TireModel
    [WbPermissionField(AutoparkPermissionSubGroupCode.TireModel, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TireModelView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TireModel, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TireModelCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TireModel, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TireModelEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TireModel, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TireModelDelete,
    #endregion

    #region TireSize
    [WbPermissionField(AutoparkPermissionSubGroupCode.TireSize, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TireSizeView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TireSize, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TireSizeCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TireSize, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TireSizeEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TireSize, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TireSizeDelete,
    #endregion

    #endregion

    #region HL

    #region Transport
    [WbPermissionField(AutoparkPermissionSubGroupCode.Transport, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Transport, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филиалдаги барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filialdagi barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.EN, "View all in branch")]
    TransportBranchView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Transport, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllViewTransport,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Transport, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Transport, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    TransportCreateForAllBranch,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Transport, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Transport, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportDelete,
    #endregion

    #region Driver
    [WbPermissionField(AutoparkPermissionSubGroupCode.Driver, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DriverView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Driver, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филиалдаги барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filialdagi barchasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.EN, "View all in branch")]
    DriverBranchView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Driver, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    AllViewDriver,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Driver, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    DriverCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Driver, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    DriverEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Driver, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    DriverDelete,
    #endregion

    #region FuelCard
    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelCard, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    FuelCardView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelCard, "Просмотр всех")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barchasibni ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр всех")]
    [WbTranslate(LanguageIdConst.EN, "View all")]
    FuelCardViewAll,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelCard, "Просмотр в масштабе филиала")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филиал миқёсида кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Filial miqyosida ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр в масштабе филиала")]
    [WbTranslate(LanguageIdConst.EN, "Branch View")]
    FuelCardViewBranch,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelCard, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    FuelCardCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelCard, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    FuelCardEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelCard, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    FuelCardDelete,

    [WbPermissionField(AutoparkPermissionSubGroupCode.FuelCard, "Создать все ветки")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Барча бранчларни ярата олиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Barcha branchlarni yarata olish")]
    [WbTranslate(LanguageIdConst.RU, "Создать все ветки")]
    [WbTranslate(LanguageIdConst.EN, "Create FuelCard For All Branch")]
    CreateFuelCardForAllBranch,
    #endregion

    #region PresentTrackingInfo
    [WbPermissionField(AutoparkPermissionSubGroupCode.PresentTrackingInfo, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    PresentTrackingInfoView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.PresentTrackingInfo, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    PresentTrackingInfoCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.PresentTrackingInfo, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    PresentTrackingInfoEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.PresentTrackingInfo, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    PresentTrackingInfoDelete,
    #endregion

    #region TrackingInfo
    [WbPermissionField(AutoparkPermissionSubGroupCode.TrackingInfo, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TrackingInfoView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TrackingInfo, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TrackingInfoCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TrackingInfo, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TrackingInfoEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TrackingInfo, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TrackingInfoDelete,
    #endregion

    #endregion

    #region DOC

    #region TransportSetting
    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    TransportSettingView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    TransportSettingViewAll,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Просмотр филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Филлял бўйича кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Fillyal bo'yicha ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр филиал")]
    [WbTranslate(LanguageIdConst.EN, "View by branch")]
    TransportSettingViewByBranch,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Просмотр по водителю")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Хайдовчи бўйича кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Xaydovchi bo'yicha ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр по водителю")]
    [WbTranslate(LanguageIdConst.EN, "View by driver")]
    TransportSettingViewByDriver,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    TransportSettingCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    TransportSettingEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Принимать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Қабул қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Qabul qilish")]
    [WbTranslate(LanguageIdConst.RU, "Принимать")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    TransportSettingAccept,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Отмена")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отмена")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    TransportSettingCancel,

    [WbPermissionField(AutoparkPermissionSubGroupCode.TransportSetting, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    TransportSettingDelete,
    #endregion

    #region Refuel
    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотреть все в филиал")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    RefuelBranchView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    RefuelViewAll,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    RefuelView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    RefuelCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    RefuelEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    RefuelDelete,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Принятие")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [WbTranslate(LanguageIdConst.RU, "Принятие")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    RefuelAccept,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Отменить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отменить")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    RefuelCancel,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Oтправлять")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Юбориш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [WbTranslate(LanguageIdConst.RU, "Oтправлять")]
    [WbTranslate(LanguageIdConst.EN, "Send")]
    RefuelSend,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Отозвать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отозвать")]
    [WbTranslate(LanguageIdConst.EN, "Revoke")]
    RefuelRevoke,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Refuel, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    RefuelCreateForAllBranch,
    #endregion

    #region Expense
    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Просмотр все")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳаммасини кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hammasini ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр все")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    AllViewExpense,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ExpenseView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Создать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать")]
    [WbTranslate(LanguageIdConst.EN, "Create")]
    ExpenseCreate,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Редактировать")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
    [WbTranslate(LanguageIdConst.RU, "Редактировать")]
    [WbTranslate(LanguageIdConst.EN, "Edit")]
    ExpenseEdit,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Удалить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "O'chirish")]
    [WbTranslate(LanguageIdConst.RU, "Удалить")]
    [WbTranslate(LanguageIdConst.EN, "Delete")]
    ExpenseDelete,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Принятие")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Қабул қилиш")]
    [WbTranslate(LanguageIdConst.RU, "Принятие")]
    [WbTranslate(LanguageIdConst.EN, "Accept")]
    ExpenseAccept,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Отменить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отменить")]
    [WbTranslate(LanguageIdConst.EN, "Cancel")]
    ExpenselCancel,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Oтправлять")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Юбориш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Yuborish")]
    [WbTranslate(LanguageIdConst.RU, "Oтправлять")]
    [WbTranslate(LanguageIdConst.EN, "Send")]
    ExpenseSend,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Отменить")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Бекор қилиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Bekor qilish")]
    [WbTranslate(LanguageIdConst.RU, "Отменить")]
    [WbTranslate(LanguageIdConst.EN, "Revoke")]
    ExpenseRevoke,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳамма филиаллар учун яратиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hamma filiallar uchun yaratish")]
    [WbTranslate(LanguageIdConst.RU, "Создать для всех Филиал")]
    [WbTranslate(LanguageIdConst.EN, "Create for all branches")]
    ExpenseCreateForAllBranch,

    [WbPermissionField(AutoparkPermissionSubGroupCode.Expense, "Прикрепить счет-фактуру")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Ҳисоб-фактура бириктириш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Hisob-faktura biriktirish")]
    [WbTranslate(LanguageIdConst.RU, "Прикрепить счет-фактуру")]
    [WbTranslate(LanguageIdConst.EN, "Invoice attach")]
    InvoiceAttach,
    #endregion

    #endregion

    #region REPORT

    #region DriverPenalty
    [WbPermissionField(AutoparkPermissionSubGroupCode.DriverPenalty, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    DriverPenaltyView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.DriverPenalty, "Просмотр (Только собственный филиал)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш (Фақат ўз филиали)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Faqat o'z filiali)")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр (Только собственный филиал)")]
    [WbTranslate(LanguageIdConst.EN, "View branch")]
    DriverPenaltyBranchView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.DriverPenalty, "Просмотр (Все филиалы)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш (Барча филиаллар)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Barcha filiallar)")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр (Все филиалы)")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    DriverPenaltyAllView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.DriverPenalty, "Оплата штрафа")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Жарима учун тўлов")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Jarima uchun to'lov")]
    [WbTranslate(LanguageIdConst.RU, "Оплата штрафа")]
    [WbTranslate(LanguageIdConst.EN, "Driver penalty pay")]
    DriverPenaltyPay,
    #endregion

    [WbPermissionField(AutoparkPermissionSubGroupCode.OptimalRoute, "Оптимальный маршрут")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Энг қулай йўналиш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Eng qulay yo'nalish")]
    [WbTranslate(LanguageIdConst.RU, "Оптимальный маршрут")]
    [WbTranslate(LanguageIdConst.EN, "Optimal route")]
    OptimalRoute,

    #region ExpenseReport
    [WbPermissionField(AutoparkPermissionSubGroupCode.ExpenseReport, "Просмотр")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр")]
    [WbTranslate(LanguageIdConst.EN, "View")]
    ExpenseReportView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.ExpenseReport, "Просмотр (Только собственный филиал)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш (Фақат ўз филиали)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Faqat o'z filiali)")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр (Только собственный филиал)")]
    [WbTranslate(LanguageIdConst.EN, "View branch")]
    ExpenseReportBranchView,

    [WbPermissionField(AutoparkPermissionSubGroupCode.ExpenseReport, "Просмотр (Все филиалы)")]
    [WbTranslate(LanguageIdConst.UZ_CYRL, "Кўриш (Барча филиаллар)")]
    [WbTranslate(LanguageIdConst.UZ_LATN, "Ko'rish (Barcha filiallar)")]
    [WbTranslate(LanguageIdConst.RU, "Просмотр (Все филиалы)")]
    [WbTranslate(LanguageIdConst.EN, "View All")]
    ExpenseReportAllView,
    #endregion

    #endregion
}
