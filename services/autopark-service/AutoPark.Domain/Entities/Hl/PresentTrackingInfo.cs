using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_present_tracking_info")]
public class PresentTrackingInfo :
    IHaveIdProp<long>
{
    #region Properties
    [Key]
    [Column("id")]
    public long Id { get; set; }

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
