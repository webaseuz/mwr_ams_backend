using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("enum_base_device_type")]
public class BaseDeviceType :
    IHaveIdProp<int>
{
    public BaseDeviceType()
    {
        //DeviceTypes = new HashSet<DeviceType>();
        Translates = new HashSet<BaseDeviceTypeTranslate>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }
    #endregion

    #region Relationships
    [InverseProperty(nameof(BaseDeviceTypeTranslate.Owner))]
    public virtual ICollection<BaseDeviceTypeTranslate> Translates { get; set; } = new List<BaseDeviceTypeTranslate>();

    //[InverseProperty(nameof(DeviceType.BaseDeviceType))]
    //public virtual ICollection<DeviceType> DeviceTypes { get; set; } = new List<DeviceType>();
    #endregion
}
