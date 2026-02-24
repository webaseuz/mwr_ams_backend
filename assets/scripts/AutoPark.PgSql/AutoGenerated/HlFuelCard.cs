using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_fuel_card")]
[Index("CardNumber", Name = "uix__hl_fl_crd__cardnum", IsUnique = true)]
[Index("StateId", "DriverId", Name = "uix__hl_fl_crd__stid_drvrid", IsUnique = true)]
[Index("StateId", "TransportId", Name = "uix__hl_fl_crd__stid_trnptid", IsUnique = true)]
public partial class HlFuelCard
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("driver_id")]
    public int? DriverId { get; set; }

    [Column("transport_id")]
    public int? TransportId { get; set; }

    [Column("plastic_card_type_id")]
    public int PlasticCardTypeId { get; set; }

    [Column("card_number")]
    [StringLength(50)]
    public string CardNumber { get; set; } = null!;

    [Column("expire_at")]
    public DateOnly? ExpireAt { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

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

    [InverseProperty("FuelCard")]
    public virtual ICollection<DocRefuel> DocRefuels { get; set; } = new List<DocRefuel>();

    [ForeignKey("DriverId")]
    [InverseProperty("HlFuelCards")]
    public virtual HlDriver? Driver { get; set; }

    [ForeignKey("PlasticCardTypeId")]
    [InverseProperty("HlFuelCards")]
    public virtual EnumPlasticCardType PlasticCardType { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("HlFuelCards")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("TransportId")]
    [InverseProperty("HlFuelCards")]
    public virtual HlTransport? Transport { get; set; }
}
