using ServiceDesk.Domain;
using ServiceDesk.Domain.Entities.Sys;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.Report.SpareTurnover;

namespace ServiceDesk.Application;

public interface IBaseEfCoreDbContext // For saving all DbSets at once because if we do not do this we have to write same code both Read and write contexts
{
    #region ENUM
    DbSet<Language> Languages { get; set; }
    DbSet<State> States { get; set; }
    DbSet<StateTranslate> StateTranslates { get; set; }
    DbSet<DocumentType> DocumentTypes { get; set; }
    DbSet<DocumentTypeTranslate> DocumentTypeTranslates { get; set; }
    DbSet<Gender> Genders { get; set; }
    DbSet<GenderTranslate> GenderTranslates { get; set; }
    DbSet<Status> Statuses { get; set; }
    DbSet<StatusTranslate> StatusTranslates { get; set; }
    DbSet<PlasticCardType> PlasticCardTypes { get; set; }
    DbSet<PlasticCardTypeTranslate> PlasticCardTypeTranslates { get; set; }
    DbSet<CodeFormType> CodeFormTypes { get; set; }
    DbSet<QrCodeType> QrCodeTypes { get; set; }
    DbSet<QrCodeState> QrCodeStates { get; set; }
	DbSet<BaseDeviceType> BaseDeviceTypes { get; set; }
	DbSet<BaseDeviceTypeTranslate> BaseDeviceTypeTranslates { get; set; }
	DbSet<ApplicationPurpose> ApplicationPurposes { get; set; }
	DbSet<ApplicationPurposeTranslate> ApplicationPurposeTranslates { get; set; }
	DbSet<ExecutorType> ExecutorTypes { get; set; }
	DbSet<ExecutorTypeTranslate> ExecutorTypeTranslates { get; set; }
	DbSet<MovementType> MovementTypes { get; set; }
	DbSet<MovementTypeTranslate> MovementTypeTranslates { get; set; }
    DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    DbSet<NotificationTemplateTranslate> NotificationTempleteTranslates { get; set; }

    #endregion


    #region INFO    
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
    DbSet<DeviceType> DeviceTypes { get; set; }
    DbSet<DeviceTypeTranslate> DeviceTypeTranslates { get; set; }
    DbSet<DevicePart> DeviceParts { get; set; }
    DbSet<DevicePartTranslate> DevicePartTranslates { get; set; }
    DbSet<DeviceModel> DeviceModels { get; set; }
    DbSet<DeviceModelTranslate> DeviceModelTranslates { get; set; }
    DbSet<DeviceSpareType> DeviceSpareTypes { get; set; }
    DbSet<DeviceSpareTypeTranslate> DeviceSpareTypeTranslates { get; set; }
    DbSet<ServiceType> ServiceTypes { get; set; }
    DbSet<ServiceTypeTranslate> ServiceTypeTranslates { get; set; }
    DbSet<MobileAppVersion> MobileAppVersions { get; set; }

    #endregion

    #region HL
    DbSet<Branch> Branches { get; set; }
    DbSet<Department> Departments { get; set; }
    DbSet<DepartmentTranslate> DepartmentTranslates { get; set; }
    DbSet<Person> People { get; set; }
    DbSet<Position> Positions { get; set; }
    DbSet<PositionTranslate> PositionTranslates { get; set; }
    DbSet<NumberTemplate> NumberTemplates { get; set; }
    DbSet<Device> Devices { get; set; }
    DbSet<DeviceFile> DeviceFiles { get; set; }
    DbSet<Notification> Notifications { get; set; }

    #endregion

    #region SYS
    DbSet<Permission> Permissions { get; set; }
    DbSet<PermissionTranslate> PermissionTranslates { get; set; }
    DbSet<PermissionGroup> PermissionGroups { get; set; }
    DbSet<PermissionGroupTranslate> PermissionGroupTranslates { get; set; }
    DbSet<PermissionSubGroup> PermissionSubGroups { get; set; }
    DbSet<PermissionSubGroupTranslate> PermissionSubGroupTranslates { get; set; }
    DbSet<QrCodeRegistry> QrCodeRegistries { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<RoleTranslate> RoleTranslates { get; set; }
    DbSet<RolePermission> RolePermissions { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserLog> UserLogs { get; set; }
    DbSet<UserRole> UserRoles { get; set; }
    DbSet<UserToken> UserTokens { get; set; }
    DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    DbSet<Number> Numbers { get; set; }
	DbSet<Table> Tables { get; set; }
	#endregion

	#region DOC
	DbSet<MachineReadableCodeSetting> MachineReadableCodeSettings { get; set; }
    DbSet<MachineReadableCodeSettingHistory> MachineReadableCodeSettingHistories { get; set; }
    DbSet<MachineReadableCodeSettingTable> MachineReadableCodeSettingTables { get; set; }
    DbSet<ServiceApplication> ServiceApplications { get; set; }
    DbSet<ServiceApplicationExecutorFile> ServiceApplicationExecutorFiles { get; set; }
    DbSet<ServiceApplicationFile> ServiceApplicationFiles { get; set; }
    DbSet<ServiceApplicationHistory> ServiceApplicationHistories { get; set; }
    DbSet<ServiceApplicationPart> ServiceApplicationParts { get; set; }
    DbSet<ServiceApplicationSpare> ServiceApplicationSpares { get; set; }
	DbSet<SpareMovement> SpareMovements { get; set; }
	DbSet<SpareMovementHistory> SpareMovementHistories { get; set; }
	DbSet<SpareMovementTable> SpareMovementTables { get; set; }
    DbSet<NotificationTemplateSetting> NotificationTemplateSettings { get; set; }
    DbSet<NotificationTemplateSettingUser> NotificationTemplateSettingUsers { get; set; }
    DbSet<NotificationTemplateSettingRestrictedUser> NotificationTemplateSettingRestrictedUsers { get; set; }
    DbSet<NotificationTemplateSettingRole> NotificationTemplateSettingRoles { get; set; }

    #endregion

    #region ACC
    DbSet<PresentSpareTurnover> PresentSpareTurnovers { get; set; }
	DbSet<SpareTurnover> SpareTurnovers { get; set; }
    #endregion

    

}
