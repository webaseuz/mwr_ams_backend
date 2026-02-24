using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_expense_type")]
public partial class EnumExpenseType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(5)]
    public string? OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("ExpenseType")]
    public virtual ICollection<DocExpense> DocExpenses { get; set; } = new List<DocExpense>();

    [InverseProperty("Owner")]
    public virtual ICollection<EnumExpenseTypeTranslate> EnumExpenseTypeTranslates { get; set; } = new List<EnumExpenseTypeTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumExpenseTypes")]
    public virtual EnumState State { get; set; } = null!;
}
