using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain.Entities;

public class HistoryEntity<TId> :
    IHaveIdProp<TId>
{
    [Key]
    [Column("id")]
    public TId Id { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }
    [Column("owner_id")]
    public TId OwnerId { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("message")]
    public string Message { get; set; }

    [Column("user_info")]
    public string UserInfo { get; set; } = null!;

    [Column("data_json", TypeName = "jsonb")]
    public string DataJson { get; set; }

    [Column("history_file_id")]
    public Guid HistoryFileId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }
}
