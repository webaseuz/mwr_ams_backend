using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_department")]
public partial class HlDepartment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

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

    [ForeignKey("BranchId")]
    [InverseProperty("HlDepartments")]
    public virtual HlBranch Branch { get; set; } = null!;

    [InverseProperty("Owner")]
    public virtual ICollection<HlDepartmentTranslate> HlDepartmentTranslates { get; set; } = new List<HlDepartmentTranslate>();

    [InverseProperty("Department")]
    public virtual ICollection<HlTransport> HlTransports { get; set; } = new List<HlTransport>();

    [ForeignKey("StateId")]
    [InverseProperty("HlDepartments")]
    public virtual EnumState State { get; set; } = null!;
}
