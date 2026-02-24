using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_transport_model_file")]
public class TransportModelFile : IFileEntity
{
    #region Properties
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("file_name")]
    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [Column("transport_model_id")]
    public int TransportModelId { get; set; }

    [Column("transport_color_id")]
    public int TransportColorId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; } = false;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }
    #endregion

    #region Relationships
    [ForeignKey(nameof(TransportModelId))]
    public virtual TransportModel TransportModel { get; set; } = null!;

    [ForeignKey(nameof(TransportColorId))]
    public virtual TransportColor TransportColor { get; set; } = null!;
    #endregion

    #region Methods
    // Add any custom methods here if needed
    #endregion
}