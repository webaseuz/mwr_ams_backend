using AutoPark.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_refuel_history")]
public class RefuelHistory :
    HistoryEntity<long>
{
    #region Relationships
    [ForeignKey(nameof(OwnerId))]
    public virtual Refuel Owner { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; } = null!;
    #endregion

    #region Methods
    #endregion
}
