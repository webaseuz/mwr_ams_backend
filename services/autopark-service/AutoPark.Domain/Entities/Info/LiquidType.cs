using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_liquid_type")]
public class LiquidType :
     IHaveIdProp<int>,
    IHaveSoftStateId
{
    public LiquidType()
    {
        Translates = new HashSet<LiquidTypeTranslate>();
    }

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
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [InverseProperty(nameof(LiquidTypeTranslate.Owner))]
    public virtual ICollection<LiquidTypeTranslate> Translates { get; set; } = new List<LiquidTypeTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    public void MarkAsActive()
    {
        StateId = StateIdConst.ACTIVE;
    }

    public void MarkAsPassive()
    {
        StateId = StateIdConst.PASSIVE;
    }
}
