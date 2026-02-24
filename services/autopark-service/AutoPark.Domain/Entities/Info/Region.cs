using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_region")]
public class Region :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public Region()
    {
        Translates = new HashSet<RegionTranslate>();
    }

    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("code")]
    [StringLength(50)]
    public string Code { get; set; }

    [Column("soato")]
    [StringLength(50)]
    public string Soato { get; set; }

    [Column("roaming_code")]
    [StringLength(50)]
    public string RoamingCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("state_id")]
    public int StateId { get; private set; }

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

    #region RelationShips
    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; } = null!;

    [InverseProperty(nameof(RegionTranslate.Owner))]
    public virtual ICollection<RegionTranslate> Translates { get; set; } = new List<RegionTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;
    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;
    #endregion

}
