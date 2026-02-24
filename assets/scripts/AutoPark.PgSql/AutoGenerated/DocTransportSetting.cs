using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting")]
[Index("TransportId", "StatusId", Name = "indx_doc_tr_sett_trid_stid")]
public partial class DocTransportSetting
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateOnly DocDate { get; set; }

    [Column("transport_id")]
    public int TransportId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("license_number")]
    [StringLength(50)]
    public string LicenseNumber { get; set; } = null!;

    [Column("license_end_at")]
    public DateOnly LicenseEndAt { get; set; }

    [Column("poa_number")]
    [StringLength(50)]
    public string PoaNumber { get; set; } = null!;

    [Column("poa_end_at")]
    public DateOnly PoaEndAt { get; set; }

    [Column("med_cert_number")]
    [StringLength(50)]
    public string MedCertNumber { get; set; } = null!;

    [Column("med_cert_end_at")]
    public DateOnly MedCertEndAt { get; set; }

    [Column("manager_full_name")]
    [StringLength(250)]
    public string? ManagerFullName { get; set; }

    [Column("load_capacity")]
    [Precision(18, 2)]
    public decimal LoadCapacity { get; set; }

    [Column("seat_count")]
    public int SeatCount { get; set; }

    [Column("odometr_indicator")]
    [Precision(18, 2)]
    public decimal OdometrIndicator { get; set; }

    [Column("fuel_card_number")]
    [StringLength(50)]
    public string FuelCardNumber { get; set; } = null!;

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

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
    public virtual ICollection<DocTransportSettingBattery> DocTransportSettingBatteries { get; set; } = new List<DocTransportSettingBattery>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocTransportSettingFile> DocTransportSettingFiles { get; set; } = new List<DocTransportSettingFile>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocTransportSettingFuel> DocTransportSettingFuels { get; set; } = new List<DocTransportSettingFuel>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocTransportSettingInspection> DocTransportSettingInspections { get; set; } = new List<DocTransportSettingInspection>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocTransportSettingInsurance> DocTransportSettingInsurances { get; set; } = new List<DocTransportSettingInsurance>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocTransportSettingLiquid> DocTransportSettingLiquids { get; set; } = new List<DocTransportSettingLiquid>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocTransportSettingOil> DocTransportSettingOils { get; set; } = new List<DocTransportSettingOil>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocTransportSettingTire> DocTransportSettingTires { get; set; } = new List<DocTransportSettingTire>();

    [ForeignKey("DriverId")]
    [InverseProperty("DocTransportSettings")]
    public virtual HlDriver Driver { get; set; } = null!;

    [ForeignKey("ResponsiblePersonId")]
    [InverseProperty("DocTransportSettings")]
    public virtual HlPerson ResponsiblePerson { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("DocTransportSettings")]
    public virtual EnumStatus Status { get; set; } = null!;

    [ForeignKey("TransportId")]
    [InverseProperty("DocTransportSettings")]
    public virtual HlTransport Transport { get; set; } = null!;
}
