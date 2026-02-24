using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("hl_device")]
public class Device :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public Device()
    {
        Files = new HashSet<DeviceFile>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("unique_number")]
    [StringLength(100)]
    public string UniqueNumber { get; set; } = null!;

    [Column("serial_number")]
    [StringLength(100)]
    public string SerialNumber { get; set; } = null!;

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("device_type_id")]
    public int DeviceTypeId { get; set; }

    [Column("device_model_id")]
    public int DeviceModelId { get; set; }

    [Column("manufacturer_id")]
    public long? ManufacturerId { get; set; }

    [Column("service_contractor_id")]
    public long? ServiceContractorId { get; set; }

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

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

    #endregion

    #region Relationships
    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey(nameof(DeviceModelId))]
    public virtual DeviceModel DeviceModel { get; set; } = null!;

    [ForeignKey(nameof(DeviceTypeId))]
    public virtual DeviceType DeviceType { get; set; } = null!;

    [InverseProperty(nameof(ServiceApplication.Device))]
    public virtual ICollection<ServiceApplication> ServiceApplications { get; set; } = new List<ServiceApplication>();

    [InverseProperty(nameof(DeviceFile.Owner))]
    public virtual ICollection<DeviceFile> Files { get; set; } = new List<DeviceFile>();

    [ForeignKey(nameof(ManufacturerId))]
    public virtual Contractor Manufacturer { get; set; }

    [ForeignKey(nameof(ResponsiblePersonId))]
    public virtual Person ResponsiblePerson { get; set; } = null!;

    [ForeignKey(nameof(ServiceContractorId))]
    public virtual Contractor ServiceContractor { get; set; }

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;

    #endregion
}
