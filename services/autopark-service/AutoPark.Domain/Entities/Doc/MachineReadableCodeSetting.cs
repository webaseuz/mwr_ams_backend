using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain
{
    [Table("doc_machine_readable_code_setting", Schema = "qr")]
    public class MachineReadableCodeSetting :
        IHaveIdProp<long>
    {
        public MachineReadableCodeSetting()
        {
            Histories = new HashSet<MachineReadableCodeSettingHistory>();
            Tables = new HashSet<MachineReadableCodeSettingTable>();
            QrCodeRegistries = new HashSet<QrCodeRegistry>();
        }
        #region
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("doc_number")]
        [StringLength(50)]
        public string DocNumber { get; set; } = null!;

        [Column("doc_date")]
        public DateTime DocDate { get; set; }

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
        public string Prefex { get; set; }

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

        #endregion

        #region Relationships
        [ForeignKey(nameof(CodeFormTypeId))]
        public virtual CodeFormType CodeFormType { get; set; }

        [ForeignKey(nameof(CodeTypeId))]
        public virtual QrCodeType CodeType { get; set; } = null!;

        [ForeignKey(nameof(StatusId))]
        public virtual Status Status { get; set; } = null!;

        [InverseProperty(nameof(MachineReadableCodeSettingHistory.Owner))]
        public virtual ICollection<MachineReadableCodeSettingHistory> Histories { get; set; } = new List<MachineReadableCodeSettingHistory>();

        [InverseProperty(nameof(MachineReadableCodeSettingTable.Owner))]
        public virtual ICollection<MachineReadableCodeSettingTable> Tables { get; set; } = new List<MachineReadableCodeSettingTable>();
        [InverseProperty(nameof(QrCodeRegistry.SettingsDoc))]
        public virtual ICollection<QrCodeRegistry> QrCodeRegistries { get; set; } = new List<QrCodeRegistry>();

        #endregion

        #region Methods
        #endregion
    }
}
