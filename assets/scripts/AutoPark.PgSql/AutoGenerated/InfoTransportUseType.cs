using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_transport_use_type")]
public partial class InfoTransportUseType
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

    [Column("transport_type_id")]
    public int TransportTypeId { get; set; }

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

    [InverseProperty("TransportUseType")]
    public virtual ICollection<HlTransport> HlTransports { get; set; } = new List<HlTransport>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoTransportUseTypeTranslate> InfoTransportUseTypeTranslates { get; set; } = new List<InfoTransportUseTypeTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoTransportUseTypes")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("TransportTypeId")]
    [InverseProperty("InfoTransportUseTypes")]
    public virtual EnumTransportType TransportType { get; set; } = null!;
}
