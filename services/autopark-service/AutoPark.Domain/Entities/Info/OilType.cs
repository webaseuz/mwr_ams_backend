using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_oil_type")]
public partial class OilType :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public OilType()
    {
        Translates = new HashSet<OilTypeTranslate>();
        OilModels = new HashSet<OilModel>();
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
    [InverseProperty(nameof(OilTypeTranslate.Owner))]
    public virtual ICollection<OilTypeTranslate> Translates { get; set; } = new List<OilTypeTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;
    [InverseProperty(nameof(OilModel.OilType))]
    public virtual ICollection<OilModel> OilModels { get; set; } = new List<OilModel>();

    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;

    #endregion

}
