using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_code_form_type", Schema = "qr")]
public partial class EnumCodeFormType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("CodeFormType")]
    public virtual ICollection<DocMachineReadableCodeSettingTable> DocMachineReadableCodeSettingTables { get; set; } = new List<DocMachineReadableCodeSettingTable>();

    [InverseProperty("CodeFormType")]
    public virtual ICollection<DocMachineReadableCodeSetting> DocMachineReadableCodeSettings { get; set; } = new List<DocMachineReadableCodeSetting>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumCodeFormTypes")]
    public virtual EnumState State { get; set; } = null!;
}
