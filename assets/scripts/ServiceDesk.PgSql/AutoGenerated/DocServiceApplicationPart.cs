using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("doc_service_application_part")]
[Index("OwnerId", Name = "indx__doc_ser_app_prt__ownid")]
public partial class DocServiceApplicationPart
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("device_part_id")]
    public int DevicePartId { get; set; }

    [Column("application_purpose_id")]
    public int ApplicationPurposeId { get; set; }

    [Column("service_type_id")]
    public int? ServiceTypeId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [ForeignKey("ApplicationPurposeId")]
    [InverseProperty("DocServiceApplicationParts")]
    public virtual EnumApplicationPurpose ApplicationPurpose { get; set; } = null!;

    [ForeignKey("DevicePartId")]
    [InverseProperty("DocServiceApplicationParts")]
    public virtual InfoDevicePart DevicePart { get; set; } = null!;

    [InverseProperty("Owner")]
    public virtual ICollection<DocServiceApplicationSpare> DocServiceApplicationSpares { get; set; } = new List<DocServiceApplicationSpare>();

    [ForeignKey("OwnerId")]
    [InverseProperty("DocServiceApplicationParts")]
    public virtual DocServiceApplication Owner { get; set; } = null!;

    [ForeignKey("ServiceTypeId")]
    [InverseProperty("DocServiceApplicationParts")]
    public virtual InfoServiceType? ServiceType { get; set; }
}
