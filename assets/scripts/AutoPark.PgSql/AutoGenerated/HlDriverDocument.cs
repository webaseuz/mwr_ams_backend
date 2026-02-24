using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_driver_document")]
[Index("OwnerId", Name = "indx_hl_driver_document_own_id")]
public partial class HlDriverDocument
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("document_type_id")]
    public int DocumentTypeId { get; set; }

    [Column("document_number")]
    [StringLength(50)]
    public string DocumentNumber { get; set; } = null!;

    [Column("document_start_on", TypeName = "timestamp without time zone")]
    public DateTime? DocumentStartOn { get; set; }

    [Column("document_end_on", TypeName = "timestamp without time zone")]
    public DateTime? DocumentEndOn { get; set; }

    [Column("document_file_id")]
    public Guid? DocumentFileId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [ForeignKey("OwnerId")]
    [InverseProperty("HlDriverDocuments")]
    public virtual HlDriver Owner { get; set; } = null!;
}
