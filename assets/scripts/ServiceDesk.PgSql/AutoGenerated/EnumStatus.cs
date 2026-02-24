using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("enum_status")]
public partial class EnumStatus
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
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<DocMachineReadableCodeSettingHistory> DocMachineReadableCodeSettingHistories { get; set; } = new List<DocMachineReadableCodeSettingHistory>();

    [InverseProperty("Status")]
    public virtual ICollection<DocMachineReadableCodeSetting> DocMachineReadableCodeSettings { get; set; } = new List<DocMachineReadableCodeSetting>();

    [InverseProperty("Status")]
    public virtual ICollection<DocServiceApplicationHistory> DocServiceApplicationHistories { get; set; } = new List<DocServiceApplicationHistory>();

    [InverseProperty("Status")]
    public virtual ICollection<DocServiceApplication> DocServiceApplications { get; set; } = new List<DocServiceApplication>();

    [InverseProperty("Status")]
    public virtual ICollection<DocSpareMovementHistory> DocSpareMovementHistories { get; set; } = new List<DocSpareMovementHistory>();

    [InverseProperty("Status")]
    public virtual ICollection<DocSpareMovement> DocSpareMovements { get; set; } = new List<DocSpareMovement>();

    [InverseProperty("Owner")]
    public virtual ICollection<EnumStatusTranslate> EnumStatusTranslates { get; set; } = new List<EnumStatusTranslate>();
}
