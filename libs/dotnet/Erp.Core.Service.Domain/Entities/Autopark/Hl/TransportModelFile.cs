using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_transport_model_file", Schema = "autopark")]
public class TransportModelFile :
    BaseEntity<Guid>
{
    #region Properties

    [Column("file_name")]
    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [Column("transport_model_id")]
    public int TransportModelId { get; set; }

    [Column("transport_color_id")]
    public int TransportColorId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; } = false;

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
    [ForeignKey(nameof(TransportModelId))]
    public virtual TransportModel TransportModel { get; set; } = null!;

    [ForeignKey(nameof(TransportColorId))]
    public virtual TransportColor TransportColor { get; set; } = null!;
    #endregion

}
