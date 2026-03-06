using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_region", Schema = "adm")]
public class Region :
    BaseEntity<int>
{
    public Region()
    {
        Translates = new HashSet<RegionTranslate>();
    }

    #region Properties

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
    public int StateId { get; set; }

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

    #region RelationShips
    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; } = null!;

    [InverseProperty(nameof(RegionTranslate.Owner))]
    public virtual ICollection<RegionTranslate> Translates { get; set; } = new List<RegionTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;
    #endregion

}
