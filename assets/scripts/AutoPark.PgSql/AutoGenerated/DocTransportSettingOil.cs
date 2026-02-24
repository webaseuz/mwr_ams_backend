using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting_oil")]
[Index("OwnerId", Name = "indx_doc_transport_setting_oil_own_id")]
public partial class DocTransportSettingOil
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("oil_type_id")]
    public int OilTypeId { get; set; }

    [Column("tank_volume")]
    [Precision(18, 2)]
    public decimal TankVolume { get; set; }

    [Column("monthly_limit")]
    [Precision(18, 2)]
    public decimal MonthlyLimit { get; set; }

    [Column("remaining")]
    [Precision(18, 2)]
    public decimal Remaining { get; set; }

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

    [ForeignKey("OilTypeId")]
    [InverseProperty("DocTransportSettingOils")]
    public virtual InfoOilType OilType { get; set; } = null!;

    [ForeignKey("OwnerId")]
    [InverseProperty("DocTransportSettingOils")]
    public virtual DocTransportSetting Owner { get; set; } = null!;
}
