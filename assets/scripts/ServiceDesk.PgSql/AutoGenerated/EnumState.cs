using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

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
    public virtual ICollection<EnumApplicationPurpose> EnumApplicationPurposes { get; set; } = new List<EnumApplicationPurpose>();

    [InverseProperty("State")]
    public virtual ICollection<EnumCodeFormType> EnumCodeFormTypes { get; set; } = new List<EnumCodeFormType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumDocumentType> EnumDocumentTypes { get; set; } = new List<EnumDocumentType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumExecutorType> EnumExecutorTypes { get; set; } = new List<EnumExecutorType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumMovementType> EnumMovementTypes { get; set; } = new List<EnumMovementType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumPlasticCardType> EnumPlasticCardTypes { get; set; } = new List<EnumPlasticCardType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumQrCodeType> EnumQrCodeTypes { get; set; } = new List<EnumQrCodeType>();

    [InverseProperty("Owner")]
    public virtual ICollection<EnumStateTranslate> EnumStateTranslates { get; set; } = new List<EnumStateTranslate>();

    [InverseProperty("State")]
    public virtual ICollection<HlDepartment> HlDepartments { get; set; } = new List<HlDepartment>();

    [InverseProperty("State")]
    public virtual ICollection<HlDevice> HlDevices { get; set; } = new List<HlDevice>();

    [InverseProperty("State")]
    public virtual ICollection<HlPerson> HlPeople { get; set; } = new List<HlPerson>();

    [InverseProperty("State")]
    public virtual ICollection<HlPosition> HlPositions { get; set; } = new List<HlPosition>();

    [InverseProperty("State")]
    public virtual ICollection<InfoBank> InfoBanks { get; set; } = new List<InfoBank>();

    [InverseProperty("State")]
    public virtual ICollection<InfoCitizenship> InfoCitizenships { get; set; } = new List<InfoCitizenship>();

    [InverseProperty("State")]
    public virtual ICollection<InfoContractor> InfoContractors { get; set; } = new List<InfoContractor>();

    [InverseProperty("State")]
    public virtual ICollection<InfoCountry> InfoCountries { get; set; } = new List<InfoCountry>();

    [InverseProperty("State")]
    public virtual ICollection<InfoCurrency> InfoCurrencies { get; set; } = new List<InfoCurrency>();

    [InverseProperty("State")]
    public virtual ICollection<InfoDeviceModel> InfoDeviceModels { get; set; } = new List<InfoDeviceModel>();

    [InverseProperty("State")]
    public virtual ICollection<InfoDevicePart> InfoDeviceParts { get; set; } = new List<InfoDevicePart>();

    [InverseProperty("State")]
    public virtual ICollection<InfoDeviceSpareType> InfoDeviceSpareTypes { get; set; } = new List<InfoDeviceSpareType>();

    [InverseProperty("State")]
    public virtual ICollection<InfoDeviceType> InfoDeviceTypes { get; set; } = new List<InfoDeviceType>();

    [InverseProperty("State")]
    public virtual ICollection<InfoDistrict> InfoDistricts { get; set; } = new List<InfoDistrict>();

    [InverseProperty("State")]
    public virtual ICollection<InfoNationality> InfoNationalities { get; set; } = new List<InfoNationality>();

    [InverseProperty("State")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [InverseProperty("State")]
    public virtual ICollection<InfoRegion> InfoRegions { get; set; } = new List<InfoRegion>();

    [InverseProperty("State")]
    public virtual ICollection<InfoServiceType> InfoServiceTypes { get; set; } = new List<InfoServiceType>();

    [InverseProperty("State")]
    public virtual ICollection<SysPermission> SysPermissions { get; set; } = new List<SysPermission>();

    [InverseProperty("State")]
    public virtual ICollection<SysRole> SysRoles { get; set; } = new List<SysRole>();

    [InverseProperty("State")]
    public virtual ICollection<SysUserRole> SysUserRoles { get; set; } = new List<SysUserRole>();

    [InverseProperty("State")]
    public virtual ICollection<SysUser> SysUsers { get; set; } = new List<SysUser>();
}
