using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("hl_device")]
public partial class HlDevice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("unique_number")]
    [StringLength(100)]
    public string UniqueNumber { get; set; } = null!;

    [Column("serial_number")]
    [StringLength(100)]
    public string SerialNumber { get; set; } = null!;

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("device_type_id")]
    public int DeviceTypeId { get; set; }

    [Column("device_model_id")]
    public int DeviceModelId { get; set; }

    [Column("manufacturer_id")]
    public long? ManufacturerId { get; set; }

    [Column("service_contractor_id")]
    public long? ServiceContractorId { get; set; }

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

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

    [ForeignKey("BranchId")]
    [InverseProperty("HlDevices")]
    public virtual HlBranch Branch { get; set; } = null!;

    [ForeignKey("DeviceModelId")]
    [InverseProperty("HlDevices")]
    public virtual InfoDeviceModel DeviceModel { get; set; } = null!;

    [ForeignKey("DeviceTypeId")]
    [InverseProperty("HlDevices")]
    public virtual InfoDeviceType DeviceType { get; set; } = null!;

    [InverseProperty("Device")]
    public virtual ICollection<DocServiceApplication> DocServiceApplications { get; set; } = new List<DocServiceApplication>();

    [InverseProperty("Owner")]
    public virtual ICollection<HlDeviceFile> HlDeviceFiles { get; set; } = new List<HlDeviceFile>();

    [ForeignKey("ManufacturerId")]
    [InverseProperty("HlDeviceManufacturers")]
    public virtual InfoContractor? Manufacturer { get; set; }

    [ForeignKey("ResponsiblePersonId")]
    [InverseProperty("HlDevices")]
    public virtual HlPerson ResponsiblePerson { get; set; } = null!;

    [ForeignKey("ServiceContractorId")]
    [InverseProperty("HlDeviceServiceContractors")]
    public virtual InfoContractor? ServiceContractor { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("HlDevices")]
    public virtual EnumState State { get; set; } = null!;
}
