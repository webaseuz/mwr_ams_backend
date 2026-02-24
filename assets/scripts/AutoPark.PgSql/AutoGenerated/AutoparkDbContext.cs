using Microsoft.EntityFrameworkCore;

namespace AutoPark.Domain;

public partial class AutoparkDbContext : DbContext
{
    public AutoparkDbContext()
    {
    }

    public AutoparkDbContext(DbContextOptions<AutoparkDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocExpense> DocExpenses { get; set; }

    public virtual DbSet<DocExpenseFile> DocExpenseFiles { get; set; }

    public virtual DbSet<DocExpenseHistory> DocExpenseHistories { get; set; }

    public virtual DbSet<DocMachineReadableCodeSetting> DocMachineReadableCodeSettings { get; set; }

    public virtual DbSet<DocMachineReadableCodeSettingHistory> DocMachineReadableCodeSettingHistories { get; set; }

    public virtual DbSet<DocMachineReadableCodeSettingTable> DocMachineReadableCodeSettingTables { get; set; }

    public virtual DbSet<DocRefuel> DocRefuels { get; set; }

    public virtual DbSet<DocRefuelFile> DocRefuelFiles { get; set; }

    public virtual DbSet<DocRefuelHistory> DocRefuelHistories { get; set; }

    public virtual DbSet<DocTransportSetting> DocTransportSettings { get; set; }

    public virtual DbSet<DocTransportSettingBattery> DocTransportSettingBatteries { get; set; }

    public virtual DbSet<DocTransportSettingFile> DocTransportSettingFiles { get; set; }

    public virtual DbSet<DocTransportSettingFuel> DocTransportSettingFuels { get; set; }

    public virtual DbSet<DocTransportSettingInspection> DocTransportSettingInspections { get; set; }

    public virtual DbSet<DocTransportSettingInsurance> DocTransportSettingInsurances { get; set; }

    public virtual DbSet<DocTransportSettingLiquid> DocTransportSettingLiquids { get; set; }

    public virtual DbSet<DocTransportSettingOil> DocTransportSettingOils { get; set; }

    public virtual DbSet<DocTransportSettingTire> DocTransportSettingTires { get; set; }

    public virtual DbSet<EnumCodeFormType> EnumCodeFormTypes { get; set; }

    public virtual DbSet<EnumDocumentType> EnumDocumentTypes { get; set; }

    public virtual DbSet<EnumDocumentTypeTranslate> EnumDocumentTypeTranslates { get; set; }

    public virtual DbSet<EnumExpenseType> EnumExpenseTypes { get; set; }

    public virtual DbSet<EnumExpenseTypeTranslate> EnumExpenseTypeTranslates { get; set; }

    public virtual DbSet<EnumGender> EnumGenders { get; set; }

    public virtual DbSet<EnumGenderTranslate> EnumGenderTranslates { get; set; }

    public virtual DbSet<EnumLanguage> EnumLanguages { get; set; }

    public virtual DbSet<EnumPlasticCardType> EnumPlasticCardTypes { get; set; }

    public virtual DbSet<EnumPlasticCardTypeTranslate> EnumPlasticCardTypeTranslates { get; set; }

    public virtual DbSet<EnumQrCodeState> EnumQrCodeStates { get; set; }

    public virtual DbSet<EnumQrCodeType> EnumQrCodeTypes { get; set; }

    public virtual DbSet<EnumState> EnumStates { get; set; }

    public virtual DbSet<EnumStateTranslate> EnumStateTranslates { get; set; }

    public virtual DbSet<EnumStatus> EnumStatuses { get; set; }

    public virtual DbSet<EnumStatusTranslate> EnumStatusTranslates { get; set; }

    public virtual DbSet<EnumTransmissionBoxType> EnumTransmissionBoxTypes { get; set; }

    public virtual DbSet<EnumTransmissionBoxTypeTranslate> EnumTransmissionBoxTypeTranslates { get; set; }

    public virtual DbSet<EnumTransportType> EnumTransportTypes { get; set; }

    public virtual DbSet<EnumTransportTypeTranslate> EnumTransportTypeTranslates { get; set; }

    public virtual DbSet<HlBranch> HlBranches { get; set; }

    public virtual DbSet<HlDepartment> HlDepartments { get; set; }

    public virtual DbSet<HlDepartmentTranslate> HlDepartmentTranslates { get; set; }

    public virtual DbSet<HlDriver> HlDrivers { get; set; }

    public virtual DbSet<HlDriverDocument> HlDriverDocuments { get; set; }

    public virtual DbSet<HlFuelCard> HlFuelCards { get; set; }

    public virtual DbSet<HlNumberTemplate> HlNumberTemplates { get; set; }

    public virtual DbSet<HlPerson> HlPeople { get; set; }

    public virtual DbSet<HlPosition> HlPositions { get; set; }

    public virtual DbSet<HlPositionTranslate> HlPositionTranslates { get; set; }

    public virtual DbSet<HlTransport> HlTransports { get; set; }

    public virtual DbSet<InfoBank> InfoBanks { get; set; }

    public virtual DbSet<InfoBankTranslate> InfoBankTranslates { get; set; }

    public virtual DbSet<InfoBatteryType> InfoBatteryTypes { get; set; }

    public virtual DbSet<InfoBatteryTypeTranslate> InfoBatteryTypeTranslates { get; set; }

    public virtual DbSet<InfoCitizenship> InfoCitizenships { get; set; }

    public virtual DbSet<InfoCitizenshipTranslate> InfoCitizenshipTranslates { get; set; }

    public virtual DbSet<InfoContractor> InfoContractors { get; set; }

    public virtual DbSet<InfoCountry> InfoCountries { get; set; }

    public virtual DbSet<InfoCountryTranslate> InfoCountryTranslates { get; set; }

    public virtual DbSet<InfoCurrency> InfoCurrencies { get; set; }

    public virtual DbSet<InfoCurrencyTranslate> InfoCurrencyTranslates { get; set; }

    public virtual DbSet<InfoDistrict> InfoDistricts { get; set; }

    public virtual DbSet<InfoDistrictTranslate> InfoDistrictTranslates { get; set; }

    public virtual DbSet<InfoFuelType> InfoFuelTypes { get; set; }

    public virtual DbSet<InfoFuelTypeTranslate> InfoFuelTypeTranslates { get; set; }

    public virtual DbSet<InfoInsuranceType> InfoInsuranceTypes { get; set; }

    public virtual DbSet<InfoInsuranceTypeTranslate> InfoInsuranceTypeTranslates { get; set; }

    public virtual DbSet<InfoLiquidType> InfoLiquidTypes { get; set; }

    public virtual DbSet<InfoLiquidTypeTranslate> InfoLiquidTypeTranslates { get; set; }

    public virtual DbSet<InfoNationality> InfoNationalities { get; set; }

    public virtual DbSet<InfoNationalityTranslate> InfoNationalityTranslates { get; set; }

    public virtual DbSet<InfoOilModel> InfoOilModels { get; set; }

    public virtual DbSet<InfoOilModelTranslate> InfoOilModelTranslates { get; set; }

    public virtual DbSet<InfoOilType> InfoOilTypes { get; set; }

    public virtual DbSet<InfoOilTypeTranslate> InfoOilTypeTranslates { get; set; }

    public virtual DbSet<InfoOrganization> InfoOrganizations { get; set; }

    public virtual DbSet<InfoOrganizationTranslate> InfoOrganizationTranslates { get; set; }

    public virtual DbSet<InfoRegion> InfoRegions { get; set; }

    public virtual DbSet<InfoRegionTranslate> InfoRegionTranslates { get; set; }

    public virtual DbSet<InfoTireSize> InfoTireSizes { get; set; }

    public virtual DbSet<InfoTransportBrand> InfoTransportBrands { get; set; }

    public virtual DbSet<InfoTransportBrandTranslate> InfoTransportBrandTranslates { get; set; }

    public virtual DbSet<InfoTransportColor> InfoTransportColors { get; set; }

    public virtual DbSet<InfoTransportColorTranslate> InfoTransportColorTranslates { get; set; }

    public virtual DbSet<InfoTransportModel> InfoTransportModels { get; set; }

    public virtual DbSet<InfoTransportModelLiquid> InfoTransportModelLiquids { get; set; }

    public virtual DbSet<InfoTransportModelTranslate> InfoTransportModelTranslates { get; set; }

    public virtual DbSet<InfoTransportUseType> InfoTransportUseTypes { get; set; }

    public virtual DbSet<InfoTransportUseTypeTranslate> InfoTransportUseTypeTranslates { get; set; }

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

    public virtual DbSet<SysUser> SysUsers { get; set; }

    public virtual DbSet<SysUserLog> SysUserLogs { get; set; }

    public virtual DbSet<SysUserRefreshToken> SysUserRefreshTokens { get; set; }

    public virtual DbSet<SysUserRole> SysUserRoles { get; set; }

    public virtual DbSet<SysUserToken> SysUserTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=autopark_db;Pooling=true;Maximum Pool Size=10000;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocExpense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_expense_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Contractor).WithMany(p => p.DocExpenses).HasConstraintName("fk_contractor_id");

