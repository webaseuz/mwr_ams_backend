using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("enum_executor_type")]
public partial class EnumExecutorType
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

    [InverseProperty("ExecutorType")]
    public virtual ICollection<DocServiceApplication> DocServiceApplications { get; set; } = new List<DocServiceApplication>();

    [InverseProperty("Owner")]
    public virtual ICollection<EnumExecutorTypeTranslate> EnumExecutorTypeTranslates { get; set; } = new List<EnumExecutorTypeTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumExecutorTypes")]
    public virtual EnumState State { get; set; } = null!;
}
