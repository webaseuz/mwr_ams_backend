using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("acc_present_spare_turnover")]
[Index("BranchId", "DeviceSpareTypeId", Name = "indx__acc_pre_spare_turnover__brid_dev_sp_typid")]
public partial class AccPresentSpareTurnover
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("last_spare_turnover_id")]
    public Guid LastSpareTurnoverId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("device_spare_type_id")]
    public int DeviceSpareTypeId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

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
    [InverseProperty("AccPresentSpareTurnovers")]
    public virtual HlBranch Branch { get; set; } = null!;

    [ForeignKey("DeviceSpareTypeId")]
    [InverseProperty("AccPresentSpareTurnovers")]
    public virtual InfoDeviceSpareType DeviceSpareType { get; set; } = null!;

    [ForeignKey("LastSpareTurnoverId")]
    [InverseProperty("AccPresentSpareTurnovers")]
    public virtual AccSpareTurnover LastSpareTurnover { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("AccPresentSpareTurnovers")]
    public virtual SysUser? User { get; set; }
}
