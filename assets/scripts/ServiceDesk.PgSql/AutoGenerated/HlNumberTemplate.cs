using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("hl_number_template")]
public partial class HlNumberTemplate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime Date { get; set; }

    [Column("document")]
    [StringLength(100)]
    public string Document { get; set; } = null!;

    [Column("template")]
    [StringLength(250)]
    public string Template { get; set; } = null!;

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

    [ForeignKey("OrganizationId")]
    [InverseProperty("HlNumberTemplates")]
    public virtual InfoOrganization Organization { get; set; } = null!;
}
