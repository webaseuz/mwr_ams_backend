using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bms.WEBASE.Models;

namespace ServiceDesk.Domain;

[Table("doc_service_application_history")]
public class ServiceApplicationHistory :
    IHaveIdProp<long>
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
    public string Message { get; set; }

    [Column("user_info")]
    [StringLength(1000)]
    public string UserInfo { get; set; } = null!;

    [Column("data_json", TypeName = "jsonb")]
    public string DataJson { get; set; }

    [Column("history_file_id")]
    public Guid HistoryFileId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public virtual ServiceApplication Owner { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; } = null!;
}
