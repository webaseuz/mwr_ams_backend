using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_fuel_card")]
public class FuelCard :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public FuelCard()
    {
        Refuels = new HashSet<Refuel>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("driver_id")]
    public int? DriverId { get; set; }

    [Column("branch_id")]
    public int? BranchId { get; set; }

    [Column("transport_id")]
    public int? TransportId { get; set; }

    [Column("plastic_card_type_id")]
    public int PlasticCardTypeId { get; set; }

    [Column("card_number")]
    [StringLength(50)]
    public string CardNumber { get; set; } = null!;

    [Column("expire_at")]
    public DateTime? ExpireAt { get; set; }

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
    #endregion

    #region Relationships
    [InverseProperty(nameof(Refuel.FuelCard))]
    public virtual ICollection<Refuel> Refuels { get; set; } = new List<Refuel>();

    [ForeignKey(nameof(DriverId))]
    public virtual Driver Driver { get; set; }

    [ForeignKey(nameof(PlasticCardTypeId))]
    public virtual PlasticCardType PlasticCardType { get; set; } = null!;

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    [ForeignKey(nameof(TransportId))]
    public virtual Transport Transport { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }
    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;
    #endregion
}
