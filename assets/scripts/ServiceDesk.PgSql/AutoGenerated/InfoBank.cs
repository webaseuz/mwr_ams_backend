using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("info_bank")]
public partial class InfoBank
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
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("bank_code")]
    [StringLength(5)]
    public string BankCode { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<InfoBankTranslate> InfoBankTranslates { get; set; } = new List<InfoBankTranslate>();

    [InverseProperty("Bank")]
    public virtual ICollection<InfoContractor> InfoContractors { get; set; } = new List<InfoContractor>();

    [InverseProperty("Bank")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoBanks")]
    public virtual EnumState State { get; set; } = null!;
}
