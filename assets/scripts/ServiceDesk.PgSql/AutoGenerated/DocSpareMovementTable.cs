using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("doc_spare_movement_table")]
[Index("OwnerId", Name = "indx__doc_sp_mov_tab__ownid")]
public partial class DocSpareMovementTable
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("device_spare_type_id")]
    public int DeviceSpareTypeId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [ForeignKey("DeviceSpareTypeId")]
    [InverseProperty("DocSpareMovementTables")]
    public virtual InfoDeviceSpareType DeviceSpareType { get; set; } = null!;

    [ForeignKey("OwnerId")]
    [InverseProperty("DocSpareMovementTables")]
    public virtual DocSpareMovement Owner { get; set; } = null!;
}
