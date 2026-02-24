using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_gender")]
public partial class EnumGender
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
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<EnumGenderTranslate> EnumGenderTranslates { get; set; } = new List<EnumGenderTranslate>();

    [InverseProperty("Gender")]
    public virtual ICollection<HlPerson> HlPeople { get; set; } = new List<HlPerson>();
}
