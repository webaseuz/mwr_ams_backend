using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_plastic_card_type", Schema = "adm")]
public class PlasticCardType :
    BaseEntity<int>
{
    public PlasticCardType()
    {
        Translates = new HashSet<PlasticCardTypeTranslate>();
    }

    #region Properties
    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

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

    #region Relationships
    [InverseProperty(nameof(PlasticCardTypeTranslate.Owner))]
    public virtual ICollection<PlasticCardTypeTranslate> Translates { get; set; } = new List<PlasticCardTypeTranslate>();

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
    #endregion

}
