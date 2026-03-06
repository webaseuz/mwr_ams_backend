using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_tire_size", Schema = "autopark")]
public class TireSize :
    BaseEntity<int>
{

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("width")]
    public decimal Width { get; set; }

    [Column("height")]
    public decimal Height { get; set; }

    [Column("radius")]
    public decimal Radius { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? LastModifiedAt { get; set; }

    [Column("modified_by")]
    public int? LastModifiedBy { get; set; }

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;
}
