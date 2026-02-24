using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("enum_qr_code_type", Schema = "qr")]
public class QrCodeType :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("state_id")]
    public int StateId { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

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
