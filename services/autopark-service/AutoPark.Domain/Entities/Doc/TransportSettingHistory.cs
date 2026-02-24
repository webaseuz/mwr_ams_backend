using AutoPark.Domain.Entities;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting_history")]
public class TransportSettingHistory
    : HistoryEntity<long>,
    IHaveIdProp<long>
{
    #region Properties
    /*
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("message")]
    [StringLength(1000)]
    public string Message { get; set; }

    [Column("user_info")]
    [StringLength(1000)]
    public string UserInfo { get; set; } = null!;

    [Column("data_json", TypeName = "jsonb")]
    public string DataJson { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }
    */
    #endregion

    #region
    [ForeignKey(nameof(OwnerId))]
    public virtual TransportSetting Owner { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; } = null!;

    #endregion

    #region Methods

    #endregion
}
