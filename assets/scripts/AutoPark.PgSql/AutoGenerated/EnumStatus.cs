using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_status")]
public partial class EnumStatus
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
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<DocExpenseHistory> DocExpenseHistories { get; set; } = new List<DocExpenseHistory>();

    [InverseProperty("Status")]
    public virtual ICollection<DocExpense> DocExpenses { get; set; } = new List<DocExpense>();

    [InverseProperty("Status")]
    public virtual ICollection<DocMachineReadableCodeSettingHistory> DocMachineReadableCodeSettingHistories { get; set; } = new List<DocMachineReadableCodeSettingHistory>();

    [InverseProperty("Status")]
    public virtual ICollection<DocMachineReadableCodeSetting> DocMachineReadableCodeSettings { get; set; } = new List<DocMachineReadableCodeSetting>();

    [InverseProperty("Status")]
    public virtual ICollection<DocRefuelHistory> DocRefuelHistories { get; set; } = new List<DocRefuelHistory>();

    [InverseProperty("Status")]
    public virtual ICollection<DocRefuel> DocRefuels { get; set; } = new List<DocRefuel>();

    [InverseProperty("Status")]
    public virtual ICollection<DocTransportSetting> DocTransportSettings { get; set; } = new List<DocTransportSetting>();

    [InverseProperty("Owner")]
    public virtual ICollection<EnumStatusTranslate> EnumStatusTranslates { get; set; } = new List<EnumStatusTranslate>();
}
