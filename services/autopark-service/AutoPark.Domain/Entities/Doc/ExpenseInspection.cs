using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_expense_inspection")]
public class ExpenseInspection :
    IHaveIdProp<long>
{
    public ExpenseInspection()
    {
        Files = new HashSet<ExpenseInspectionFile>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("date_on")]
    public DateTime DateOn { get; set; }

    [Column("inspection_type_id")]
    public int InspectionTypeId { get; set; }

    [Column("details")]
    public string Details { get; set; } = null!;

    [Column("price", TypeName = "NUMERIC(18,2)")]
    public decimal Price { get; set; }

    [Column("mile_age", TypeName = "NUMERIC(18,2)")]
    public decimal MileAge { get; set; }

    [Column("invoice_number")]
    [StringLength(50)]
    public string InvoiceNumber { get; set; } = null!;

    [Column("invoice_date_on")]
    public DateTime? InvoiceDateOn { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    #endregion

    #region Relationships
    [ForeignKey(nameof(OwnerId))]
    public virtual Expense Owner { get; set; } = null!;

    [ForeignKey(nameof(InspectionTypeId))]
    public virtual InspectionType InspectionType { get; set; } = null!;

    [InverseProperty(nameof(ExpenseInspectionFile.Owner))]
    public virtual ICollection<ExpenseInspectionFile> Files { get; set; } = new List<ExpenseInspectionFile>();
    #endregion

    #region Methods

    #endregion
}
