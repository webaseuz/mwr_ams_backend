using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_gender")]
public class Gender :
    IHaveIdProp<int>
{
    public Gender()
    {
        Translates = new HashSet<GenderTranslate>();
    }

    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;
    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    #endregion

    #region Relationships
    [InverseProperty(nameof(GenderTranslate.Owner))]
    public virtual ICollection<GenderTranslate> Translates { get; set; } = new List<GenderTranslate>();

    #endregion

    #region Methods
    #endregion
}
