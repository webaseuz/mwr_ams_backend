using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("info_device_model")]
public partial class InfoDeviceModel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

    [Column("device_type_id")]
    public int DeviceTypeId { get; set; }

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

    [ForeignKey("DeviceTypeId")]
    [InverseProperty("InfoDeviceModels")]
    public virtual InfoDeviceType DeviceType { get; set; } = null!;

    [InverseProperty("DeviceModel")]
    public virtual ICollection<HlDevice> HlDevices { get; set; } = new List<HlDevice>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoDeviceModelTranslate> InfoDeviceModelTranslates { get; set; } = new List<InfoDeviceModelTranslate>();

    [InverseProperty("DeviceModel")]
    public virtual ICollection<InfoDeviceSpareType> InfoDeviceSpareTypes { get; set; } = new List<InfoDeviceSpareType>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoDeviceModels")]
    public virtual EnumState State { get; set; } = null!;
}
