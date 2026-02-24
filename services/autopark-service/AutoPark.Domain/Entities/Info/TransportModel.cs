using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_transport_model")]
public class TransportModel :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public TransportModel()
    {
        Translates = new HashSet<TransportModelTranslate>();
        Files = new HashSet<TransportModelFile>();
        Liquids = new HashSet<TransportModelLiquid>();
        Fuels = new HashSet<TransportModelFuel>();
        Oils = new HashSet<TransportModelOil>();
    }

    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("transport_type_id")]
    public int TransportTypeId { get; set; }

    [Column("transport_brand_id")]
    public int TransportBrandId { get; set; }
    [Column("transmission_box_type_id")]
    public int TransmissionBoxTypeId { get; set; }

    [Column("load_capacity", TypeName = "NUMERIC(18,2)")]
    public decimal? LoadCapacity { get; set; }

    [Column("seat_count")]
    public int SeatCount { get; set; }
    [Column("consumption_per_100km")]
    public decimal ConsumptionPer100Km { get; set; }
    [Column("consumption_per_hour")]
    public decimal ConsumptionPerHour { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("state_id")]
    public int StateId { get; private set; }

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
    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;
    [ForeignKey(nameof(TransmissionBoxTypeId))]
    public virtual TransmissionBoxType TransmissionBoxType { get; set; } = null!;
    [InverseProperty(nameof(TransportModelTranslate.Owner))]
    public virtual ICollection<TransportModelTranslate> Translates { get; set; } = new List<TransportModelTranslate>();
    [InverseProperty(nameof(TransportModelFile.TransportModel))]
    public virtual ICollection<TransportModelFile> Files { get; set; } = new List<TransportModelFile>();
    [InverseProperty(nameof(TransportModelLiquid.Owner))]
    public virtual ICollection<TransportModelLiquid> Liquids { get; set; } = new List<TransportModelLiquid>();

    [InverseProperty(nameof(TransportModelFuel.Owner))]
    public virtual ICollection<TransportModelFuel> Fuels { get; set; } = new List<TransportModelFuel>();
    [InverseProperty(nameof(TransportModelOil.Owner))]
    public virtual ICollection<TransportModelOil> Oils { get; set; } = new List<TransportModelOil>();

    [ForeignKey(nameof(TransportTypeId))]
    public virtual TransportType TransportType { get; set; } = null!;
    [ForeignKey(nameof(TransportBrandId))]
    public virtual TransportBrand TransportBrand { get; set; } = null!;

    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;
    #endregion

}
