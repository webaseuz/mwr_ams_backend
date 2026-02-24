using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting_liquid")]
public class TransportSettingLiquid :
    IHaveIdProp<long>
{
    #region Properties
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }
    [Column("liquid_type_id")]
    public int LiquidTypeId { get; set; }

    [Column("tank_volume", TypeName = "NUMERIC(18,2)")]
    public decimal TankVolume { get; set; }

    [Column("monthly_limit", TypeName = "NUMERIC(18,2)")]
    public decimal MonthlyLimit { get; set; }

    [Column("remaining", TypeName = "NUMERIC(18,2)")]
    public decimal Remaining { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    #endregion

    #region Relationships
    [ForeignKey(nameof(OwnerId))]
    public virtual TransportSetting Owner { get; set; } = null!;

    [ForeignKey(nameof(LiquidTypeId))]
    public virtual LiquidType LiquidType { get; set; } = null!;
    #endregion

    #region Methods

    #endregion
}
