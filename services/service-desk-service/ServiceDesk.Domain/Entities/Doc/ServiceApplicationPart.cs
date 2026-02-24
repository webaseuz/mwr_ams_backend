using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bms.WEBASE.Models;

namespace ServiceDesk.Domain;

[Table("doc_service_application_part")]
public class ServiceApplicationPart :
    IHaveIdProp<long>
{
    public ServiceApplicationPart()
    {
    }
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("device_part_id")]
    public int? DevicePartId { get; set; }

    [Column("application_purpose_id")]
    public int ApplicationPurposeId { get; set; }

    [Column("service_type_id")]
    public int? ServiceTypeId { get; set; }

    [Column("additional_desc")]
    [StringLength(50)]
    public string AdditionalDesc { get; set; }

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

    [ForeignKey(nameof(ApplicationPurposeId))]
    public virtual ApplicationPurpose ApplicationPurpose { get; set; } = null!;

    [ForeignKey(nameof(DevicePartId))]
    public virtual DevicePart DevicePart { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual ServiceApplication Owner { get; set; } = null!;

    [ForeignKey(nameof(ServiceTypeId))]
    public virtual ServiceType ServiceType { get; set; }
}
