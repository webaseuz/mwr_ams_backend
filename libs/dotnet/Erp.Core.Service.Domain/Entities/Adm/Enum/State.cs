using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_state", Schema = "adm")]
public class State :
    BaseEntity<int>
{
    public State()
    {
        Translates = new HashSet<StateTranslate>();
    }

    #region Properties

    [Column("order_code")]
    [StringLength(5)]
    public string OrderCode { get; set; }

    [Required]
    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; }

    [Required]
    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    #endregion

    #region Relationships
    [InverseProperty(nameof(StateTranslate.Owner))]
    public virtual ICollection<StateTranslate> Translates { get; set; } = new List<StateTranslate>();

    #endregion

}
