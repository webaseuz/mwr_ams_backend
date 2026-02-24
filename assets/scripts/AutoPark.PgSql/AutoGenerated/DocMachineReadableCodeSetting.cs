using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_machine_readable_code_setting", Schema = "qr")]
public partial class DocMachineReadableCodeSetting
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateOnly DocDate { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("code_form_type_id")]
    public int? CodeFormTypeId { get; set; }

    [Column("code_type_id")]
    public int CodeTypeId { get; set; }

    [Column("has_prefex")]
    public bool HasPrefex { get; set; }

    [Column("is_uuid")]
    public bool IsUuid { get; set; }

    [Column("prefex")]
    [StringLength(10)]
    public string? Prefex { get; set; }

    [Column("next_template_length")]
    public int? NextTemplateLength { get; set; }

    [Column("next_template_letter_count")]
    public int? NextTemplateLetterCount { get; set; }

    [Column("next_template_number_count")]
    public int? NextTemplateNumberCount { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [ForeignKey("CodeFormTypeId")]
    [InverseProperty("DocMachineReadableCodeSettings")]
    public virtual EnumCodeFormType? CodeFormType { get; set; }

    [ForeignKey("CodeTypeId")]
    [InverseProperty("DocMachineReadableCodeSettings")]
    public virtual EnumQrCodeType CodeType { get; set; } = null!;

    [InverseProperty("Owner")]
    public virtual ICollection<DocMachineReadableCodeSettingHistory> DocMachineReadableCodeSettingHistories { get; set; } = new List<DocMachineReadableCodeSettingHistory>();

    [InverseProperty("Owner")]
    public virtual ICollection<DocMachineReadableCodeSettingTable> DocMachineReadableCodeSettingTables { get; set; } = new List<DocMachineReadableCodeSettingTable>();

    [ForeignKey("StatusId")]
    [InverseProperty("DocMachineReadableCodeSettings")]
    public virtual EnumStatus Status { get; set; } = null!;

    [InverseProperty("SettingsDoc")]
    public virtual ICollection<SysQrCodeRegistry> SysQrCodeRegistries { get; set; } = new List<SysQrCodeRegistry>();
}
