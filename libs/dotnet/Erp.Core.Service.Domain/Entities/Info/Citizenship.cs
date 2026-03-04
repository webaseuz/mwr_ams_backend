using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_citizenship")]
public class Citizenship :
    BaseEntity<int>
{
    public Citizenship()
    {
        Translates = new HashSet<CitizenshipTranslate>();
    }

    #region Properties

    [Column("wb_code")]
    [StringLength(50)]
    public string WbCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    [Column("is_citizenship")]
    public bool IsCitizenship { get; set; }

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
    [InverseProperty(nameof(CitizenshipTranslate.Owner))]
    public virtual ICollection<CitizenshipTranslate> Translates { get; set; } = new List<CitizenshipTranslate>();

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;

    #endregion

}
