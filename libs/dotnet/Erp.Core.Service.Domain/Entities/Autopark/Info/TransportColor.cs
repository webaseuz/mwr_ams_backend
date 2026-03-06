using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_transport_color", Schema = "autopark")]
public class TransportColor :
    BaseEntity<int>
{
    public TransportColor()
    {
        Translates = new HashSet<TransportColorTranslate>();
        TransportModelFiles = new HashSet<TransportModelFile>();
    }

    #region Properties

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
    public DateTime? LastModifiedAt { get; set; }

    [Column("modified_by")]
    public int? LastModifiedBy { get; set; }

    #endregion

    #region Relationships
    [InverseProperty(nameof(TransportColorTranslate.Owner))]
    public virtual ICollection<TransportColorTranslate> Translates { get; set; } = new List<TransportColorTranslate>();
    [InverseProperty(nameof(TransportModelFile.TransportColor))]
    public virtual ICollection<TransportModelFile> TransportModelFiles { get; set; } = new List<TransportModelFile>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    #endregion

}
