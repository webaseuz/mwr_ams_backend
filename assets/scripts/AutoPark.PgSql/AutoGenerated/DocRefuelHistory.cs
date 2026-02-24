using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_refuel_history")]
[Index("OwnerId", Name = "indx__doc_refuel_his__ownid")]
public partial class DocRefuelHistory
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
    public string DataJson { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [ForeignKey("OwnerId")]
    [InverseProperty("DocRefuelHistories")]
    public virtual DocRefuel Owner { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("DocRefuelHistories")]
    public virtual EnumStatus Status { get; set; } = null!;
}
