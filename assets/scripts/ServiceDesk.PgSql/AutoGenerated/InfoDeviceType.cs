using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("info_device_type")]
public partial class InfoDeviceType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

    [Column("base_device_type_id")]
    public int BaseDeviceTypeId { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [ForeignKey("BaseDeviceTypeId")]
    [InverseProperty("InfoDeviceTypes")]
    public virtual EnumBaseDeviceType BaseDeviceType { get; set; } = null!;

    [InverseProperty("DeviceType")]
    public virtual ICollection<HlDevice> HlDevices { get; set; } = new List<HlDevice>();

    [InverseProperty("DeviceType")]
    public virtual ICollection<InfoDeviceModel> InfoDeviceModels { get; set; } = new List<InfoDeviceModel>();

    [InverseProperty("DeviceType")]
    public virtual ICollection<InfoDevicePart> InfoDeviceParts { get; set; } = new List<InfoDevicePart>();

    [InverseProperty("DeviceType")]
    public virtual ICollection<InfoDeviceSpareType> InfoDeviceSpareTypes { get; set; } = new List<InfoDeviceSpareType>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoDeviceTypeTranslate> InfoDeviceTypeTranslates { get; set; } = new List<InfoDeviceTypeTranslate>();

    [InverseProperty("DeviceType")]
    public virtual ICollection<InfoServiceType> InfoServiceTypes { get; set; } = new List<InfoServiceType>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoDeviceTypes")]
    public virtual EnumState State { get; set; } = null!;
}
