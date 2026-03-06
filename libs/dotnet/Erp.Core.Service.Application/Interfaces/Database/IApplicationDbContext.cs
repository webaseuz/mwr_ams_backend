using Erp.Core.Security;
using Erp.Core.Service.Domain;
using Erp.Core.Service.Domain.Entities.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Erp.Core.Service.Application;

public interface IApplicationDbContext
{
    #region ADM

    // ENUM
    DbSet<State> States { get; set; }
    DbSet<StateTranslate> StateTranslates { get; set; }
    DbSet<Status> Statuses { get; set; }
    DbSet<StatusTranslate> StatusTranslates { get; set; }
    DbSet<Language> Languages { get; set; }
    DbSet<Gender> Genders { get; set; }
    DbSet<GenderTranslate> GenderTranslates { get; set; }
    DbSet<DocumentType> DocumentTypes { get; set; }
    DbSet<DocumentTypeTranslate> DocumentTypeTranslates { get; set; }
    DbSet<PlasticCardType> PlasticCardTypes { get; set; }
    DbSet<PlasticCardTypeTranslate> PlasticCardTypeTranslates { get; set; }
    DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    DbSet<NotificationTemplateTranslate> NotificationTempleteTranslates { get; set; }

    // INFO
    DbSet<Bank> Banks { get; set; }
    DbSet<BankTranslate> BankTranslates { get; set; }
    DbSet<Citizenship> Citizenships { get; set; }
    DbSet<CitizenshipTranslate> CitizenshipTranslates { get; set; }
    DbSet<Contractor> Contractors { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<CountryTranslate> CountryTranslates { get; set; }
    DbSet<Currency> Currencies { get; set; }
    DbSet<CurrencyTranslate> CurrencyTranslates { get; set; }
    DbSet<District> Districts { get; set; }
    DbSet<DistrictTranslate> DistrictTranslates { get; set; }
    DbSet<Nationality> Nationalities { get; set; }
    DbSet<NationalityTranslate> NationalityTranslates { get; set; }
    DbSet<Organization> Organizations { get; set; }
    DbSet<OrganizationTranslate> OrganizationTranslates { get; set; }
    DbSet<Region> Regions { get; set; }
    DbSet<RegionTranslate> RegionTranslates { get; set; }
    DbSet<MobileAppVersion> MobileAppVersions { get; set; }

    // SYS
    DbSet<Permission> Permissions { get; set; }
    DbSet<PermissionTranslate> PermissionTranslates { get; set; }
    DbSet<PermissionGroup> PermissionGroups { get; set; }
    DbSet<PermissionGroupTranslate> PermissionGroupTranslates { get; set; }
    DbSet<PermissionSubGroup> PermissionSubGroups { get; set; }
    DbSet<PermissionSubGroupTranslate> PermissionSubGroupTranslates { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<RoleTranslate> RoleTranslates { get; set; }
    DbSet<RolePermission> RolePermissions { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserLog> UserLogs { get; set; }
    DbSet<UserRole> UserRoles { get; set; }
    DbSet<UserToken> UserTokens { get; set; }
    DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    DbSet<Number> Numbers { get; set; }
    DbSet<RowChangeLog> RowChangeLogs { get; set; }

    // HL
    DbSet<Branch> Branches { get; set; }
    DbSet<Department> Departments { get; set; }
    DbSet<DepartmentTranslate> DepartmentTranslates { get; set; }
    DbSet<Person> People { get; set; }
    DbSet<Position> Positions { get; set; }
    DbSet<PositionTranslate> PositionTranslates { get; set; }
    DbSet<Notification> Notifications { get; set; }
    DbSet<PresentNotification> PresentNotifications { get; set; }
    DbSet<NumberTemplate> NumberTemplates { get; set; }

    // DOC
    DbSet<NotificationTemplateSetting> NotificationTemplateSettings { get; set; }
    DbSet<NotificationTemplateSettingRestrictedUser> NotificationTemplateSettingRestrictedUsers { get; set; }
    DbSet<NotificationTemplateSettingRole> NotificationTemplateSettingRoles { get; set; }
    DbSet<NotificationTemplateSettingUser> NotificationTemplateSettingUsers { get; set; }

    #endregion


    #region AUTOPARK

    // ENUM
    DbSet<ExpenseType> ExpenseTypes { get; set; }
    DbSet<ExpenseTypeTranslate> ExpenseTypeTranslates { get; set; }
    DbSet<TransmissionBoxType> TransmissionBoxTypes { get; set; }
    DbSet<TransmissionBoxTypeTranslate> TransmissionBoxTypeTranslates { get; set; }
    DbSet<InspectionType> InspectionTypes { get; set; }
    DbSet<InspectionTypeTranslate> InspectionTypeTranslates { get; set; }
    DbSet<TransportType> TransportTypes { get; set; }
    DbSet<TransportTypeTranslate> TransportTypeTranslates { get; set; }

    // INFO
    DbSet<BatteryType> BatteryTypes { get; set; }
    DbSet<BatteryTypeTranslate> BatteryTypeTranslates { get; set; }
    DbSet<FuelType> FuelTypes { get; set; }
    DbSet<FuelTypeTranslate> FuelTypeTranslates { get; set; }
    DbSet<InsuranceType> InsuranceTypes { get; set; }
    DbSet<InsuranceTypeTranslate> InsuranceTypeTranslates { get; set; }
    DbSet<LiquidType> LiquidTypes { get; set; }
    DbSet<LiquidTypeTranslate> LiquidTypeTranslates { get; set; }
    DbSet<OilModel> OilModels { get; set; }
    DbSet<OilModelTranslate> OilModelTranslates { get; set; }
    DbSet<OilType> OilTypes { get; set; }
    DbSet<OilTypeTranslate> OilTypeTranslates { get; set; }
    DbSet<TireModel> TireModels { get; set; }
    DbSet<TireModelTranslate> TireModelTranslates { get; set; }
    DbSet<TireSize> TireSizes { get; set; }
    DbSet<TransportBrand> TransportBrands { get; set; }
    DbSet<TransportBrandTranslate> TransportBrandTranslates { get; set; }
    DbSet<TransportColor> TransportColors { get; set; }
    DbSet<TransportColorTranslate> TransportColorTranslates { get; set; }
    DbSet<TransportModel> TransportModels { get; set; }
    DbSet<TransportModelTranslate> TransportModelTranslates { get; set; }
    DbSet<TransportModelLiquid> TransportModelLiquids { get; set; }
    DbSet<TransportUseType> TransportUseTypes { get; set; }
    DbSet<TransportUseTypeTranslate> TransportUseTypeTranslates { get; set; }

    // HL
    DbSet<Driver> Drivers { get; set; }
    DbSet<DriverDocument> DriverDocuments { get; set; }
    DbSet<FuelCard> FuelCards { get; set; }
    DbSet<Transport> Transports { get; set; }
    DbSet<TransportFile> TransportFiles { get; set; }
    DbSet<TransportModelFile> TransportModelFiles { get; set; }
    DbSet<TrackingInfo> TrackingInfos { get; set; }
    DbSet<PresentTrackingInfo> PresentTrackingInfos { get; set; }

    // DOC
    DbSet<Refuel> Refuels { get; set; }
    DbSet<RefuelFile> RefuelFiles { get; set; }
    DbSet<RefuelHistory> RefuelHistories { get; set; }
    DbSet<Expense> Expenses { get; set; }
    DbSet<ExpenseFile> ExpenseFiles { get; set; }
    DbSet<ExpenseHistory> ExpenseHistories { get; set; }
    DbSet<ExpenseBatteryFile> ExpenseBatteryFiles { get; set; }
    DbSet<ExpenseInspectionFile> ExpenseInspectionFiles { get; set; }
    DbSet<ExpenseInsuranceFile> ExpenseInsuranceFiles { get; set; }
    DbSet<ExpenseLiquidFile> ExpenseLiquidFiles { get; set; }
    DbSet<ExpenseOilFile> ExpenseOilFiles { get; set; }
    DbSet<ExpenseTireFile> ExpenseTireFiles { get; set; }
    DbSet<TransportSetting> TransportSettings { get; set; }
    DbSet<TransportSettingFile> TransportSettingFiles { get; set; }
    DbSet<TransportSettingHistory> TransportSettingHistorys { get; set; }
    DbSet<TransportSettingBattery> TransportSettingBatteries { get; set; }
    DbSet<TransportSettingFuel> TransportSettingFuels { get; set; }
    DbSet<TransportSettingInspection> TransportSettingInspections { get; set; }
    DbSet<TransportSettingInsurance> TransportSettingInsurances { get; set; }
    DbSet<TransportSettingLiquid> TransportSettingLiquids { get; set; }
    DbSet<TransportSettingOil> TransportSettingOils { get; set; }
    DbSet<TransportSettingTire> TransportSettingTires { get; set; }

    // ACC
    DbSet<DriverPenalty> DriverPenalties { get; set; }

    #endregion


    #region QR

    DbSet<CodeFormType> CodeFormTypes { get; set; }
    DbSet<QrCodeType> QrCodeTypes { get; set; }
    DbSet<QrCodeState> QrCodeStates { get; set; }
    DbSet<QrCodeRegistry> QrCodeRegistries { get; set; }
    DbSet<MachineReadableCodeSetting> MachineReadableCodeSettings { get; set; }
    DbSet<MachineReadableCodeSettingHistory> MachineReadableCodeSettingHistories { get; set; }
    DbSet<MachineReadableCodeSettingTable> MachineReadableCodeSettingTables { get; set; }

    #endregion


    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    void SetAuthService(IAuthService authService);
}
