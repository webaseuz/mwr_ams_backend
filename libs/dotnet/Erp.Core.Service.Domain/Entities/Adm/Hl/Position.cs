using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_position", Schema = "adm")]
public class Position :
    BaseEntity<int>
{
    public Position()
    {
        Translates = new HashSet<PositionTranslate>();
    }

    #region Properties

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("code")]
    [StringLength(50)]
    public string Code { get; set; } = null!;

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

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

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    [InverseProperty(nameof(PositionTranslate.Owner))]
    public virtual ICollection<PositionTranslate> Translates { get; set; }
    [InverseProperty(nameof(User.Position))]
    public virtual ICollection<User> Users { get; set; }

    #endregion

}
