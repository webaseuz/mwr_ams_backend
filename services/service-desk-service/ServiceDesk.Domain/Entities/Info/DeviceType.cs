using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("info_device_type")]
public class DeviceType :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public DeviceType()
    {
        Devices = new HashSet<Device>();
        Translates = new HashSet<DeviceTypeTranslate>();
        DeviceModels = new HashSet<DeviceModel>();
        DeviceParts = new HashSet<DevicePart>();
        DeviceSpareTypes = new HashSet<DeviceSpareType>();
        ServiceTypes = new HashSet<ServiceType>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    //[Column("base_device_type_id")]
    //public int BaseDeviceTypeId { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

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
	//[ForeignKey(nameof(BaseDeviceTypeId))]
 //   public virtual BaseDeviceType BaseDeviceType { get; set; } = null!;

	[InverseProperty(nameof(Device.DeviceType))]
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

	[InverseProperty(nameof(DeviceModel.DeviceType))]
    public virtual ICollection<DeviceModel> DeviceModels { get; set; } = new List<DeviceModel>();

    [InverseProperty(nameof(DevicePart.DeviceType))]
    public virtual ICollection<DevicePart> DeviceParts { get; set; } = new List<DevicePart>();

    [InverseProperty(nameof(DeviceSpareType.DeviceType))]
    public virtual ICollection<DeviceSpareType> DeviceSpareTypes { get; set; } = new List<DeviceSpareType>();

    [InverseProperty(nameof(DeviceTypeTranslate.Owner))]
    public virtual ICollection<DeviceTypeTranslate> Translates { get; set; } = new List<DeviceTypeTranslate>();

    [InverseProperty(nameof(ServiceType.DeviceType))]
    public virtual ICollection<ServiceType> ServiceTypes { get; set; } = new List<ServiceType>();

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
