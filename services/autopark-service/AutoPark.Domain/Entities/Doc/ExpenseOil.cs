using Bms.Core.Domain.Domains;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_expense_oil")]
public class ExpenseOil :
    Entity,
    IHaveIdProp<long>
{
    public ExpenseOil()
    {
        Files = new HashSet<ExpenseOilFile>();
    }
    #region Properties  
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("date_on")]
    public DateTime DateOn { get; set; }

    [Column("oil_type_id")]
    public int OilTypeId { get; set; }

    [Column("oil_model_id")]
    public int OilModelId { get; set; }

    [Column("quantity", TypeName = "NUMERIC(18,2)")]
    public decimal Quantity { get; set; }

    [Column("price", TypeName = "NUMERIC(18,2)")]
    public decimal Price { get; set; }

    [Column("total_price", TypeName = "NUMERIC(18,2)")]
    public decimal TotalPrice { get; set; }

    [Column("mile_age", TypeName = "NUMERIC(18,2)")]
    public decimal MileAge { get; set; }

    [Column("invoice_number")]
    [StringLength(50)]
    public string InvoiceNumber { get; set; } = null!;

    [Column("invoice_date_on")]
    public DateTime? InvoiceDateOn { get; set; }
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

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

    [ForeignKey(nameof(OilTypeId))]
    public virtual OilType OilType { get; set; } = null!;

    [ForeignKey(nameof(OilModelId))]
    public virtual OilModel OilModel { get; set; } = null!;

    [InverseProperty(nameof(ExpenseOilFile.Owner))]
    public virtual ICollection<ExpenseOilFile> Files { get; set; } = new List<ExpenseOilFile>();
    #endregion
}
