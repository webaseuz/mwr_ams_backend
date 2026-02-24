using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

public partial class ServiceDeskDbContext : DbContext
{
    public ServiceDeskDbContext()
    {
    }

    public ServiceDeskDbContext(DbContextOptions<ServiceDeskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccPresentSpareTurnover> AccPresentSpareTurnovers { get; set; }

    public virtual DbSet<AccSpareTurnover> AccSpareTurnovers { get; set; }

    public virtual DbSet<DocMachineReadableCodeSetting> DocMachineReadableCodeSettings { get; set; }

    public virtual DbSet<DocMachineReadableCodeSettingHistory> DocMachineReadableCodeSettingHistories { get; set; }

    public virtual DbSet<DocMachineReadableCodeSettingTable> DocMachineReadableCodeSettingTables { get; set; }

    public virtual DbSet<DocServiceApplication> DocServiceApplications { get; set; }

    public virtual DbSet<DocServiceApplicationExecutorFile> DocServiceApplicationExecutorFiles { get; set; }

    public virtual DbSet<DocServiceApplicationFile> DocServiceApplicationFiles { get; set; }

    public virtual DbSet<DocServiceApplicationHistory> DocServiceApplicationHistories { get; set; }

    public virtual DbSet<DocServiceApplicationPart> DocServiceApplicationParts { get; set; }

    public virtual DbSet<DocServiceApplicationSpare> DocServiceApplicationSpares { get; set; }

    public virtual DbSet<DocSpareMovement> DocSpareMovements { get; set; }

    public virtual DbSet<DocSpareMovementHistory> DocSpareMovementHistories { get; set; }

    public virtual DbSet<DocSpareMovementTable> DocSpareMovementTables { get; set; }

    public virtual DbSet<EnumApplicationPurpose> EnumApplicationPurposes { get; set; }

    public virtual DbSet<EnumApplicationPurposeTranslate> EnumApplicationPurposeTranslates { get; set; }

    public virtual DbSet<EnumBaseDeviceType> EnumBaseDeviceTypes { get; set; }

    public virtual DbSet<EnumBaseDeviceTypeTranslate> EnumBaseDeviceTypeTranslates { get; set; }

    public virtual DbSet<EnumCodeFormType> EnumCodeFormTypes { get; set; }

    public virtual DbSet<EnumDocumentType> EnumDocumentTypes { get; set; }

    public virtual DbSet<EnumDocumentTypeTranslate> EnumDocumentTypeTranslates { get; set; }

    public virtual DbSet<EnumExecutorType> EnumExecutorTypes { get; set; }

    public virtual DbSet<EnumExecutorTypeTranslate> EnumExecutorTypeTranslates { get; set; }

    public virtual DbSet<EnumGender> EnumGenders { get; set; }

    public virtual DbSet<EnumGenderTranslate> EnumGenderTranslates { get; set; }

    public virtual DbSet<EnumLanguage> EnumLanguages { get; set; }

    public virtual DbSet<EnumMovementType> EnumMovementTypes { get; set; }

    public virtual DbSet<EnumMovementTypeTranslate> EnumMovementTypeTranslates { get; set; }

    public virtual DbSet<EnumPlasticCardType> EnumPlasticCardTypes { get; set; }

    public virtual DbSet<EnumPlasticCardTypeTranslate> EnumPlasticCardTypeTranslates { get; set; }

    public virtual DbSet<EnumQrCodeState> EnumQrCodeStates { get; set; }

    public virtual DbSet<EnumQrCodeType> EnumQrCodeTypes { get; set; }

    public virtual DbSet<EnumState> EnumStates { get; set; }

    public virtual DbSet<EnumStateTranslate> EnumStateTranslates { get; set; }

    public virtual DbSet<EnumStatus> EnumStatuses { get; set; }

    public virtual DbSet<EnumStatusTranslate> EnumStatusTranslates { get; set; }

    public virtual DbSet<HlBranch> HlBranches { get; set; }

    public virtual DbSet<HlDepartment> HlDepartments { get; set; }

    public virtual DbSet<HlDepartmentTranslate> HlDepartmentTranslates { get; set; }

    public virtual DbSet<HlDevice> HlDevices { get; set; }

    public virtual DbSet<HlDeviceFile> HlDeviceFiles { get; set; }

    public virtual DbSet<HlNumberTemplate> HlNumberTemplates { get; set; }

    public virtual DbSet<HlPerson> HlPeople { get; set; }

    public virtual DbSet<HlPosition> HlPositions { get; set; }

    public virtual DbSet<HlPositionTranslate> HlPositionTranslates { get; set; }

    public virtual DbSet<InfoBank> InfoBanks { get; set; }

    public virtual DbSet<InfoBankTranslate> InfoBankTranslates { get; set; }

    public virtual DbSet<InfoCitizenship> InfoCitizenships { get; set; }

    public virtual DbSet<InfoCitizenshipTranslate> InfoCitizenshipTranslates { get; set; }

    public virtual DbSet<InfoContractor> InfoContractors { get; set; }

    public virtual DbSet<InfoCountry> InfoCountries { get; set; }

    public virtual DbSet<InfoCountryTranslate> InfoCountryTranslates { get; set; }

    public virtual DbSet<InfoCurrency> InfoCurrencies { get; set; }

    public virtual DbSet<InfoCurrencyTranslate> InfoCurrencyTranslates { get; set; }

    public virtual DbSet<InfoDeviceModel> InfoDeviceModels { get; set; }

    public virtual DbSet<InfoDeviceModelTranslate> InfoDeviceModelTranslates { get; set; }

    public virtual DbSet<InfoDevicePart> InfoDeviceParts { get; set; }

    public virtual DbSet<InfoDevicePartTranslate> InfoDevicePartTranslates { get; set; }

    public virtual DbSet<InfoDeviceSpareType> InfoDeviceSpareTypes { get; set; }

    public virtual DbSet<InfoDeviceSpareTypeTranslate> InfoDeviceSpareTypeTranslates { get; set; }

    public virtual DbSet<InfoDeviceType> InfoDeviceTypes { get; set; }

    public virtual DbSet<InfoDeviceTypeTranslate> InfoDeviceTypeTranslates { get; set; }

    public virtual DbSet<InfoDistrict> InfoDistricts { get; set; }

    public virtual DbSet<InfoDistrictTranslate> InfoDistrictTranslates { get; set; }

    public virtual DbSet<InfoNationality> InfoNationalities { get; set; }

    public virtual DbSet<InfoNationalityTranslate> InfoNationalityTranslates { get; set; }

    public virtual DbSet<InfoOrganization> InfoOrganizations { get; set; }

    public virtual DbSet<InfoOrganizationTranslate> InfoOrganizationTranslates { get; set; }

    public virtual DbSet<InfoRegion> InfoRegions { get; set; }

    public virtual DbSet<InfoRegionTranslate> InfoRegionTranslates { get; set; }

    public virtual DbSet<InfoServiceType> InfoServiceTypes { get; set; }

    public virtual DbSet<InfoServiceTypeTranslate> InfoServiceTypeTranslates { get; set; }

    public virtual DbSet<SysNumber> SysNumbers { get; set; }

    public virtual DbSet<SysPermission> SysPermissions { get; set; }

    public virtual DbSet<SysPermissionGroup> SysPermissionGroups { get; set; }

    public virtual DbSet<SysPermissionGroupTranslate> SysPermissionGroupTranslates { get; set; }

    public virtual DbSet<SysPermissionSubGroup> SysPermissionSubGroups { get; set; }

    public virtual DbSet<SysPermissionSubGroupTranslate> SysPermissionSubGroupTranslates { get; set; }

    public virtual DbSet<SysPermissionTranslate> SysPermissionTranslates { get; set; }

    public virtual DbSet<SysQrCodeRegistry> SysQrCodeRegistries { get; set; }

    public virtual DbSet<SysRole> SysRoles { get; set; }

    public virtual DbSet<SysRolePermission> SysRolePermissions { get; set; }

    public virtual DbSet<SysRoleTranslate> SysRoleTranslates { get; set; }

    public virtual DbSet<SysTable> SysTables { get; set; }

    public virtual DbSet<SysUser> SysUsers { get; set; }

    public virtual DbSet<SysUserLog> SysUserLogs { get; set; }

    public virtual DbSet<SysUserRefreshToken> SysUserRefreshTokens { get; set; }

    public virtual DbSet<SysUserRole> SysUserRoles { get; set; }

    public virtual DbSet<SysUserToken> SysUserTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=service_desk_db;Pooling=true;Maximum Pool Size=10000;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccPresentSpareTurnover>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("acc_present_spare_turnover_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.AccPresentSpareTurnovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.DeviceSpareType).WithMany(p => p.AccPresentSpareTurnovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_spare_type_id");

            entity.HasOne(d => d.LastSpareTurnover).WithMany(p => p.AccPresentSpareTurnovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_last_spare_turnover_id");

            entity.HasOne(d => d.User).WithMany(p => p.AccPresentSpareTurnovers).HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<AccSpareTurnover>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("acc_spare_turnover_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.AccSpareTurnovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.DeviceSpareType).WithMany(p => p.AccSpareTurnovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_spare_type_id");

            entity.HasOne(d => d.Table).WithMany(p => p.AccSpareTurnovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_table_id");

            entity.HasOne(d => d.User).WithMany(p => p.AccSpareTurnovers).HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<DocMachineReadableCodeSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_machine_readable_code_setting_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CodeFormType).WithMany(p => p.DocMachineReadableCodeSettings).HasConstraintName("fk_code_form_type_id");

            entity.HasOne(d => d.CodeType).WithMany(p => p.DocMachineReadableCodeSettings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_qodetypeid");

            entity.HasOne(d => d.Status).WithMany(p => p.DocMachineReadableCodeSettings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_statusid");
        });

        modelBuilder.Entity<DocMachineReadableCodeSettingHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_machine_readable_code_setting_history_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocMachineReadableCodeSettingHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocMachineReadableCodeSettingHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");
        });

