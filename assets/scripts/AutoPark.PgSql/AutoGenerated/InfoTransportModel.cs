using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_transport_model")]
public partial class InfoTransportModel
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

    [Column("seat_count")]
    public int SeatCount { get; set; }

    [Column("load_capacity")]
    [Precision(18, 2)]
    public decimal LoadCapacity { get; set; }

    [Column("transmission_box_type_id")]
    public int TransmissionBoxTypeId { get; set; }

    [InverseProperty("TransportModel")]
    public virtual ICollection<HlTransport> HlTransports { get; set; } = new List<HlTransport>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoTransportModelTranslate> InfoTransportModelTranslates { get; set; } = new List<InfoTransportModelTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoTransportModels")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("TransportTypeId")]
    [InverseProperty("InfoTransportModels")]
    public virtual EnumTransportType TransportType { get; set; } = null!;
}
