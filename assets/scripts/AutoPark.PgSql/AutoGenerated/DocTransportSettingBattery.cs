using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting_battery")]
[Index("OwnerId", Name = "indx_doc_transport_setting_battery_own_id")]
public partial class DocTransportSettingBattery
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("battery_type_id")]
    public int BatteryTypeId { get; set; }

    [Column("produced_at")]
    public DateOnly ProducedAt { get; set; }

    [Column("mile_age")]
    [Precision(18, 2)]
    public decimal MileAge { get; set; }

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

    [ForeignKey("BatteryTypeId")]
    [InverseProperty("DocTransportSettingBatteries")]
    public virtual InfoBatteryType BatteryType { get; set; } = null!;

    [ForeignKey("OwnerId")]
    [InverseProperty("DocTransportSettingBatteries")]
    public virtual DocTransportSetting Owner { get; set; } = null!;
}
