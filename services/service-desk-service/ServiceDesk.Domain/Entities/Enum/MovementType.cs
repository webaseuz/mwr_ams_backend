using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("enum_movement_type")]
public class MovementType :
	IHaveIdProp<int>,
	IHaveSoftStateId
{
    public MovementType()
    {
        Translates = new HashSet<MovementTypeTranslate>();
        SpareMovements = new HashSet<SpareMovement>();
    }
	#region Properties
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
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }
	#endregion

	#region Relationships
	[InverseProperty(nameof(SpareMovement.MovementType))]
    public virtual ICollection<SpareMovement> SpareMovements { get; set; } = new List<SpareMovement>();

    [InverseProperty(nameof(MovementTypeTranslate.Owner))]
    public virtual ICollection<MovementTypeTranslate> Translates { get; set; } = new List<MovementTypeTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;
	#endregion

	#region Methods
	public void MarkAsActive()
		=> StateId = StateIdConst.ACTIVE;

	public void MarkAsPassive()
		=> StateId = StateIdConst.PASSIVE;

	#endregion
}
