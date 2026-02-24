using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("info_device_model_translate")]
public partial class InfoDeviceModelTranslate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("column_name")]
    [StringLength(100)]
    public string ColumnName { get; set; } = null!;

    [Column("translate_text")]
    public string TranslateText { get; set; } = null!;

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

    [ForeignKey("LanguageId")]
    [InverseProperty("InfoDeviceModelTranslates")]
    public virtual EnumLanguage Language { get; set; } = null!;

    [ForeignKey("OwnerId")]
    [InverseProperty("InfoDeviceModelTranslates")]
    public virtual InfoDeviceModel Owner { get; set; } = null!;
}
