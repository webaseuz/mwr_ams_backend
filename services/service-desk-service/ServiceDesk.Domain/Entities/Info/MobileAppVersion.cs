using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Domain;


[Table("info_mobile_app_version")]
public class MobileAppVersion :
    IHaveIdProp<Guid>,
    IHaveSoftStateId,
    IFileEntity
{
    #region Properties

    [Key]
    [Column("id")]
    public Guid Id { get; set; }

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
    public int StateId { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    #endregion

    #region Relationships

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
