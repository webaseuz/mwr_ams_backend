using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBASE;

namespace Erp.Core.Service.Domain;

[Table("info_bank", Schema = "adm")]
public class Bank :
    BaseEntity<int>, IWbStateProp
{
    public Bank()
    {
        Translates = new HashSet<BankTranslate>();
    }

    #region Properties

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("bank_code")]
    [StringLength(5)]
    public string BankCode { get; set; } = null!;

    [Column("code")]
    [StringLength(50)]
    public string Code { get; set; }

    [Column("inn")]
    [StringLength(20)]
    public string Inn { get; set; }

    [Column("address")]
    [StringLength(500)]
    public string Address { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? LastModifiedAt { get; set; }

    [Column("modified_by")]
    public int? LastModifiedBy { get; set; }

    #endregion

    #region Relationships
    [InverseProperty(nameof(BankTranslate.Owner))]
    public virtual ICollection<BankTranslate> Translates { get; set; } = new List<BankTranslate>();

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    #endregion

}
