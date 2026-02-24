using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_transport_type")]
public partial class EnumTransportType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(5)]
    public string? OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<EnumTransportTypeTranslate> EnumTransportTypeTranslates { get; set; } = new List<EnumTransportTypeTranslate>();

    [InverseProperty("TransportType")]
    public virtual ICollection<InfoTransportModel> InfoTransportModels { get; set; } = new List<InfoTransportModel>();

    [InverseProperty("TransportType")]
    public virtual ICollection<InfoTransportUseType> InfoTransportUseTypes { get; set; } = new List<InfoTransportUseType>();
}
