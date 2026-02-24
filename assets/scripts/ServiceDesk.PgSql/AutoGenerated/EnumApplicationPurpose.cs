using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("enum_application_purpose")]
public partial class EnumApplicationPurpose
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

    [InverseProperty("ApplicationPurpose")]
    public virtual ICollection<DocServiceApplicationPart> DocServiceApplicationParts { get; set; } = new List<DocServiceApplicationPart>();

    [InverseProperty("Owner")]
    public virtual ICollection<EnumApplicationPurposeTranslate> EnumApplicationPurposeTranslates { get; set; } = new List<EnumApplicationPurposeTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumApplicationPurposes")]
    public virtual EnumState State { get; set; } = null!;
}
