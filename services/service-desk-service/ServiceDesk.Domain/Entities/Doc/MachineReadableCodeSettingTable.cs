using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("doc_machine_readable_code_setting_table", Schema = "qr")]
public class MachineReadableCodeSettingTable :
    IHaveIdProp<long>
{
	#region Properties
	[Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("code_form_type_id")]
    public int? CodeFormTypeId { get; set; }

    [Column("has_prefex")]
    public bool HasPrefex { get; set; }

    [Column("is_uuid")]
    public bool IsUuid { get; set; }

    [Column("prefex")]
    [StringLength(10)]
    public string Prefex { get; set; }

    [Column("next_template_length")]
    public int? NextTemplateLength { get; set; }

    [Column("next_template_letter_count")]
    public int? NextTemplateLetterCount { get; set; }

    [Column("next_template_number_count")]
    public int? NextTemplateNumberCount { get; set; }

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
    #endregion

	#region Relationships
	[ForeignKey(nameof(CodeFormTypeId))]
    public virtual CodeFormType CodeFormType { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public virtual MachineReadableCodeSetting Owner { get; set; } = null!;

    #endregion

    #region Methods
    #endregion
}