            entity.HasOne(d => d.Driver).WithMany(p => p.DocExpenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_driver_id");

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.DocExpenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_expense_type_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocExpenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");

            entity.HasOne(d => d.Transport).WithMany(p => p.DocExpenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_id");
        });

        modelBuilder.Entity<DocExpenseFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_expense_file_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocExpenseFiles).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocExpenseHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_expense_history_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocExpenseHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocExpenseHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");
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

        modelBuilder.Entity<DocRefuel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_refuel_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Driver).WithMany(p => p.DocRefuels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_driver_id");

            entity.HasOne(d => d.FuelCard).WithMany(p => p.DocRefuels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fuel_card_id");

            entity.HasOne(d => d.FuelType).WithMany(p => p.DocRefuels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fuel_type_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocRefuels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");

            entity.HasOne(d => d.Transport).WithMany(p => p.DocRefuels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_id");
        });

        modelBuilder.Entity<DocRefuelFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_refuel_file_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocRefuelFiles).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocRefuelHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_refuel_history_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocRefuelHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocRefuelHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");
        });

        modelBuilder.Entity<DocTransportSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Driver).WithMany(p => p.DocTransportSettings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_driver_id");

            entity.HasOne(d => d.ResponsiblePerson).WithMany(p => p.DocTransportSettings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_responsible_person_id");

            entity.HasOne(d => d.Status).WithMany(p => p.DocTransportSettings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_status_id");

            entity.HasOne(d => d.Transport).WithMany(p => p.DocTransportSettings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_id");
        });

        modelBuilder.Entity<DocTransportSettingBattery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_battery_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.BatteryType).WithMany(p => p.DocTransportSettingBatteries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_battery_type_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.DocTransportSettingBatteries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocTransportSettingFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_file_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocTransportSettingFiles).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocTransportSettingFuel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_fuel_pkey");

            entity.HasIndex(e => new { e.OwnerId, e.IsDeleted, e.FuelTypeId }, "uindx__doc_tr_set_fuel_ownid_isdel_futypeid")
                .IsUnique()
                .HasFilter("(is_deleted = false)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.FuelType).WithMany(p => p.DocTransportSettingFuels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fuel_type_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.DocTransportSettingFuels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocTransportSettingInspection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_inspection_pkey");

            entity.HasIndex(e => new { e.OwnerId, e.IsDeleted }, "uindx__doc_tr_set_insp_ownid_isdel")
                .IsUnique()
                .HasFilter("(is_deleted = false)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocTransportSettingInspections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");

            entity.HasOne(d => d.ResponsiblePerson).WithMany(p => p.DocTransportSettingInspections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_responsible_person_id");
        });

        modelBuilder.Entity<DocTransportSettingInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_insurance_pkey");

            entity.HasIndex(e => new { e.OwnerId, e.IsDeleted }, "uindx__doc_tr_set_insurance_ownid_isdel")
                .IsUnique()
                .HasFilter("(is_deleted = false)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Contractor).WithMany(p => p.DocTransportSettingInsurances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contractor_id");

            entity.HasOne(d => d.InsuranceType).WithMany(p => p.DocTransportSettingInsurances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_insurance_type_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.DocTransportSettingInsurances).HasConstraintName("fk_owner_id");

            entity.HasOne(d => d.ResponsiblePerson).WithMany(p => p.DocTransportSettingInsurances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_responsible_person_id");
        });

        modelBuilder.Entity<DocTransportSettingLiquid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_liquid_pkey");

            entity.HasIndex(e => new { e.OwnerId, e.IsDeleted }, "uindx__doc_tr_set_liq_ownid_isdel")
                .IsUnique()
                .HasFilter("(is_deleted = false)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocTransportSettingLiquids)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocTransportSettingOil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_oil_pkey");

            entity.HasIndex(e => new { e.OwnerId, e.IsDeleted }, "uindx__doc_tr_set_oil_ownid_isdel")
                .IsUnique()
                .HasFilter("(is_deleted = false)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.OilType).WithMany(p => p.DocTransportSettingOils)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_oil_type_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.DocTransportSettingOils)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<DocTransportSettingTire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_transport_setting_tire_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.DocTransportSettingTires)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");
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

        modelBuilder.Entity<EnumExpenseType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_expense_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumExpenseTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumExpenseTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_expense_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumExpenseTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumExpenseTypeTranslates).HasConstraintName("fk_owner_id");
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

        modelBuilder.Entity<EnumTransmissionBoxType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_transmission_box_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.EnumTransmissionBoxTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumTransmissionBoxTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_transmission_box_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumTransmissionBoxTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumTransmissionBoxTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<EnumTransportType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_transport_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<EnumTransportTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_transport_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.EnumTransportTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.EnumTransportTypeTranslates).HasConstraintName("fk_owner_id");
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

        modelBuilder.Entity<HlDriver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_driver_pkey");

            entity.HasIndex(e => new { e.BranchId, e.PersonId, e.StateId }, "uix__hl_driver__brid_perid_stid")
                .IsUnique()
                .HasFilter("(state_id = 1)");

            entity.HasIndex(e => e.UniqueCode, "uix__hl_driver__uniqcd")
                .IsUnique()
                .HasFilter("(state_id = 1)");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.HlDrivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.Person).WithMany(p => p.HlDrivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_person_id");

            entity.HasOne(d => d.QrCodeRegistry).WithMany(p => p.HlDrivers).HasConstraintName("fk_qr_code_registry_id");

            entity.HasOne(d => d.State).WithMany(p => p.HlDrivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<HlDriverDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_driver_document_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.HlDriverDocuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<HlFuelCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_fuel_card_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Driver).WithMany(p => p.HlFuelCards).HasConstraintName("fk_driver_id");

            entity.HasOne(d => d.PlasticCardType).WithMany(p => p.HlFuelCards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_plastic_card_type_id");

            entity.HasOne(d => d.State).WithMany(p => p.HlFuelCards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.Transport).WithMany(p => p.HlFuelCards).HasConstraintName("fk_transport_id");
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

        modelBuilder.Entity<HlTransport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_transport_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.HlTransports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_id");

            entity.HasOne(d => d.Department).WithMany(p => p.HlTransports).HasConstraintName("fk_department_id");

            entity.HasOne(d => d.QrCodeRegistry).WithMany(p => p.HlTransports).HasConstraintName("fk_qr_code_registry_id");

            entity.HasOne(d => d.State).WithMany(p => p.HlTransports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.TransportBrand).WithMany(p => p.HlTransports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_brand_id");

            entity.HasOne(d => d.TransportColor).WithMany(p => p.HlTransports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_color_id");

            entity.HasOne(d => d.TransportModel).WithMany(p => p.HlTransports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_model_id");

            entity.HasOne(d => d.TransportUseType).WithMany(p => p.HlTransports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_use_type_id");
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

        modelBuilder.Entity<InfoBatteryType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_battery_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoBatteryTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoBatteryTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_battery_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoBatteryTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoBatteryTypeTranslates).HasConstraintName("fk_owner_id");
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

            entity.HasOne(d => d.Bank).WithMany(p => p.InfoContractors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bank_id");

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

        modelBuilder.Entity<InfoFuelType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_fuel_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoFuelTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoFuelTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_fuel_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoFuelTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoFuelTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoInsuranceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_insurance_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoInsuranceTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoInsuranceTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_insurance_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoInsuranceTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoInsuranceTypeTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoLiquidType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_liquid_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoLiquidTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoLiquidTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_liquid_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoLiquidTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoLiquidTypeTranslates).HasConstraintName("fk_owner_id");
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

        modelBuilder.Entity<InfoOilModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_oil_model_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoOilModels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoOilModelTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_oil_model_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoOilModelTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoOilModelTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoOilType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_oil_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoOilTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoOilTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_oil_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoOilTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoOilTypeTranslates).HasConstraintName("fk_owner_id");
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

        modelBuilder.Entity<InfoTireSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_tire_size_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoTireSizes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoTransportBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_brand_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoTransportBrands)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoTransportBrandTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_brand_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoTransportBrandTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoTransportBrandTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoTransportColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_color_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoTransportColors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoTransportColorTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_color_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoTransportColorTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoTransportColorTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoTransportModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_model_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoTransportModels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.TransportType).WithMany(p => p.InfoTransportModels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_type_id");
        });

        modelBuilder.Entity<InfoTransportModelLiquid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_model_liquid_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoTransportModelLiquids)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<InfoTransportModelTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_model_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoTransportModelTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoTransportModelTranslates).HasConstraintName("fk_owner_id");
        });

        modelBuilder.Entity<InfoTransportUseType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_use_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.State).WithMany(p => p.InfoTransportUseTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.TransportType).WithMany(p => p.InfoTransportUseTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transport_type_id");
        });

        modelBuilder.Entity<InfoTransportUseTypeTranslate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_transport_use_type_translate_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.InfoTransportUseTypeTranslates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_language_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InfoTransportUseTypeTranslates).HasConstraintName("fk_owner_id");
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
