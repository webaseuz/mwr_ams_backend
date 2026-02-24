using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_position")]
public partial class HlPosition
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

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
    public string? OrderCode { get; set; }

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

    [InverseProperty("Owner")]
    public virtual ICollection<HlPositionTranslate> HlPositionTranslates { get; set; } = new List<HlPositionTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("HlPositions")]
    public virtual EnumState State { get; set; } = null!;

    [InverseProperty("Position")]
    public virtual ICollection<SysUser> SysUsers { get; set; } = new List<SysUser>();
}
