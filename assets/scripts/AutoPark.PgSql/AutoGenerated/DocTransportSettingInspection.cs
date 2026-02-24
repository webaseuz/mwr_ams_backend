using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting_inspection")]
public partial class DocTransportSettingInspection
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("date_at")]
    public DateOnly DateAt { get; set; }

    [Column("expire_at")]
    public DateOnly ExpireAt { get; set; }

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

    [Column("details")]
    public string? Details { get; set; }

    [Column("notify_before_day")]
    public int NotifyBeforeDay { get; set; }

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

    [ForeignKey("OwnerId")]
    [InverseProperty("DocTransportSettingInspections")]
    public virtual DocTransportSetting Owner { get; set; } = null!;

    [ForeignKey("ResponsiblePersonId")]
    [InverseProperty("DocTransportSettingInspections")]
    public virtual HlPerson ResponsiblePerson { get; set; } = null!;
}
