using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("sys_table")]
public partial class SysTable
{
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

    [InverseProperty("Table")]
    public virtual ICollection<AccSpareTurnover> AccSpareTurnovers { get; set; } = new List<AccSpareTurnover>();
}
