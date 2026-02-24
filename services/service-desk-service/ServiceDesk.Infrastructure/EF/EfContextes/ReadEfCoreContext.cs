using System.Text.Json.Nodes;
using Bms.WEBASE.EF;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.Report.SpareTurnover;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Entities.Sys;

namespace ServiceDesk.Application;

public class ReadEfCoreContext :
    AuditableDbContext,
    IReadEfCoreContext
{
    public ReadEfCoreContext(DbContextOptions<ReadEfCoreContext> options) :
        base(options)
    { }

    #region ENUM
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<State> States { get; set; }
    public virtual DbSet<StateTranslate> StateTranslates { get; set; }
    public virtual DbSet<DocumentType> DocumentTypes { get; set; }
    public virtual DbSet<DocumentTypeTranslate> DocumentTypeTranslates { get; set; }
    public virtual DbSet<Gender> Genders { get; set; }
    public virtual DbSet<GenderTranslate> GenderTranslates { get; set; }
    public virtual DbSet<Status> Statuses { get; set; }
    public virtual DbSet<StatusTranslate> StatusTranslates { get; set; }
    public virtual DbSet<PlasticCardType> PlasticCardTypes { get; set; }
    public virtual DbSet<PlasticCardTypeTranslate> PlasticCardTypeTranslates { get; set; }
    public virtual DbSet<CodeFormType> CodeFormTypes { get; set; }
    public virtual DbSet<QrCodeType> QrCodeTypes { get; set; }
    public virtual DbSet<QrCodeState> QrCodeStates { get; set; }
    public virtual DbSet<BaseDeviceType> BaseDeviceTypes { get; set; }
    public virtual DbSet<BaseDeviceTypeTranslate> BaseDeviceTypeTranslates { get; set; }
    public virtual DbSet<ExecutorType> ExecutorTypes { get; set; }
    public virtual DbSet<ExecutorTypeTranslate> ExecutorTypeTranslates { get; set; }
    public virtual DbSet<ApplicationPurpose> ApplicationPurposes { get; set; }
    public virtual DbSet<ApplicationPurposeTranslate> ApplicationPurposeTranslates { get; set; }
    public virtual DbSet<MovementType> MovementTypes { get; set; }
    public virtual DbSet<MovementTypeTranslate> MovementTypeTranslates { get; set; }
    public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    public virtual DbSet<NotificationTemplateTranslate> NotificationTempleteTranslates { get; set; }

    #endregion

    #region INFO    
    public virtual DbSet<Bank> Banks { get; set; }
    public virtual DbSet<BankTranslate> BankTranslates { get; set; }
    public virtual DbSet<Citizenship> Citizenships { get; set; }
    public virtual DbSet<CitizenshipTranslate> CitizenshipTranslates { get; set; }
    public virtual DbSet<Contractor> Contractors { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<CountryTranslate> CountryTranslates { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<CurrencyTranslate> CurrencyTranslates { get; set; }
    public virtual DbSet<District> Districts { get; set; }
    public virtual DbSet<DistrictTranslate> DistrictTranslates { get; set; }
    public virtual DbSet<Nationality> Nationalities { get; set; }
    public virtual DbSet<NationalityTranslate> NationalityTranslates { get; set; }
    public virtual DbSet<Organization> Organizations { get; set; }
    public virtual DbSet<OrganizationTranslate> OrganizationTranslates { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
	public virtual DbSet<RegionTranslate> RegionTranslates { get; set; }
	public virtual DbSet<DeviceType> DeviceTypes { get; set; }
	public virtual DbSet<DeviceTypeTranslate> DeviceTypeTranslates { get; set; }
	public virtual DbSet<DevicePart> DeviceParts { get; set; }
	public virtual DbSet<DevicePartTranslate> DevicePartTranslates { get; set; }
	public virtual DbSet<DeviceModel> DeviceModels { get; set; }
	public virtual DbSet<DeviceModelTranslate> DeviceModelTranslates { get; set; }
	public virtual DbSet<DeviceSpareType> DeviceSpareTypes { get; set; }
	public virtual DbSet<DeviceSpareTypeTranslate> DeviceSpareTypeTranslates { get; set; }
	public virtual DbSet<ServiceType> ServiceTypes { get; set; }
	public virtual DbSet<ServiceTypeTranslate> ServiceTypeTranslates { get; set; }
    public virtual DbSet<MobileAppVersion> MobileAppVersions { get; set; }
    public virtual DbSet<SpareTurnoverReportJson> SpareTurnoverReportBriefListDtos { get; set; }

    #endregion


    #region HL
    public virtual DbSet<Branch> Branches { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<DepartmentTranslate> DepartmentTranslates { get; set; }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
    public virtual DbSet<PositionTranslate> PositionTranslates { get; set; }
    public virtual DbSet<NumberTemplate> NumberTemplates { get; set; }
    public virtual DbSet<Device> Devices { get; set; }
    public virtual DbSet<DeviceFile> DeviceFiles { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }

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
    public virtual DbSet<Table> Tables { get; set; }
    #endregion

    #region DOC
    public virtual DbSet<MachineReadableCodeSetting> MachineReadableCodeSettings { get; set; }
    public virtual DbSet<MachineReadableCodeSettingHistory> MachineReadableCodeSettingHistories { get; set; }
    public virtual DbSet<MachineReadableCodeSettingTable> MachineReadableCodeSettingTables { get; set; }
    public virtual DbSet<ServiceApplication> ServiceApplications { get; set; }
    public virtual DbSet<ServiceApplicationExecutorFile> ServiceApplicationExecutorFiles { get; set; }
    public virtual DbSet<ServiceApplicationFile> ServiceApplicationFiles { get; set; }
    public virtual DbSet<ServiceApplicationHistory> ServiceApplicationHistories { get; set; }
    public virtual DbSet<ServiceApplicationPart> ServiceApplicationParts { get; set; }
    public virtual DbSet<ServiceApplicationSpare> ServiceApplicationSpares { get; set; }
    public virtual DbSet<SpareMovement> SpareMovements { get; set; }
    public virtual DbSet<SpareMovementHistory> SpareMovementHistories { get; set; }
    public virtual DbSet<SpareMovementTable> SpareMovementTables { get; set; }
    public virtual DbSet<NotificationTemplateSetting> NotificationTemplateSettings { get; set; }
    public virtual DbSet<NotificationTemplateSettingUser> NotificationTemplateSettingUsers { get; set; }
    public virtual DbSet<NotificationTemplateSettingRestrictedUser> NotificationTemplateSettingRestrictedUsers { get; set; }
    public virtual DbSet<NotificationTemplateSettingRole> NotificationTemplateSettingRoles { get; set; }

    #endregion

    #region ACC
    public virtual DbSet<PresentSpareTurnover> PresentSpareTurnovers { get; set; }
    public virtual DbSet<SpareTurnover> SpareTurnovers { get; set; }
    #endregion

    #region Functions
    public DbSet<SpareTurnoverReportJson> Results { get; set; } = null!;

    public IQueryable<SpareTurnoverReportJson> GetSpareTurnoverReport(
    int branchId,
    int deviceTypeId,
    int pageSize,
    int pageIndex,
    string search,
    string sortBy,
    string orderBy)
    => FromExpression(() =>
        GetSpareTurnoverReport(branchId, deviceTypeId, pageSize, pageIndex, search, sortBy, orderBy));

    #endregion

    private void AutopayOnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SpareTurnoverReportJson>()
                  .HasNoKey()
                  .ToView(null);
    }
}