using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("hl_number_template")]
public class NumberTemplate :
    IHaveIdProp<int>
{
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

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
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    #endregion

    #region
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization Organization { get; set; } = null!;

    #endregion

    #region Methods
    #endregion
}
