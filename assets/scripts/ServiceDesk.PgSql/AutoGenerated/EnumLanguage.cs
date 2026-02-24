using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

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
    public virtual ICollection<EnumApplicationPurposeTranslate> EnumApplicationPurposeTranslates { get; set; } = new List<EnumApplicationPurposeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumBaseDeviceTypeTranslate> EnumBaseDeviceTypeTranslates { get; set; } = new List<EnumBaseDeviceTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumDocumentTypeTranslate> EnumDocumentTypeTranslates { get; set; } = new List<EnumDocumentTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumExecutorTypeTranslate> EnumExecutorTypeTranslates { get; set; } = new List<EnumExecutorTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumGenderTranslate> EnumGenderTranslates { get; set; } = new List<EnumGenderTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumMovementTypeTranslate> EnumMovementTypeTranslates { get; set; } = new List<EnumMovementTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumPlasticCardTypeTranslate> EnumPlasticCardTypeTranslates { get; set; } = new List<EnumPlasticCardTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumStateTranslate> EnumStateTranslates { get; set; } = new List<EnumStateTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<EnumStatusTranslate> EnumStatusTranslates { get; set; } = new List<EnumStatusTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<HlDepartmentTranslate> HlDepartmentTranslates { get; set; } = new List<HlDepartmentTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<HlPositionTranslate> HlPositionTranslates { get; set; } = new List<HlPositionTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoBankTranslate> InfoBankTranslates { get; set; } = new List<InfoBankTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoCitizenshipTranslate> InfoCitizenshipTranslates { get; set; } = new List<InfoCitizenshipTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoCountryTranslate> InfoCountryTranslates { get; set; } = new List<InfoCountryTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoCurrencyTranslate> InfoCurrencyTranslates { get; set; } = new List<InfoCurrencyTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoDeviceModelTranslate> InfoDeviceModelTranslates { get; set; } = new List<InfoDeviceModelTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoDevicePartTranslate> InfoDevicePartTranslates { get; set; } = new List<InfoDevicePartTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoDeviceSpareTypeTranslate> InfoDeviceSpareTypeTranslates { get; set; } = new List<InfoDeviceSpareTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoDeviceTypeTranslate> InfoDeviceTypeTranslates { get; set; } = new List<InfoDeviceTypeTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoDistrictTranslate> InfoDistrictTranslates { get; set; } = new List<InfoDistrictTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoNationalityTranslate> InfoNationalityTranslates { get; set; } = new List<InfoNationalityTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoOrganizationTranslate> InfoOrganizationTranslates { get; set; } = new List<InfoOrganizationTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoRegionTranslate> InfoRegionTranslates { get; set; } = new List<InfoRegionTranslate>();

    [InverseProperty("Language")]
    public virtual ICollection<InfoServiceTypeTranslate> InfoServiceTypeTranslates { get; set; } = new List<InfoServiceTypeTranslate>();

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
