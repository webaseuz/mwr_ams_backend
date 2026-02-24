using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_expense_history")]
[Index("OwnerId", Name = "indx__doc_expns_his__ownid")]
public partial class DocExpenseHistory
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
    [InverseProperty("DocExpenseHistories")]
    public virtual DocExpense Owner { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("DocExpenseHistories")]
    public virtual EnumStatus Status { get; set; } = null!;
}
