using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("sys_table")]
public class Table :
	IHaveIdProp<int>
{
    public Table()
    {
        SpareTurnovers = new HashSet<SpareTurnover>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("short_name")]
    [StringLength(100)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(200)]
    public string FullName { get; set; } = null!;

    [Column("db_table_name")]
    [StringLength(100)]
    public string DbTableName { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }
	#endregion

	#region Relationships
	[InverseProperty(nameof(SpareTurnover.Table))]
    public virtual ICollection<SpareTurnover> SpareTurnovers { get; set; } = new List<SpareTurnover>();
	#endregion
}
