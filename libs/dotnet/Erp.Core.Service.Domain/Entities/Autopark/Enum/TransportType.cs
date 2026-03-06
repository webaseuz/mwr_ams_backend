using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_transport_type", Schema = "autopark")]
public class TransportType :
    BaseEntity<int>
{
    public TransportType()
    {
        Translates = new HashSet<TransportTypeTranslate>();
    }

    #region Properties

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

    #region Reltionships
    [InverseProperty(nameof(TransportTypeTranslate.Owner))]
    public virtual ICollection<TransportTypeTranslate> Translates { get; set; } = new List<TransportTypeTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    #endregion
}
