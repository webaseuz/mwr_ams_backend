using ServiceDesk.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("doc_spare_movement_history")]
public class SpareMovementHistory :
    HistoryEntity<long>
{
	#region Properties
	
	#endregion

	#region Relationships
	[ForeignKey(nameof(OwnerId))]
    public virtual SpareMovement Owner { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; } = null!;
	#endregion
}
