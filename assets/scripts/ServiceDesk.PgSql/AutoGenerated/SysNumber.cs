using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("sys_number")]
public partial class SysNumber
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("document")]
    [StringLength(100)]
    public string Document { get; set; } = null!;

    [Column("current_number")]
    public int CurrentNumber { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

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

    [ForeignKey("BranchId")]
    [InverseProperty("SysNumbers")]
    public virtual HlBranch Branch { get; set; } = null!;

    [ForeignKey("OrganizationId")]
    [InverseProperty("SysNumbers")]
    public virtual InfoOrganization Organization { get; set; } = null!;
}
