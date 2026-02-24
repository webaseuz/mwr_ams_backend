using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("doc_spare_movement")]
public partial class DocSpareMovement
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateTime DocDate { get; set; }

    [Column("movement_type_id")]
    public int MovementTypeId { get; set; }

    [Column("from_branch_id")]
    public int? FromBranchId { get; set; }

    [Column("to_branch_id")]
    public int? ToBranchId { get; set; }

    [Column("from_user_id")]
    public int? FromUserId { get; set; }

    [Column("to_user_id")]
    public int? ToUserId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<DocSpareMovementHistory> DocSpareMovementHistories { get; set; } = new List<DocSpareMovementHistory>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocSpareMovementTable> DocSpareMovementTables { get; set; } = new List<DocSpareMovementTable>();

    [ForeignKey("FromBranchId")]
    [InverseProperty("DocSpareMovementFromBranches")]
    public virtual HlBranch? FromBranch { get; set; }

    [ForeignKey("FromUserId")]
    [InverseProperty("DocSpareMovementFromUsers")]
    public virtual SysUser? FromUser { get; set; }

    [ForeignKey("MovementTypeId")]
    [InverseProperty("DocSpareMovements")]
    public virtual EnumMovementType MovementType { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("DocSpareMovements")]
    public virtual EnumStatus Status { get; set; } = null!;

    [ForeignKey("ToBranchId")]
    [InverseProperty("DocSpareMovementToBranches")]
    public virtual HlBranch? ToBranch { get; set; }

    [ForeignKey("ToUserId")]
    [InverseProperty("DocSpareMovementToUsers")]
    public virtual SysUser? ToUser { get; set; }
}
