using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("doc_transport_setting_battery", Schema = "autopark")]
public class TransportSettingBattery :
    BaseEntity<long>
{
    #region Properties
    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("battery_type_id")]
    public int BatteryTypeId { get; set; }

    [Column("produced_at")]
    public DateTime ProducedAt { get; set; }

    [Column("mile_age", TypeName = "NUMERIC(18,2)")]
    public decimal MileAge { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? LastModifiedAt { get; set; }

    [Column("modified_by")]
    public int? LastModifiedBy { get; set; }

    #endregion

    #region Relationships 
    [ForeignKey(nameof(BatteryTypeId))]
    public virtual BatteryType BatteryType { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual TransportSetting Owner { get; set; } = null!;

    #endregion

}
