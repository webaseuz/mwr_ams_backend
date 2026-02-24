using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_expense")]
[Index("DriverId", "StatusId", Name = "indx__doc_expense__drvrid_sttsid")]
[Index("TransportId", "StatusId", Name = "indx__doc_expense__trid_stid")]
public partial class DocExpense
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateOnly DocDate { get; set; }

    [Column("transport_id")]
    public int TransportId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("expense_type_id")]
    public int ExpenseTypeId { get; set; }

    [Column("price")]
    [Precision(18, 5)]
    public decimal Price { get; set; }

    [Column("contractor_id")]
    public long? ContractorId { get; set; }

    [Column("contractor_name")]
    [StringLength(250)]
    public string? ContractorName { get; set; }

    [Column("message")]
    public string? Message { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [ForeignKey("ContractorId")]
    [InverseProperty("DocExpenses")]
    public virtual InfoContractor? Contractor { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<DocExpenseFile> DocExpenseFiles { get; set; } = new List<DocExpenseFile>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocExpenseHistory> DocExpenseHistories { get; set; } = new List<DocExpenseHistory>();

    [ForeignKey("DriverId")]
    [InverseProperty("DocExpenses")]
    public virtual HlDriver Driver { get; set; } = null!;

    [ForeignKey("ExpenseTypeId")]
    [InverseProperty("DocExpenses")]
    public virtual EnumExpenseType ExpenseType { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("DocExpenses")]
    public virtual EnumStatus Status { get; set; } = null!;

    [ForeignKey("TransportId")]
    [InverseProperty("DocExpenses")]
    public virtual HlTransport Transport { get; set; } = null!;
}
