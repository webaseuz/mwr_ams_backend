using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_driver")]
public partial class HlDriver
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("unique_code")]
    public Guid UniqueCode { get; set; }

    [Column("qr_code_registry_id")]
    public Guid? QrCodeRegistryId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

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

    [ForeignKey("BranchId")]
    [InverseProperty("HlDrivers")]
    public virtual HlBranch Branch { get; set; } = null!;

    [InverseProperty("Driver")]
    public virtual ICollection<DocExpense> DocExpenses { get; set; } = new List<DocExpense>();

    [InverseProperty("Driver")]
    public virtual ICollection<DocRefuel> DocRefuels { get; set; } = new List<DocRefuel>();

    [InverseProperty("Driver")]
    public virtual ICollection<DocTransportSetting> DocTransportSettings { get; set; } = new List<DocTransportSetting>();

    [InverseProperty("Owner")]
    public virtual ICollection<HlDriverDocument> HlDriverDocuments { get; set; } = new List<HlDriverDocument>();

    [InverseProperty("Driver")]
    public virtual ICollection<HlFuelCard> HlFuelCards { get; set; } = new List<HlFuelCard>();

    [ForeignKey("PersonId")]
    [InverseProperty("HlDrivers")]
    public virtual HlPerson Person { get; set; } = null!;

    [ForeignKey("QrCodeRegistryId")]
    [InverseProperty("HlDrivers")]
    public virtual SysQrCodeRegistry? QrCodeRegistry { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("HlDrivers")]
    public virtual EnumState State { get; set; } = null!;
}
