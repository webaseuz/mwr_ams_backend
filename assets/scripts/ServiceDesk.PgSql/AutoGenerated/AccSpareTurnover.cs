using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("acc_spare_turnover")]
[Index("BranchId", "DeviceSpareTypeId", Name = "indx__acc_spare_turnover__brid_dev_sp_typid")]
public partial class AccSpareTurnover
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateTime DocDate { get; set; }

    [Column("table_id")]
    public int TableId { get; set; }

    [Column("document_id")]
    public long DocumentId { get; set; }

    [Column("document_table_id")]
    public long? DocumentTableId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("device_spare_type_id")]
    public int DeviceSpareTypeId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("is_debit")]
    public bool IsDebit { get; set; }

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

    [InverseProperty("LastSpareTurnover")]
    public virtual ICollection<AccPresentSpareTurnover> AccPresentSpareTurnovers { get; set; } = new List<AccPresentSpareTurnover>();

    [ForeignKey("BranchId")]
    [InverseProperty("AccSpareTurnovers")]
    public virtual HlBranch Branch { get; set; } = null!;

    [ForeignKey("DeviceSpareTypeId")]
    [InverseProperty("AccSpareTurnovers")]
    public virtual InfoDeviceSpareType DeviceSpareType { get; set; } = null!;

    [ForeignKey("TableId")]
    [InverseProperty("AccSpareTurnovers")]
    public virtual SysTable Table { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("AccSpareTurnovers")]
    public virtual SysUser? User { get; set; }
}
