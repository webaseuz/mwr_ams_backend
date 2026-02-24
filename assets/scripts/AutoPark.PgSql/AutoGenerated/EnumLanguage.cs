using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_language")]
public partial class EnumLanguage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("short_name")]
    [StringLength(50)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Language")]
    public virtual ICollection<EnumDocumentTypeTranslate> EnumDocumentTypeTranslates { get; set; } = new List<EnumDocumentTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumExpenseTypeTranslate> EnumExpenseTypeTranslates { get; set; } = new List<EnumExpenseTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumGenderTranslate> EnumGenderTranslates { get; set; } = new List<EnumGenderTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumPlasticCardTypeTranslate> EnumPlasticCardTypeTranslates { get; set; } = new List<EnumPlasticCardTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumStateTranslate> EnumStateTranslates { get; set; } = new List<EnumStateTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumStatusTranslate> EnumStatusTranslates { get; set; } = new List<EnumStatusTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumTransmissionBoxTypeTranslate> EnumTransmissionBoxTypeTranslates { get; set; } = new List<EnumTransmissionBoxTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumTransportTypeTranslate> EnumTransportTypeTranslates { get; set; } = new List<EnumTransportTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<HlDepartmentTranslate> HlDepartmentTranslates { get; set; } = new List<HlDepartmentTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<HlPositionTranslate> HlPositionTranslates { get; set; } = new List<HlPositionTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoBankTranslate> InfoBankTranslates { get; set; } = new List<InfoBankTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoBatteryTypeTranslate> InfoBatteryTypeTranslates { get; set; } = new List<InfoBatteryTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoCitizenshipTranslate> InfoCitizenshipTranslates { get; set; } = new List<InfoCitizenshipTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoCountryTranslate> InfoCountryTranslates { get; set; } = new List<InfoCountryTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoCurrencyTranslate> InfoCurrencyTranslates { get; set; } = new List<InfoCurrencyTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoDistrictTranslate> InfoDistrictTranslates { get; set; } = new List<InfoDistrictTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoFuelTypeTranslate> InfoFuelTypeTranslates { get; set; } = new List<InfoFuelTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoInsuranceTypeTranslate> InfoInsuranceTypeTranslates { get; set; } = new List<InfoInsuranceTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoLiquidTypeTranslate> InfoLiquidTypeTranslates { get; set; } = new List<InfoLiquidTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoNationalityTranslate> InfoNationalityTranslates { get; set; } = new List<InfoNationalityTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoOilModelTranslate> InfoOilModelTranslates { get; set; } = new List<InfoOilModelTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoOilTypeTranslate> InfoOilTypeTranslates { get; set; } = new List<InfoOilTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoOrganizationTranslate> InfoOrganizationTranslates { get; set; } = new List<InfoOrganizationTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoRegionTranslate> InfoRegionTranslates { get; set; } = new List<InfoRegionTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoTransportBrandTranslate> InfoTransportBrandTranslates { get; set; } = new List<InfoTransportBrandTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoTransportColorTranslate> InfoTransportColorTranslates { get; set; } = new List<InfoTransportColorTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoTransportModelTranslate> InfoTransportModelTranslates { get; set; } = new List<InfoTransportModelTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoTransportUseTypeTranslate> InfoTransportUseTypeTranslates { get; set; } = new List<InfoTransportUseTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<SysPermissionGroupTranslate> SysPermissionGroupTranslates { get; set; } = new List<SysPermissionGroupTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<SysPermissionSubGroupTranslate> SysPermissionSubGroupTranslates { get; set; } = new List<SysPermissionSubGroupTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<SysPermissionTranslate> SysPermissionTranslates { get; set; } = new List<SysPermissionTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<SysRoleTranslate> SysRoleTranslates { get; set; } = new List<SysRoleTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<SysUser> SysUsers { get; set; } = new List<SysUser>();
}
