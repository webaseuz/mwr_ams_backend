using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Erp.Core.Service.Domain.Entities;

namespace Erp.Core.Service.Domain;

[Table("doc_refuel_history")]
public class RefuelHistory :
    BaseEntity<long>
{
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
    [Column("owner_id")]
    public long OwnerId { get; set; }

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

    #region Relationships
    [ForeignKey(nameof(OwnerId))]
    public virtual Refuel Owner { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; } = null!;
    #endregion

}
