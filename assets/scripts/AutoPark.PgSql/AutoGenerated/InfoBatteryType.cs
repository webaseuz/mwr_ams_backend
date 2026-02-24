using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_battery_type")]
public partial class InfoBatteryType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

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

    [InverseProperty("BatteryType")]
    public virtual ICollection<DocTransportSettingBattery> DocTransportSettingBatteries { get; set; } = new List<DocTransportSettingBattery>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoBatteryTypeTranslate> InfoBatteryTypeTranslates { get; set; } = new List<InfoBatteryTypeTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoBatteryTypes")]
    public virtual EnumState State { get; set; } = null!;
}
