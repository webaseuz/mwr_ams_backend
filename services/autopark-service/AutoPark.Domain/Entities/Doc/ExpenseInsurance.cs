using AutoPark.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("doc_expense_insurance")]
public class ExpenseInsurance :
    IHaveIdProp<long>
{
    public ExpenseInsurance()
    {
        Files = new HashSet<ExpenseInsuranceFile>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("insurance_type_id")]
    public int InsuranceTypeId { get; set; }

    [Column("ins_number")]
    [StringLength(50)]
    public string InsNumber { get; set; } = null!;

    [Column("date_on")]
    public DateTime DateOn { get; set; }

    [Column("contractor_id")]
    public long ContractorId { get; set; }

    [Column("price", TypeName = "NUMERIC(18,2)")]
    public decimal Price { get; set; }

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
    [ForeignKey(nameof(ContractorId))]
    public virtual Contractor Contractor { get; set; } = null!;

    [ForeignKey(nameof(InsuranceTypeId))]
    public virtual InsuranceType InsuranceType { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual Expense Owner { get; set; } = null!;

    [InverseProperty(nameof(ExpenseInsuranceFile.Owner))]
    public virtual ICollection<ExpenseInsuranceFile> Files { get; set; } = new List<ExpenseInsuranceFile>();
    #endregion

    #region Methods
    #endregion
}
