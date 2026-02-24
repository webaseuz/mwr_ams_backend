using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("doc_spare_movement_history")]
[Index("OwnerId", Name = "indx__doc_sp_mov__his__ownid")]
public partial class DocSpareMovementHistory
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("message")]
    [StringLength(1000)]
    public string? Message { get; set; }

    [Column("user_info")]
    [StringLength(1000)]
    public string UserInfo { get; set; } = null!;

    [Column("data_json", TypeName = "jsonb")]
    public string? DataJson { get; set; }

    [Column("history_file_id")]
    public Guid HistoryFileId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [ForeignKey("OwnerId")]
    [InverseProperty("DocSpareMovementHistories")]
    public virtual DocSpareMovement Owner { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("DocSpareMovementHistories")]
    public virtual EnumStatus Status { get; set; } = null!;
}
