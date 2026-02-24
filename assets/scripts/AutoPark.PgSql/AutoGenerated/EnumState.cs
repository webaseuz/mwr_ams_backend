using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_state")]
public partial class EnumState
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(5)]
    public string? OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("State")]
    public virtual ICollection<EnumCodeFormType> EnumCodeFormTypes { get; set; } = new List<EnumCodeFormType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumDocumentType> EnumDocumentTypes { get; set; } = new List<EnumDocumentType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumExpenseType> EnumExpenseTypes { get; set; } = new List<EnumExpenseType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumPlasticCardType> EnumPlasticCardTypes { get; set; } = new List<EnumPlasticCardType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumQrCodeType> EnumQrCodeTypes { get; set; } = new List<EnumQrCodeType>();

    [InverseProperty("Owner")]
    public virtual ICollection<EnumStateTranslate> EnumStateTranslates { get; set; } = new List<EnumStateTranslate>();

    [InverseProperty("State")]
    public virtual ICollection<EnumTransmissionBoxType> EnumTransmissionBoxTypes { get; set; } = new List<EnumTransmissionBoxType>();

    [InverseProperty("State")]
    public virtual ICollection<HlDepartment> HlDepartments { get; set; } = new List<HlDepartment>();

    [InverseProperty("State")]
    public virtual ICollection<HlDriver> HlDrivers { get; set; } = new List<HlDriver>();

    [InverseProperty("State")]
    public virtual ICollection<HlFuelCard> HlFuelCards { get; set; } = new List<HlFuelCard>();

    [InverseProperty("State")]
    public virtual ICollection<HlPerson> HlPeople { get; set; } = new List<HlPerson>();

    [InverseProperty("State")]
    public virtual ICollection<HlPosition> HlPositions { get; set; } = new List<HlPosition>();

    [InverseProperty("State")]
    public virtual ICollection<HlTransport> HlTransports { get; set; } = new List<HlTransport>();

    [InverseProperty("State")]
    public virtual ICollection<InfoBank> InfoBanks { get; set; } = new List<InfoBank>();

    [InverseProperty("State")]
    public virtual ICollection<InfoBatteryType> InfoBatteryTypes { get; set; } = new List<InfoBatteryType>();

    [InverseProperty("State")]
    public virtual ICollection<InfoCitizenship> InfoCitizenships { get; set; } = new List<InfoCitizenship>();

    [InverseProperty("State")]
    public virtual ICollection<InfoContractor> InfoContractors { get; set; } = new List<InfoContractor>();

    [InverseProperty("State")]
    public virtual ICollection<InfoCountry> InfoCountries { get; set; } = new List<InfoCountry>();

    [InverseProperty("State")]
    public virtual ICollection<InfoCurrency> InfoCurrencies { get; set; } = new List<InfoCurrency>();

    [InverseProperty("State")]
    public virtual ICollection<InfoDistrict> InfoDistricts { get; set; } = new List<InfoDistrict>();

    [InverseProperty("State")]
    public virtual ICollection<InfoFuelType> InfoFuelTypes { get; set; } = new List<InfoFuelType>();

    [InverseProperty("State")]
    public virtual ICollection<InfoInsuranceType> InfoInsuranceTypes { get; set; } = new List<InfoInsuranceType>();

    [InverseProperty("State")]
    public virtual ICollection<InfoLiquidType> InfoLiquidTypes { get; set; } = new List<InfoLiquidType>();

    [InverseProperty("State")]
    public virtual ICollection<InfoNationality> InfoNationalities { get; set; } = new List<InfoNationality>();

    [InverseProperty("State")]
    public virtual ICollection<InfoOilModel> InfoOilModels { get; set; } = new List<InfoOilModel>();

    [InverseProperty("State")]
    public virtual ICollection<InfoOilType> InfoOilTypes { get; set; } = new List<InfoOilType>();

    [InverseProperty("State")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [InverseProperty("State")]
    public virtual ICollection<InfoRegion> InfoRegions { get; set; } = new List<InfoRegion>();

    [InverseProperty("State")]
    public virtual ICollection<InfoTireSize> InfoTireSizes { get; set; } = new List<InfoTireSize>();

    [InverseProperty("State")]
    public virtual ICollection<InfoTransportBrand> InfoTransportBrands { get; set; } = new List<InfoTransportBrand>();

    [InverseProperty("State")]
    public virtual ICollection<InfoTransportColor> InfoTransportColors { get; set; } = new List<InfoTransportColor>();

    [InverseProperty("State")]
    public virtual ICollection<InfoTransportModelLiquid> InfoTransportModelLiquids { get; set; } = new List<InfoTransportModelLiquid>();

    [InverseProperty("State")]
    public virtual ICollection<InfoTransportModel> InfoTransportModels { get; set; } = new List<InfoTransportModel>();

    [InverseProperty("State")]
    public virtual ICollection<InfoTransportUseType> InfoTransportUseTypes { get; set; } = new List<InfoTransportUseType>();

    [InverseProperty("State")]
    public virtual ICollection<SysPermission> SysPermissions { get; set; } = new List<SysPermission>();

    [InverseProperty("State")]
    public virtual ICollection<SysRole> SysRoles { get; set; } = new List<SysRole>();

    [InverseProperty("State")]
    public virtual ICollection<SysUserRole> SysUserRoles { get; set; } = new List<SysUserRole>();

    [InverseProperty("State")]
    public virtual ICollection<SysUser> SysUsers { get; set; } = new List<SysUser>();
}
