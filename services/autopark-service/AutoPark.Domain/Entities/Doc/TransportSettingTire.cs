using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting_tire")]
public class TransportSettingTire :
    IHaveIdProp<long>
{
    #region Properties
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }
    [Column("tire_size_id")]
    public int TireSizeId { get; set; }

    [Column("tire_model_id")]
    public int? TireModelId { get; set; }

    [Column("size")]
    public string Size { get; set; }

    [Column("produced_at")]
    public DateTime ProducedAt { get; set; }

    [Column("mile_age", TypeName = "NUMERIC(18,2)")]
    public decimal MileAge { get; set; }

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
    [ForeignKey(nameof(TireSizeId))]
    public virtual TireSize TireSize { get; set; } = null!;
    [ForeignKey(nameof(TireModelId))]
    public virtual TireModel TireModel { get; set; } = null!;

    #endregion

    #region Methods

    #endregion
}
