using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_refuel")]
[Index("DriverId", "StatusId", Name = "indx__doc_refuel__drvrid_sttsid")]
[Index("TransportId", "StatusId", Name = "indx__doc_refuel__trid_stid")]
public partial class DocRefuel
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateOnly DocDate { get; set; }

    [Column("fuel_card_id")]
    public int FuelCardId { get; set; }

    [Column("transport_id")]
    public int TransportId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("fuel_type_id")]
    public int FuelTypeId { get; set; }

    [Column("litre")]
    [Precision(18, 2)]
    public decimal Litre { get; set; }

    [Column("cheque_number")]
    [StringLength(50)]
    public string ChequeNumber { get; set; } = null!;

    [Column("address")]
    [StringLength(500)]
    public string Address { get; set; } = null!;

    [Column("message")]
    public string? Message { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<DocRefuelFile> DocRefuelFiles { get; set; } = new List<DocRefuelFile>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocRefuelHistory> DocRefuelHistories { get; set; } = new List<DocRefuelHistory>();

    [ForeignKey("DriverId")]
    [InverseProperty("DocRefuels")]
    public virtual HlDriver Driver { get; set; } = null!;

    [ForeignKey("FuelCardId")]
    [InverseProperty("DocRefuels")]
    public virtual HlFuelCard FuelCard { get; set; } = null!;

    [ForeignKey("FuelTypeId")]
    [InverseProperty("DocRefuels")]
    public virtual InfoFuelType FuelType { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("DocRefuels")]
    public virtual EnumStatus Status { get; set; } = null!;

    [ForeignKey("TransportId")]
    [InverseProperty("DocRefuels")]
    public virtual HlTransport Transport { get; set; } = null!;
}
