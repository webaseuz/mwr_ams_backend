using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("info_device_model")]
public class DeviceModel :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public DeviceModel()
    {
        Translates = new HashSet<DeviceModelTranslate>();
        DeviceSpareTypes = new HashSet<DeviceSpareType>();
        Devices = new HashSet<Device>();

	}
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("device_type_id")]
    public int DeviceTypeId { get; set; }

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

	[ForeignKey(nameof(DeviceTypeId))]
    public virtual DeviceType DeviceType { get; set; } = null!;

    [InverseProperty(nameof(Device.DeviceModel))]
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    [InverseProperty(nameof(DeviceModelTranslate.Owner))]
    public virtual ICollection<DeviceModelTranslate> Translates { get; set; } = new List<DeviceModelTranslate>();

    [InverseProperty(nameof(DeviceSpareType.DeviceModel))]
    public virtual ICollection<DeviceSpareType> DeviceSpareTypes { get; set; } = new List<DeviceSpareType>();

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
