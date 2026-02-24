using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_status_translate")]
public partial class EnumStatusTranslate
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
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("EnumStatusTranslates")]
    public virtual EnumLanguage Language { get; set; } = null!;

    [ForeignKey("OwnerId")]
    [InverseProperty("EnumStatusTranslates")]
    public virtual EnumStatus Owner { get; set; } = null!;
}
