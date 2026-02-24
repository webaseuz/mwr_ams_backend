using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("enum_movement_type")]
public partial class EnumMovementType
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

    [InverseProperty("MovementType")]
    public virtual ICollection<DocSpareMovement> DocSpareMovements { get; set; } = new List<DocSpareMovement>();

    [InverseProperty("Owner")]
    public virtual ICollection<EnumMovementTypeTranslate> EnumMovementTypeTranslates { get; set; } = new List<EnumMovementTypeTranslate>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumMovementTypes")]
    public virtual EnumState State { get; set; } = null!;
}
