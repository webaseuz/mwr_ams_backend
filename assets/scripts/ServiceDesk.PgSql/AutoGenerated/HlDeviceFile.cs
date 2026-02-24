using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("hl_device_file")]
[Index("OwnerId", Name = "indx__hl_device_fil__ownid")]
public partial class HlDeviceFile
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("file_name")]
    [StringLength(250)]
    public string FileName { get; set; } = null!;

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

    [ForeignKey("OwnerId")]
    [InverseProperty("HlDeviceFiles")]
    public virtual HlDevice Owner { get; set; } = null!;
}
