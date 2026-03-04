using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_driver_document")]
public class DriverDocument :
    BaseEntity<long>
{
    #region Properties
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
    [Column("document_file_name")]
    [StringLength(250)]
    public string DocumentFileName { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

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
    [ForeignKey(nameof(OwnerId))]
    public virtual Driver Owner { get; set; } = null!;
    [ForeignKey(nameof(DocumentTypeId))]
    public virtual DocumentType DocumentType { get; set; }

    #endregion

}
