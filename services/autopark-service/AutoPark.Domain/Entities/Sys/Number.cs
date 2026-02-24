using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("sys_number")]
public class Number :
    IHaveIdProp<int>
{

    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("document")]
    [Required]
    [StringLength(100)]
    public string Document { get; set; }

    [Column("current_number")]
    public int CurrentNumber { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("branch_id")]
    public int? BranchId { get; set; }

    [Column("finance_year")]
    public int FinanceYear { get; set; }

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

    #endregion

    #region
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization Organization { get; set; } = null!;

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    #endregion

    #region Methods

    #endregion
}
