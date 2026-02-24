using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("info_application_purpose")]
public class ApplicationPurpose :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public ApplicationPurpose()
    {
        Translates = new HashSet<ApplicationPurposeTranslate>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(5)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("device_type_id")]
    public int DeviceTypeId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }
    #endregion

    #region Relationships
    [ForeignKey(nameof(DeviceTypeId))]
    public virtual DeviceType DeviceType { get; set; } = null!;

    [InverseProperty(nameof(ApplicationPurposeTranslate.Owner))]
    public virtual ICollection<ApplicationPurposeTranslate> Translates { get; set; } = new List<ApplicationPurposeTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; }
    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;
    #endregion
}
