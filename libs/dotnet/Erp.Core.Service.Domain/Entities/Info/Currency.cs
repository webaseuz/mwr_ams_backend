using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_currency")]
public class Currency :
    BaseEntity<int>
{
    public Currency()
    {
        Translates = new HashSet<CurrencyTranslate>();
    }

    #region Properties

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("code")]
    [StringLength(3)]
    public string Code { get; set; } = null!;

    [Column("text_code")]
    [StringLength(3)]
    public string TextCode { get; set; } = null!;

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("picture_id")]
    public Guid? PictureId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("is_main")]
    public bool IsMain { get; set; }

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
    [InverseProperty(nameof(CurrencyTranslate.Owner))]
    public virtual ICollection<CurrencyTranslate> Translates { get; set; } = new List<CurrencyTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;
    #endregion

}
