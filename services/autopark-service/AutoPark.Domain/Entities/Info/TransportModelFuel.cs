using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_transport_model_fuel")]
public class TransportModelFuel :
    IHaveIdProp<int>
{
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("fuel_type_id")]
    public int FuelTypeId { get; set; }

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
    [ForeignKey(nameof(FuelTypeId))]
    public virtual FuelType FuelType { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual TransportModel Owner { get; set; } = null!;
    #endregion
}
