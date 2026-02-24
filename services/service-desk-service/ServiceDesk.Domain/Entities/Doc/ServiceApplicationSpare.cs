using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bms.WEBASE.Models;

namespace ServiceDesk.Domain;

[Table("doc_service_application_spare")]
public class ServiceApplicationSpare :
    IHaveIdProp<long>
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("device_spare_type_id")]
    public int DeviceSpareTypeId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

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

    [ForeignKey(nameof(DeviceSpareTypeId))]
    public virtual DeviceSpareType DeviceSpareType { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual ServiceApplication Owner { get; set; } = null!;
}
