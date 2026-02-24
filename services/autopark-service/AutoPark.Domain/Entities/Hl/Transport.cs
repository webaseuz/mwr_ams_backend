using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_transport")]
public class Transport :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public Transport()
    {
        Files = new HashSet<TransportFile>();
        Settings = new HashSet<TransportSetting>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

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
    public DateTime ManufacturedAt { get; set; }

    [Column("purchased_at")]
    public DateTime PurchasedAt { get; set; }

    [Column("state_code")]
    [StringLength(5)]
    public string StateCode { get; set; } = null!;

    [Column("state_number")]
    [StringLength(50)]
    public string StateNumber { get; set; } = null!;

    [Column("vin_number")]
    [StringLength(50)]
    public string VinNumber { get; set; } = null!;

    [Column("purchased_amount", TypeName = "NUMERIC(18,2)")]
    public decimal PurchasedAmount { get; set; }

    [Column("amortization_period")]
    public int AmortizationPeriod { get; set; }

    [Column("qr_code_registry_id")]
    public Guid? QrCodeRegistryId { get; set; }

    [Column("state_id")]
    public int StateId { get; private set; }

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
    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey(nameof(DepartmentId))]
    public virtual Department Department { get; set; }

    [ForeignKey(nameof(QrCodeRegistryId))]
    public virtual QrCodeRegistry QrCodeRegistry { get; set; }

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    [ForeignKey(nameof(TransportBrandId))]
    public virtual TransportBrand TransportBrand { get; set; } = null!;

    [ForeignKey(nameof(TransportColorId))]
    public virtual TransportColor TransportColor { get; set; } = null!;

    [ForeignKey(nameof(TransportModelId))]
    public virtual TransportModel TransportModel { get; set; } = null!;

    [ForeignKey(nameof(TransportUseTypeId))]
    public virtual TransportUseType TransportUseType { get; set; } = null!;

    [InverseProperty(nameof(TransportFile.Owner))]
    public virtual ICollection<TransportFile> Files { get; set; } = new List<TransportFile>();

    [InverseProperty(nameof(TransportSetting.Transport))]
    public virtual ICollection<TransportSetting> Settings { get; set; }

    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;
    #endregion
}
