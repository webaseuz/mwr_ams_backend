using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("sys_qr_code_registry", Schema = "qr")]
[Index("QrCodeTypeId", "UniqueKey", Name = "ix__sys_qr_code_registry_cd_typeid_unique_key")]
[Index("QrCodeTypeId", "DocumentId", Name = "ix__sys_qr_code_registry_typeid_docid")]
[Index("UniqueKey", Name = "uix__sys_qr_code_registry_unique_key", IsUnique = true)]
public partial class SysQrCodeRegistry
{
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
    public string? Extends { get; set; }

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
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [InverseProperty("QrCodeRegistry")]
    public virtual ICollection<HlDriver> HlDrivers { get; set; } = new List<HlDriver>();

    [InverseProperty("QrCodeRegistry")]
    public virtual ICollection<HlTransport> HlTransports { get; set; } = new List<HlTransport>();

    [InverseProperty("Parent")]
    public virtual ICollection<SysQrCodeRegistry> InverseParent { get; set; } = new List<SysQrCodeRegistry>();

    [ForeignKey("OrganizationId")]
    [InverseProperty("SysQrCodeRegistries")]
    public virtual InfoOrganization Organization { get; set; } = null!;

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual SysQrCodeRegistry? Parent { get; set; }

    [ForeignKey("QrCodeStateId")]
    [InverseProperty("SysQrCodeRegistries")]
    public virtual EnumQrCodeState QrCodeState { get; set; } = null!;

    [ForeignKey("QrCodeTypeId")]
    [InverseProperty("SysQrCodeRegistries")]
    public virtual EnumQrCodeType QrCodeType { get; set; } = null!;

    [ForeignKey("SettingsDocId")]
    [InverseProperty("SysQrCodeRegistries")]
    public virtual DocMachineReadableCodeSetting? SettingsDoc { get; set; }
}
