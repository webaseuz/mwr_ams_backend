using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("info_device_spare_type")]
public class DeviceSpareType :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public DeviceSpareType()
    {
        Translates = new HashSet<DeviceSpareTypeTranslate>();
		//ServiceApplicationSpares = new HashSet<ServiceApplicationSpare>

	}
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("nomenclature")]
    [StringLength(100)]
    public string Nomenclature { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("device_type_id")]
    public int DeviceTypeId { get; set; }

    [Column("device_part_id")]
    public int DevicePartId { get; set; }

    [Column("device_model_id")]
    public int? DeviceModelId { get; set; }

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
	[ForeignKey(nameof(DeviceModelId))]
    public virtual DeviceModel DeviceModel { get; set; }

    [ForeignKey(nameof(DevicePartId))]
    public virtual DevicePart DevicePart { get; set; } = null!;

    [ForeignKey(nameof(DeviceTypeId))]
    public virtual DeviceType DeviceType { get; set; } = null!;

    //[InverseProperty(nameof(ServiceApplicationSpare.DeviceSpareType))]
    //public virtual ICollection<ServiceApplicationSpare> ServiceApplicationSpares { get; set; } = new List<ServiceApplicationSpare>();

    [InverseProperty(nameof(DeviceSpareTypeTranslate.Owner))]
    public virtual ICollection<DeviceSpareTypeTranslate> Translates { get; set; } = new List<DeviceSpareTypeTranslate>();

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
