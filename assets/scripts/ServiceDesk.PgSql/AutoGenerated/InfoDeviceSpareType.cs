using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("info_device_spare_type")]
[Index("DeviceTypeId", Name = "indx__info_dev_spr_typ__dev_ty_id")]
public partial class InfoDeviceSpareType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

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

    [InverseProperty("DeviceSpareType")]
    public virtual ICollection<AccPresentSpareTurnover> AccPresentSpareTurnovers { get; set; } = new List<AccPresentSpareTurnover>();

    [InverseProperty("DeviceSpareType")]
    public virtual ICollection<AccSpareTurnover> AccSpareTurnovers { get; set; } = new List<AccSpareTurnover>();

    [ForeignKey("DeviceModelId")]
    [InverseProperty("InfoDeviceSpareTypes")]
    public virtual InfoDeviceModel? DeviceModel { get; set; }

    [ForeignKey("DevicePartId")]
    [InverseProperty("InfoDeviceSpareTypes")]
    public virtual InfoDevicePart DevicePart { get; set; } = null!;

    [ForeignKey("DeviceTypeId")]
    [InverseProperty("InfoDeviceSpareTypes")]
    public virtual InfoDeviceType DeviceType { get; set; } = null!;

    [InverseProperty("DeviceSpareType")]
    public virtual ICollection<DocServiceApplicationSpare> DocServiceApplicationSpares { get; set; } = new List<DocServiceApplicationSpare>();

    [InverseProperty("DeviceSpareType")]
    public virtual ICollection<DocSpareMovementTable> DocSpareMovementTables { get; set; } = new List<DocSpareMovementTable>();

    [InverseProperty("Owner")]
    public virtual ICollection<InfoDeviceSpareTypeTranslate> InfoDeviceSpareTypeTranslates { get; set; } = new List<InfoDeviceSpareTypeTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoDeviceSpareTypes")]
    public virtual EnumState State { get; set; } = null!;
}
