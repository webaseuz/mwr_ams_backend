using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Erp.Core.Service.Domain;

[Table("sys_row_change_log", Schema = "adm")]
[Index(nameof(TableId), nameof(RowId), Name = "ix_sys_row_change_log__table_row")]
public class RowChangeLog : BaseEntity<long>
{
    [Column("date_at", TypeName = "timestamp without time zone")]
    public DateTime DateAt { get; set; } = DateTime.UtcNow;

    [Column("user_id")]
    public int UserId { get; set; }

    [Required]
    [Column("user_info", TypeName = "text")]
    public string UserInfo { get; set; }

    [Column("table_id")]
    public int TableId { get; set; }

    [Column("row_id")]
    public long RowId { get; set; }

    [Column("ip_address")]
    [StringLength(50)]
    public string IpAddress { get; set; }

    [Column("user_agent")]
    [StringLength(250)]
    public string UserAgent { get; set; }

    [Column("message")]
    [StringLength(500)]
    public string Message { get; set; }

    [Column("organization_id")]
    public int? OrganizationId { get; set; }

    [Column("request_trace_id")]
    [StringLength(50)]
    public string RequestTraceId { get; set; }

    [ForeignKey(nameof(TableId))]
    public virtual Table Table { get; set; }

    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization Organization { get; set; }
}