        modelBuilder.Entity<DocMachineReadableCodeSettingTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_machine_readable_code_setting_table_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CodeFormType).WithMany(p => p.DocMachineReadableCodeSettingTables).HasConstraintName("fk_code_form_type_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.DocMachineReadableCodeSettingTables)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocServiceApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_service_application_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.DocServiceApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.Device).WithMany(p => p.DocServiceApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_id");

            entity.HasOne(d => d.ExecutorType).WithMany(p => p.DocServiceApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_executor_type_id");

            entity.HasOne(d => d.ResponsiblePerson).WithMany(p => p.DocServiceApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_responsible_person_id");

            entity.HasOne(d => d.ServiceContractor).WithMany(p => p.DocServiceApplications).HasConstraintName("fk_service_contractor_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocServiceApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");
        });

        modelBuilder.Entity<DocServiceApplicationExecutorFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_service_application_executor_file_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocServiceApplicationExecutorFiles).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocServiceApplicationFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_service_application_file_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocServiceApplicationFiles).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocServiceApplicationHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_service_application_history_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocServiceApplicationHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocServiceApplicationHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");
        });

        modelBuilder.Entity<DocServiceApplicationPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_service_application_part_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.ApplicationPurpose).WithMany(p => p.DocServiceApplicationParts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_application_purpose_id");

            entity.HasOne(d => d.DevicePart).WithMany(p => p.DocServiceApplicationParts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_part_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.DocServiceApplicationParts).HasConstraintName("fk_owner_id");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.DocServiceApplicationParts).HasConstraintName("fk_service_type_id");
        });

        modelBuilder.Entity<DocServiceApplicationSpare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_service_application_spare_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.DeviceSpareType).WithMany(p => p.DocServiceApplicationSpares)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_spare_type_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.DocServiceApplicationSpares).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocSpareMovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_spare_movement_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.FromBranch).WithMany(p => p.DocSpareMovementFromBranches).HasConstraintName("fk_from_branch_id");

            entity.HasOne(d => d.FromUser).WithMany(p => p.DocSpareMovementFromUsers).HasConstraintName("fk_from_user_id");

            entity.HasOne(d => d.MovementType).WithMany(p => p.DocSpareMovements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_movement_type_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocSpareMovements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");

            entity.HasOne(d => d.ToBranch).WithMany(p => p.DocSpareMovementToBranches).HasConstraintName("fk_to_branch_id");

            entity.HasOne(d => d.ToUser).WithMany(p => p.DocSpareMovementToUsers).HasConstraintName("fk_to_user_id");
        });

        modelBuilder.Entity<DocSpareMovementHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_spare_movement_history_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocSpareMovementHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocSpareMovementHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");
        });

        modelBuilder.Entity<DocSpareMovementTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_spare_movement_table_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.DeviceSpareType).WithMany(p => p.DocSpareMovementTables)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_spare_type_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.DocSpareMovementTables).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumApplicationPurpose>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_application_purpose_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumApplicationPurposes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumApplicationPurposeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_application_purpose_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumApplicationPurposeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumApplicationPurposeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumBaseDeviceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_base_device_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<EnumBaseDeviceTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_base_device_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumBaseDeviceTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumBaseDeviceTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumCodeFormType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_code_form_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumCodeFormTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumDocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_document_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumDocumentTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumDocumentTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_document_type_translate_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumDocumentTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumDocumentTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumExecutorType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_executor_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumExecutorTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumExecutorTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_executor_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumExecutorTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumExecutorTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumGender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_gender_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<EnumGenderTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_gender_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumGenderTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumGenderTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_language_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<EnumMovementType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_movement_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumMovementTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumMovementTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_movement_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumMovementTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumMovementTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumPlasticCardType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_plastic_card_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumPlasticCardTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumPlasticCardTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_plastic_card_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumPlasticCardTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumPlasticCardTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumQrCodeState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_qr_code_state_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<EnumQrCodeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_qr_code_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumQrCodeTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_state_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<EnumStateTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_state_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumStateTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumStateTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_status_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<EnumStatusTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_status_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumStatusTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumStatusTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<HlBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_branch_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Country).WithMany(p => p.HlBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_country_id");

            entity.HasOne(d => d.District).WithMany(p => p.HlBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_district_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("fk_parent_id");

            entity.HasOne(d => d.Region).WithMany(p => p.HlBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_region_id");
        });

        modelBuilder.Entity<HlDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_department_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.HlDepartments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.State).WithMany(p => p.HlDepartments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<HlDepartmentTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_department_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.HlDepartmentTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.HlDepartmentTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<HlDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_device_pkey");

            entity.HasIndex(e => new { e.StateId, e.SerialNumber }, "uix__hl_dev__stid_sernum")
                .IsUnique()
                .HasFilter("(state_id = 1)");

            entity.HasIndex(e => new { e.StateId, e.UniqueNumber }, "uix__hl_dev__stid_uniqnum")
                .IsUnique()
                .HasFilter("(state_id = 1)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.HlDevices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.DeviceModel).WithMany(p => p.HlDevices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_model_id");

            entity.HasOne(d => d.DeviceType).WithMany(p => p.HlDevices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_type_id");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.HlDeviceManufacturers).HasConstraintName("fk_manufacturer_id");

            entity.HasOne(d => d.ResponsiblePerson).WithMany(p => p.HlDevices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_responsible_person_id");

            entity.HasOne(d => d.ServiceContractor).WithMany(p => p.HlDeviceServiceContractors).HasConstraintName("fk_service_contractor_id");

            entity.HasOne(d => d.State).WithMany(p => p.HlDevices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<HlDeviceFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_device_file_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.HlDeviceFiles).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<HlNumberTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_number_template_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Organization).WithMany(p => p.HlNumberTemplates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organization_id");
        });

        modelBuilder.Entity<HlPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_person_pkey");

            entity.HasIndex(e => e.Inn, "hl_person_unique_index_inn")
                .IsUnique()
                .HasFilter("(inn IS NOT NULL)");

            entity.HasIndex(e => e.Pinfl, "hl_person_unique_index_pinfl")
                .IsUnique()
                .HasFilter("(pinfl IS NOT NULL)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.BirthCountry).WithMany(p => p.HlPeople).HasConstraintName("fk_birth_country_id");

            entity.HasOne(d => d.BirthDistrict).WithMany(p => p.HlPersonBirthDistricts).HasConstraintName("fk_birth_district_id");

            entity.HasOne(d => d.BirthRegion).WithMany(p => p.HlPersonBirthRegions).HasConstraintName("fk_birth_region_id");

            entity.HasOne(d => d.Branch).WithMany(p => p.HlPeople)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.Citizenship).WithMany(p => p.HlPeople).HasConstraintName("fk_citizenship_id");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.HlPeople)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_document_type_id");

            entity.HasOne(d => d.Gender).WithMany(p => p.HlPeople).HasConstraintName("fk_gender_id");

            entity.HasOne(d => d.LivingDistrict).WithMany(p => p.HlPersonLivingDistricts).HasConstraintName("fk_living_district_id");

            entity.HasOne(d => d.LivingRegion).WithMany(p => p.HlPersonLivingRegions).HasConstraintName("fk_living_region_id");

            entity.HasOne(d => d.State).WithMany(p => p.HlPeople)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<HlPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_position_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.HlPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<HlPositionTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_position_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.HlPositionTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.HlPositionTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_bank_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoBanks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoBankTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_bank_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoBankTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoBankTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoCitizenship>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_citizenship_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoCitizenships)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoCitizenshipTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_citizenship_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoCitizenshipTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoCitizenshipTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoContractor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_contractor_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Bank).WithMany(p => p.InfoContractors).HasConstraintName("fk_bank_id");

            entity.HasOne(d => d.Country).WithMany(p => p.InfoContractors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_country_id");

            entity.HasOne(d => d.District).WithMany(p => p.InfoContractors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_district_id");

            entity.HasOne(d => d.Region).WithMany(p => p.InfoContractors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_region_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoContractors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_country_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoCountries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoCountryTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_country_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoCountryTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoCountryTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoCurrency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_currency_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoCurrencies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_currency");
        });

        modelBuilder.Entity<InfoCurrencyTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_currency_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoCurrencyTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoCurrencyTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoDeviceModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_device_model_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.DeviceType).WithMany(p => p.InfoDeviceModels).HasConstraintName("fk_device_type_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoDeviceModels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoDeviceModelTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_device_model_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoDeviceModelTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoDeviceModelTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoDevicePart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_device_part_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.DeviceType).WithMany(p => p.InfoDeviceParts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_type_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoDeviceParts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoDevicePartTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_device_part_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoDevicePartTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoDevicePartTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoDeviceSpareType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_device_spare_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.DeviceModel).WithMany(p => p.InfoDeviceSpareTypes).HasConstraintName("fk_device_model_id");

            entity.HasOne(d => d.DevicePart).WithMany(p => p.InfoDeviceSpareTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_part_id");

            entity.HasOne(d => d.DeviceType).WithMany(p => p.InfoDeviceSpareTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_device_type_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoDeviceSpareTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoDeviceSpareTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_device_spare_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoDeviceSpareTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoDeviceSpareTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoDeviceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_device_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.BaseDeviceType).WithMany(p => p.InfoDeviceTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_base_device_type_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoDeviceTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoDeviceTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_device_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoDeviceTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoDeviceTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoDistrict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_district_pkey");

            entity.HasIndex(e => e.Code, "uix__info_district__code")
                .IsUnique()
                .HasFilter("(code IS NOT NULL)");

            entity.HasIndex(e => e.RoamingCode, "uix__info_district__roaming_code")
                .IsUnique()
                .HasFilter("(roaming_code IS NOT NULL)");

            entity.HasIndex(e => e.Soato, "uix__info_district__soato")
                .IsUnique()
                .HasFilter("(soato IS NOT NULL)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Region).WithMany(p => p.InfoDistricts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_region_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoDistricts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoDistrictTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_district_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoDistrictTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoDistrictTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoNationality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_nationality_pkey");

            entity.HasIndex(e => e.WbCode, "uix__info_citizenship__wb_code")
                .IsUnique()
                .HasFilter("(wb_code IS NOT NULL)");

            entity.HasIndex(e => e.WbCode, "uix__info_nationality__wb_code")
                .IsUnique()
                .HasFilter("(wb_code IS NOT NULL)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoNationalities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoNationalityTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_nationality_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoNationalityTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoNationalityTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoOrganization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_organization_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Bank).WithMany(p => p.InfoOrganizations).HasConstraintName("fk_bank_id");

            entity.HasOne(d => d.Country).WithMany(p => p.InfoOrganizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_country_id");

            entity.HasOne(d => d.District).WithMany(p => p.InfoOrganizations).HasConstraintName("fk_district_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("fk_parent_id");

            entity.HasOne(d => d.Region).WithMany(p => p.InfoOrganizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_region_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoOrganizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoOrganizationTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_organization_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoOrganizationTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoOrganizationTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoRegion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_region_pkey");

            entity.HasIndex(e => e.Code, "uix_info_region__code")
                .IsUnique()
                .HasFilter("(code IS NOT NULL)");

            entity.HasIndex(e => e.RoamingCode, "uix_info_region__roaming_code")
                .IsUnique()
                .HasFilter("(roaming_code IS NOT NULL)");

            entity.HasIndex(e => e.Soato, "uix_info_region__soato")
                .IsUnique()
                .HasFilter("(soato IS NOT NULL)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Country).WithMany(p => p.InfoRegions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_country_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoRegions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoRegionTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_region_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoRegionTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoRegionTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoServiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_service_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.DeviceType).WithMany(p => p.InfoServiceTypes).HasConstraintName("fk_device_type_id");

            entity.HasOne(d => d.State).WithMany(p => p.InfoServiceTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoServiceTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_service_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoServiceTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoServiceTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<SysNumber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_number_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Branch).WithMany(p => p.SysNumbers).HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.Organization).WithMany(p => p.SysNumbers).HasConstraintName("fk_organization_id");
        });

        modelBuilder.Entity<SysPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_permission_pkey");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.SysPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.SubGroup).WithMany(p => p.SysPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sub_group_id");
        });

        modelBuilder.Entity<SysPermissionGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_permission_group_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<SysPermissionGroupTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_permission_group_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.SysPermissionGroupTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.SysPermissionGroupTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<SysPermissionSubGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_permission_sub_group_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Group).WithMany(p => p.SysPermissionSubGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_id");
        });

        modelBuilder.Entity<SysPermissionSubGroupTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_permission_sub_group_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.SysPermissionSubGroupTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.SysPermissionSubGroupTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<SysPermissionTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_permission_translate_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.SysPermissionTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.SysPermissionTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<SysQrCodeRegistry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_qr_code_registry_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Organization).WithMany(p => p.SysQrCodeRegistries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organization_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("fk_parent_id");

            entity.HasOne(d => d.QrCodeState).WithMany(p => p.SysQrCodeRegistries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_qr_code_state_id");

            entity.HasOne(d => d.QrCodeType).WithMany(p => p.SysQrCodeRegistries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_qr_code_type_id");

            entity.HasOne(d => d.SettingsDoc).WithMany(p => p.SysQrCodeRegistries).HasConstraintName("fk_settings_doc_id");
        });

        modelBuilder.Entity<SysRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_role_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.SysRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<SysRolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_role_permission_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SysRolePermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_created_by");

            entity.HasOne(d => d.Permission).WithMany(p => p.SysRolePermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permission_id");

            entity.HasOne(d => d.Role).WithMany(p => p.SysRolePermissions).HasConstraintName("fk_role_id");
        });

        modelBuilder.Entity<SysRoleTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_role_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.SysRoleTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.SysRoleTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<SysTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_table_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<SysUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_user_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.SysUsers).HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.Language).WithMany(p => p.SysUsers).HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Organization).WithMany(p => p.SysUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organization_id");

            entity.HasOne(d => d.Person).WithMany(p => p.SysUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_person_id");

            entity.HasOne(d => d.Position).WithMany(p => p.SysUsers).HasConstraintName("fk_position_id");

            entity.HasOne(d => d.State).WithMany(p => p.SysUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<SysUserLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_user_log_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<SysUserRefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_user_refresh_token_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.User).WithMany(p => p.SysUserRefreshTokens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<SysUserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_user_role_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Role).WithMany(p => p.SysUserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_id");

            entity.HasOne(d => d.State).WithMany(p => p.SysUserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.User).WithMany(p => p.SysUserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<SysUserToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_user_token_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.User).WithMany(p => p.SysUserTokens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
