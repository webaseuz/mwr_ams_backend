using AutoPark.Application.UseCases.ExpenseLimits;
using AutoPark.Application.UseCases.Report;
using AutoPark.Domain;
using AutoPark.Domain.Entities.Sys;
using Bms.WEBASE.EF;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application;

public class ReadEfCoreContext :
    AuditableDbContext,
    IReadEfCoreContext
{
    public ReadEfCoreContext(DbContextOptions<ReadEfCoreContext> options) :
        base(options)
    { }

    #region ENUM
    public virtual DbSet<TransmissionBoxType> TransmissionBoxTypes { get; set; }
    public virtual DbSet<TransmissionBoxTypeTranslate> TransmissionBoxTypeTranslates { get; set; }
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<State> States { get; set; }
    public virtual DbSet<StateTranslate> StateTranslates { get; set; }
    public virtual DbSet<DocumentType> DocumentTypes { get; set; }
    public virtual DbSet<DocumentTypeTranslate> DocumentTypeTranslates { get; set; }
    public virtual DbSet<Gender> Genders { get; set; }
    public virtual DbSet<GenderTranslate> GenderTranslates { get; set; }
    public virtual DbSet<InspectionType> InspectionTypes { get; set; }
    public virtual DbSet<InspectionTypeTranslate> InspectionTypeTranslates { get; set; }
    public virtual DbSet<Status> Statuses { get; set; }
    public virtual DbSet<StatusTranslate> StatusTranslates { get; set; }
    public virtual DbSet<PlasticCardType> PlasticCardTypes { get; set; }
    public virtual DbSet<PlasticCardTypeTranslate> PlasticCardTypeTranslates { get; set; }
    public virtual DbSet<CodeFormType> CodeFormTypes { get; set; }
    public virtual DbSet<QrCodeType> QrCodeTypes { get; set; }
    public virtual DbSet<QrCodeState> QrCodeStates { get; set; }
    public virtual DbSet<TransportType> TransportTypes { get; set; }
    public virtual DbSet<TransportTypeTranslate> TransportTypeTranslates { get; set; }
    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
    public virtual DbSet<ExpenseTypeTranslate> ExpenseTypeTranslates { get; set; }
    public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    public virtual DbSet<NotificationTemplateTranslate> NotificationTempleteTranslates { get; set; }
    #endregion



    #region INFO    
    public virtual DbSet<TireSize> TireSizes { get; set; }
    public virtual DbSet<LiquidType> LiquidTypes { get; set; }
    public virtual DbSet<LiquidTypeTranslate> LiquidTypeTranslates { get; set; }
    public virtual DbSet<OilModel> OilModels { get; set; }
    public virtual DbSet<OilModelTranslate> OilModelTranslates { get; set; }
    public virtual DbSet<TireModel> TireModels { get; set; }
    public virtual DbSet<TireModelTranslate> TireModelTranslates { get; set; }
    public virtual DbSet<TransportModelLiquid> TransportModelLiquids { get; set; }
    public virtual DbSet<Bank> Banks { get; set; }
    public virtual DbSet<BankTranslate> BankTranslates { get; set; }
    public virtual DbSet<BatteryType> BatteryTypes { get; set; }
    public virtual DbSet<BatteryTypeTranslate> BatteryTypeTranslates { get; set; }
    public virtual DbSet<Citizenship> Citizenships { get; set; }
    public virtual DbSet<CitizenshipTranslate> CitizenshipTranslates { get; set; }
    public virtual DbSet<Contractor> Contractors { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<CountryTranslate> CountryTranslates { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<CurrencyTranslate> CurrencyTranslates { get; set; }
    public virtual DbSet<District> Districts { get; set; }
    public virtual DbSet<DistrictTranslate> DistrictTranslates { get; set; }
    public virtual DbSet<FuelType> FuelTypes { get; set; }
    public virtual DbSet<FuelTypeTranslate> FuelTypeTranslates { get; set; }
    public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }
    public virtual DbSet<InsuranceTypeTranslate> InsuranceTypeTranslates { get; set; }
    public virtual DbSet<Nationality> Nationalities { get; set; }
    public virtual DbSet<NationalityTranslate> NationalityTranslates { get; set; }
    public virtual DbSet<OilType> OilTypes { get; set; }
    public virtual DbSet<OilTypeTranslate> OilTypeTranslates { get; set; }
    public virtual DbSet<Organization> Organizations { get; set; }
    public virtual DbSet<OrganizationTranslate> OrganizationTranslates { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    public virtual DbSet<RegionTranslate> RegionTranslates { get; set; }
    public virtual DbSet<TransportBrand> TransportBrands { get; set; }
    public virtual DbSet<TransportBrandTranslate> TransportBrandTranslates { get; set; }
    public virtual DbSet<TransportColor> TransportColors { get; set; }
    public virtual DbSet<TransportColorTranslate> TransportColorTranslates { get; set; }
    public virtual DbSet<TransportModel> TransportModels { get; set; }
    public virtual DbSet<TransportModelTranslate> TransportModelTranslates { get; set; }
    public virtual DbSet<TransportUseType> TransportUseTypes { get; set; }
    public virtual DbSet<TransportUseTypeTranslate> TransportUseTypeTranslates { get; set; }
    public virtual DbSet<MobileAppVersion> MobileAppVersions { get; set; }
    #endregion


    #region HL
    public virtual DbSet<Branch> Branches { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<DepartmentTranslate> DepartmentTranslates { get; set; }
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<DriverDocument> DriverDocuments { get; set; }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Transport> Transports { get; set; }
    public virtual DbSet<TransportFile> TransportFiles { get; set; }
    public virtual DbSet<TransportModelFile> TransportModelFiles { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
    public virtual DbSet<PositionTranslate> PositionTranslates { get; set; }
    public virtual DbSet<NumberTemplate> NumberTemplates { get; set; }
    public virtual DbSet<FuelCard> FuelCards { get; set; }
    public virtual DbSet<PresentTrackingInfo> PresentTrackingInfos { get; set; }
    public virtual DbSet<TrackingInfo> TrackingInfos { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }
    public virtual DbSet<PresentNotification> PresentNotifications { get; set; }

    #endregion


    #region SYS
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<PermissionTranslate> PermissionTranslates { get; set; }
    public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }
    public virtual DbSet<PermissionGroupTranslate> PermissionGroupTranslates { get; set; }
    public virtual DbSet<PermissionSubGroup> PermissionSubGroups { get; set; }
    public virtual DbSet<PermissionSubGroupTranslate> PermissionSubGroupTranslates { get; set; }
    public virtual DbSet<QrCodeRegistry> QrCodeRegistries { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RoleTranslate> RoleTranslates { get; set; }
    public virtual DbSet<RolePermission> RolePermissions { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserLog> UserLogs { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<UserToken> UserTokens { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    public virtual DbSet<Number> Numbers { get; set; }
    #endregion



    #region DOC
    public virtual DbSet<TransportSettingFile> TransportSettingFiles { get; set; }
    public virtual DbSet<MachineReadableCodeSetting> MachineReadableCodeSettings { get; set; }
    public virtual DbSet<MachineReadableCodeSettingHistory> MachineReadableCodeSettingHistories { get; set; }
    public virtual DbSet<MachineReadableCodeSettingTable> MachineReadableCodeSettingTables { get; set; }
    public virtual DbSet<TransportSetting> TransportSettings { get; set; }
    public virtual DbSet<TransportSettingBattery> TransportSettingBatteries { get; set; }
    public virtual DbSet<TransportSettingFuel> TransportSettingFuels { get; set; }
    public virtual DbSet<TransportSettingInspection> TransportSettingInspections { get; set; }
    public virtual DbSet<TransportSettingInsurance> TransportSettingInsurances { get; set; }
    public virtual DbSet<TransportSettingLiquid> TransportSettingLiquids { get; set; }
    public virtual DbSet<TransportSettingOil> TransportSettingOils { get; set; }
    public virtual DbSet<TransportSettingTire> TransportSettingTires { get; set; }
    public virtual DbSet<TransportSettingHistory> TransportSettingHistorys { get; set; }
    public virtual DbSet<Expense> Expenses { get; set; }
    public virtual DbSet<ExpenseBattery> ExpenseBatteries { get; set; }
    public virtual DbSet<ExpenseInspection> ExpenseInspections { get; set; }
    public virtual DbSet<ExpenseInsurance> ExpenseInsurances { get; set; }
    public virtual DbSet<ExpenseLiquid> ExpenseLiquids { get; set; }
    public virtual DbSet<ExpenseOil> ExpenseOils { get; set; }
    public virtual DbSet<ExpenseTire> ExpenseTires { get; set; }
    public virtual DbSet<ExpenseBatteryFile> ExpenseBatteryFiles { get; set; }
    public virtual DbSet<ExpenseInspectionFile> ExpenseInspectionFiles { get; set; }
    public virtual DbSet<ExpenseInsuranceFile> ExpenseInsuranceFiles { get; set; }
    public virtual DbSet<ExpenseLiquidFile> ExpenseLiquidFiles { get; set; }
    public virtual DbSet<ExpenseOilFile> ExpenseOilFiles { get; set; }
    public virtual DbSet<ExpenseTireFile> ExpenseTireFiles { get; set; }
    public virtual DbSet<ExpenseFile> ExpenseFiles { get; set; }
    public virtual DbSet<ExpenseHistory> ExpenseHistories { get; set; }
    public virtual DbSet<Refuel> Refuels { get; set; }
    public virtual DbSet<RefuelFile> RefuelFiles { get; set; }
    public virtual DbSet<RefuelHistory> RefuelHistories { get; set; }
    public virtual DbSet<NotificationTemplateSetting> NotificationTemplateSettings { get; set; }
    public virtual DbSet<NotificationTemplateSettingUser> NotificationTemplateSettingUsers { get; set; }
    public virtual DbSet<NotificationTemplateSettingRestrictedUser> NotificationTemplateSettingRestrictedUsers { get; set; }
    public virtual DbSet<NotificationTemplateSettingRole> NotificationTemplateSettingRoles { get; set; }

    #endregion


    #region Acc
    public virtual DbSet<DriverPenalty> DriverPenalties { get; set; }
    #endregion

    #region Functions
    [DbFunction("get_total_expense", Schema = "public")]
    public IQueryable<TotalExpenseReportListDto> GetTotalExpenseReport(
        int? branchId,
        int? transportId,
        int? driverId,
        DateTime? fromDate,
        DateTime? toDate)
    => FromExpression(() =>
        GetTotalExpenseReport(branchId, transportId, driverId, fromDate, toDate));

    [DbFunction("get_expense", Schema = "public")]
    public IQueryable<ExpenseReportList> GetExpenseReport(
        int? branchId,
        int? transportId,
        int? driverId,
        DateTime? fromDate,
        DateTime? toDate)
    => FromExpression(() =>
        GetExpenseReport(branchId, transportId, driverId, fromDate, toDate));

    [DbFunction("get_total_expense_over_limit", Schema = "public")]
    public IQueryable<TotalExpenseLimitReportListDto> GetTotalExpenseLimitReport(
        int? branchId,
        int? transportId,
        int? driverId,
        DateTime? fromDate,
        DateTime? toDate)
    => FromExpression(() =>
        GetTotalExpenseLimitReport(branchId, transportId, driverId, fromDate, toDate));

    [DbFunction("get_expense_over_limit", Schema = "public")]
    public IQueryable<ExpenseLimitReportList> GetExpenseLimitReport(
        int? branchId,
        int? transportId,
        int? driverId,
        DateTime? fromDate,
        DateTime? toDate)
    => FromExpression(() =>
        GetExpenseLimitReport(branchId, transportId, driverId, fromDate, toDate));
    #endregion
}