using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_transport_model_oil")]
public class TransportModelOil :
    IHaveIdProp<int>
{
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("oil_type_id")]
    public int OilTypeId { get; set; }

    [Column("oil_model_id")]
    public int? OilModelId { get; set; }

    [Column("tank_volume")]
    [Precision(18, 2)]
    public decimal TankVolume { get; set; }

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
    #endregion

    #region Relationships
    [ForeignKey(nameof(OilTypeId))]
    public virtual OilType OilType { get; set; } = null!;

    [ForeignKey(nameof(OilModelId))]
    public virtual OilModel OilModel { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual TransportModel Owner { get; set; } = null!;
    #endregion
}
