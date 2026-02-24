using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_transport")]
[Index("IsDeleted", "StateId", "BranchId", Name = "indx__hl_trprt_isdel_stid_brid")]
public partial class HlTransport
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("unique_code")]
    public Guid UniqueCode { get; set; }

    [Column("transport_model_id")]
    public int TransportModelId { get; set; }

    [Column("transport_use_type_id")]
    public int TransportUseTypeId { get; set; }

    [Column("transport_brand_id")]
    public int TransportBrandId { get; set; }

    [Column("transport_color_id")]
    public int TransportColorId { get; set; }

    [Column("manufactured_at")]
    public DateOnly ManufacturedAt { get; set; }

    [Column("purchased_at")]
    public DateOnly PurchasedAt { get; set; }

    [Column("state_code")]
    [StringLength(5)]
    public string StateCode { get; set; } = null!;

    [Column("state_number")]
    [StringLength(50)]
    public string StateNumber { get; set; } = null!;

    [Column("purchased_amount")]
    [Precision(18, 2)]
    public decimal PurchasedAmount { get; set; }

    [Column("amortization_period")]
    public int AmortizationPeriod { get; set; }

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
    [InverseProperty("HlTransports")]
    public virtual HlBranch Branch { get; set; } = null!;

    [ForeignKey("DepartmentId")]
    [InverseProperty("HlTransports")]
    public virtual HlDepartment? Department { get; set; }

    [InverseProperty("Transport")]
    public virtual ICollection<DocExpense> DocExpenses { get; set; } = new List<DocExpense>();

    [InverseProperty("Transport")]
    public virtual ICollection<DocRefuel> DocRefuels { get; set; } = new List<DocRefuel>();

    [InverseProperty("Transport")]
    public virtual ICollection<DocTransportSetting> DocTransportSettings { get; set; } = new List<DocTransportSetting>();

    [InverseProperty("Transport")]
    public virtual ICollection<HlFuelCard> HlFuelCards { get; set; } = new List<HlFuelCard>();

    [ForeignKey("QrCodeRegistryId")]
    [InverseProperty("HlTransports")]
    public virtual SysQrCodeRegistry? QrCodeRegistry { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("HlTransports")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("TransportBrandId")]
    [InverseProperty("HlTransports")]
    public virtual InfoTransportBrand TransportBrand { get; set; } = null!;

    [ForeignKey("TransportColorId")]
    [InverseProperty("HlTransports")]
    public virtual InfoTransportColor TransportColor { get; set; } = null!;

    [ForeignKey("TransportModelId")]
    [InverseProperty("HlTransports")]
    public virtual InfoTransportModel TransportModel { get; set; } = null!;

    [ForeignKey("TransportUseTypeId")]
    [InverseProperty("HlTransports")]
    public virtual InfoTransportUseType TransportUseType { get; set; } = null!;
}
