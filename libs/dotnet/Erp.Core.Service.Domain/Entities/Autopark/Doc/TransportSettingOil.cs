using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("doc_transport_setting_oil", Schema = "autopark")]
public class TransportSettingOil :
    BaseEntity<long>
{
    #region Properties
    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("oil_type_id")]
    public int OilTypeId { get; set; }
    //[Column("oil_model_id")]
    //public int OilModelId { get; set; }

    //[Column("tank_volume", TypeName = "NUMERIC(18,2)")]
    //public decimal TankVolume { get; set; }

    [Column("monthly_limit", TypeName = "NUMERIC(18,2)")]
    public decimal MonthlyLimit { get; set; }

    [Column("remaining", TypeName = "NUMERIC(18,2)")]
    public decimal Remaining { get; set; }

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
    [ForeignKey(nameof(OilTypeId))]
    public virtual OilType OilType { get; set; } = null!;
    //[ForeignKey(nameof(OilModelId))]
    //public virtual OilModel OilModel { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual TransportSetting Owner { get; set; } = null!;

    #endregion

}
