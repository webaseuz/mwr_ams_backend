using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("doc_expense", Schema = "autopark")]
public class Expense : BaseEntity<long>, IAuditTrackEntity
{
    public Expense()
    {
        Files = new HashSet<ExpenseFile>();
        Histories = new HashSet<ExpenseHistory>();
        Batteries = new HashSet<ExpenseBattery>();
        Oils = new HashSet<ExpenseOil>();
        Tires = new HashSet<ExpenseTire>();
        Liquids = new HashSet<ExpenseLiquid>();
        Inspections = new HashSet<ExpenseInspection>();
        Insurances = new HashSet<ExpenseInsurance>();
    }
    #region Properties

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateTime DocDate { get; set; }

    [Column("branch_id")]
    public int? BranchId { get; set; }

    [Column("transport_id")]
    public int TransportId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("contractor_name")]
    [StringLength(250)]
    public string ContractorName { get; set; }

    [Column("message")]
    public string Message { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? LastModifiedAt { get; set; }

    [Column("modified_by")]
    public int? LastModifiedBy { get; set; }
    #endregion

    #region Relationships

    [InverseProperty(nameof(ExpenseFile.Owner))]
    public virtual ICollection<ExpenseFile> Files { get; set; } = new List<ExpenseFile>();

    [InverseProperty(nameof(ExpenseHistory.Owner))]
    public virtual ICollection<ExpenseHistory> Histories { get; set; } = new List<ExpenseHistory>();
    [InverseProperty(nameof(ExpenseBattery.Owner))]
    public virtual ICollection<ExpenseBattery> Batteries { get; set; } = new List<ExpenseBattery>();

    [InverseProperty(nameof(ExpenseLiquid.Owner))]
    public virtual ICollection<ExpenseLiquid> Liquids { get; set; } = new List<ExpenseLiquid>();

    [InverseProperty(nameof(ExpenseOil.Owner))]
    public virtual ICollection<ExpenseOil> Oils { get; set; } = new List<ExpenseOil>();

    [InverseProperty(nameof(ExpenseTire.Owner))]
    public virtual ICollection<ExpenseTire> Tires { get; set; } = new List<ExpenseTire>();

    [InverseProperty(nameof(ExpenseInspection.Owner))]
    public virtual ICollection<ExpenseInspection> Inspections { get; set; } = new List<ExpenseInspection>();

    [InverseProperty(nameof(ExpenseInsurance.Owner))]
    public virtual ICollection<ExpenseInsurance> Insurances { get; set; } = new List<ExpenseInsurance>();

    [ForeignKey(nameof(DriverId))]
    public virtual Driver Driver { get; set; } = null!;

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; } = null!;

    [ForeignKey(nameof(TransportId))]
    public virtual Transport Transport { get; set; } = null!;
    #endregion

    /*  public void AddHistory(Guid fileId, string userInfo)
      {
          Guid historyFileId = Guid.NewGuid();

          Histories.Add(new ExpenseHistory
          {
              OwnerId = Id,
              HistoryFileId = fileId,
              StatusId = StatusId,
              Message = Message,
              UserInfo = userInfo
          });
      }*/
}
