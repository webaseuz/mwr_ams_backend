using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_mobile_app_version")]
public class MobileAppVersion :
    BaseEntity<Guid>
{
    #region Properties

    [Column("file_name")]
    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [Column("version_code")]
    [StringLength(50)]
    public string VersionCode { get; set; } = null!;

    [Column("details")]
    [StringLength(1000)]
    public string Details { get; set; } = null!;

    [Column("release_at", TypeName = "timestamp without time zone")]
    public DateTime ReleaseAt { get; set; }

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

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    #endregion

}
