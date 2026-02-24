using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("enum_qr_code_type", Schema = "qr")]
public partial class EnumQrCodeType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

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

    [InverseProperty("CodeType")]
    public virtual ICollection<DocMachineReadableCodeSetting> DocMachineReadableCodeSettings { get; set; } = new List<DocMachineReadableCodeSetting>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumQrCodeTypes")]
    public virtual EnumState State { get; set; } = null!;

    [InverseProperty("QrCodeType")]
    public virtual ICollection<SysQrCodeRegistry> SysQrCodeRegistries { get; set; } = new List<SysQrCodeRegistry>();
}
