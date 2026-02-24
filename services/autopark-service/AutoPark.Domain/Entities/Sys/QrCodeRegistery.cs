using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("sys_qr_code_registry", Schema = "qr")]
public class QrCodeRegistry :
    IHaveIdProp<Guid>
{
    #region Properties
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("unique_key")]
    [StringLength(50)]
    public string UniqueKey { get; set; } = null!;

    [Column("qr_code_type_id")]
    public int QrCodeTypeId { get; set; }

    [Column("qr_code_version")]
    public int QrCodeVersion { get; set; }

    [Column("document_id")]
    public long? DocumentId { get; set; }

    [Column("document_id_as_guid")]
    public Guid? DocumentIdAsGuid { get; set; }

    [Column("extends", TypeName = "character varying")]
    public string Extends { get; set; }

    [Column("qr_code_state_id")]
    public int QrCodeStateId { get; set; }

    [Column("expire_at", TypeName = "timestamp without time zone")]
    public DateTime? ExpireAt { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("settings_doc_id")]
    public long? SettingsDocId { get; set; }

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

    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization Organization { get; set; } = null!;

    [ForeignKey(nameof(ParentId))]
    public virtual QrCodeRegistry Parent { get; set; }

    [ForeignKey(nameof(QrCodeStateId))]
    public virtual QrCodeState QrCodeState { get; set; } = null!;

    [ForeignKey(nameof(QrCodeTypeId))]
    public virtual QrCodeType QrCodeType { get; set; } = null!;

    [ForeignKey(nameof(SettingsDocId))]
    public virtual MachineReadableCodeSetting SettingsDoc { get; set; }

    #endregion

    #region Methods

    #endregion
}
