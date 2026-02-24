using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_gender_translate")]
public partial class EnumGenderTranslate
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
    [InverseProperty("EnumGenderTranslates")]
    public virtual EnumLanguage Language { get; set; } = null!;

    [ForeignKey("OwnerId")]
    [InverseProperty("EnumGenderTranslates")]
    public virtual EnumGender Owner { get; set; } = null!;
}
