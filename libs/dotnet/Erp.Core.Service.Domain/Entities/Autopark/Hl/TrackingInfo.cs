using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_tracking_info", Schema = "autopark")]
public class TrackingInfo :
    BaseEntity<long>
{
    #region Properties
    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("latitude", TypeName = "numeric(18,6)")]
    public decimal Latitude { get; set; }

    [Column("longitude", TypeName = "numeric(18,6)")]
    public decimal Longitude { get; set; }

    [Column("date_at", TypeName = "timestamp without time zone")]
    public DateTime DateAt { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("created_by")]
    public int? CreatedBy { get; set; }
    #endregion

    #region Relationships
    [ForeignKey(nameof(PersonId))]
    public virtual Person Person { get; set; } = null!;
    #endregion
}
