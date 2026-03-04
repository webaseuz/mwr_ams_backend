using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("sys_table", Schema = "adm")]
public class Table : BaseEntity<int>
{
    [Column("short_name")]
    public string ShortName { get; set; }

    [Column("full_name")]
    public string FullName { get; set; }

    [Column("db_schema_name")]
    public string DbSchemaName { get; set; }

    [Column("db_table_name")]
    public string DbTableName { get; set; }

    [Column("table_type")]
    public string TableType { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("last_modified_at")]
    public DateTime? LastModifiedAt { get; set; }

    [Column("last_modified_by")]
    public int? LastModifiedBy { get; set; }

    [InverseProperty(nameof(TableTranslate.Owner))]
    public virtual ICollection<TableTranslate> Translates { get; set; }

    /*[InverseProperty(nameof(FileConfig.Table))]
    public virtual ICollection<FileConfig> FileConfigs { get; set; }*/
}
