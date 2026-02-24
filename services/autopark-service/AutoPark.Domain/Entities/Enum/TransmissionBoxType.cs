using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_transmission_box_type")]
public class TransmissionBoxType : IHaveSoftStateId
{
    public TransmissionBoxType()
    {
        Translates = new HashSet<TransmissionBoxTypeTranslate>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(5)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<TransmissionBoxTypeTranslate> Translates { get; set; } = [];

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    #region Methods
    public void MarkAsActive()
    {
        StateId = StateIdConst.ACTIVE;
    }

    public void MarkAsPassive()
    {
        StateId = StateIdConst.PASSIVE;
    }

    #endregion
}
