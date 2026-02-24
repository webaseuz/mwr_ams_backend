using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("info_service_type")]
[Index("DeviceTypeId", Name = "indx__info_ser_typ__dev_ty_id")]
public partial class InfoServiceType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("device_type_id")]
    public int? DeviceTypeId { get; set; }

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
    [InverseProperty("InfoServiceTypes")]
    public virtual InfoDeviceType? DeviceType { get; set; }

    [InverseProperty("ServiceType")]
    public virtual ICollection<DocServiceApplicationPart> DocServiceApplicationParts { get; set; } = new List<DocServiceApplicationPart>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoServiceTypeTranslate> InfoServiceTypeTranslates { get; set; } = new List<InfoServiceTypeTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoServiceTypes")]
    public virtual EnumState State { get; set; } = null!;
}
