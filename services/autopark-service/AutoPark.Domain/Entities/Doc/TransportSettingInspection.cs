using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting_inspection")]
public class TransportSettingInspection :
    IHaveIdProp<long>
{
    #region Properties
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("date_at")]
    public DateTime DateAt { get; set; }

    [Column("expire_at")]
    public DateTime ExpireAt { get; set; }

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

    [Column("details")]
    public string Details { get; set; }

    [Column("notify_before_day")]
    public int NotifyBeforeDay { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

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
    [ForeignKey(nameof(OwnerId))]
    public virtual TransportSetting Owner { get; set; } = null!;

    [ForeignKey(nameof(ResponsiblePersonId))]
    public virtual Person ResponsiblePerson { get; set; } = null!;

    #endregion

    #region Methods

    #endregion
}
