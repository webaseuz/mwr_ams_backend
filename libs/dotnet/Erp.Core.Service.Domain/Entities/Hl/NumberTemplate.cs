using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_number_template")]
public class NumberTemplate :
    BaseEntity<int>
{
    #region Properties

    [Column("date")]
    public DateTime Date { get; set; }

    [Column("document")]
    [StringLength(100)]
    public string Document { get; set; }

    [Column("template")]
    [StringLength(250)]
    public string Template { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? LastModifiedAt { get; set; }

    [Column("modified_by")]
    public int? LastModifiedBy { get; set; }

    #endregion

    #region
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization Organization { get; set; } = null!;

    #endregion

}
