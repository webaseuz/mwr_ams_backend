using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;
[Table("hl_transport_file")]
public class TransportFile :
    IFileEntity
{
    #region Properties
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("file_name")]
    [StringLength(250)]
    public string FileName { get; set; } = null!;

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
    #endregion

    #region Relationships
    [ForeignKey(nameof(OwnerId))]
    public virtual Transport Owner { get; set; } = null!;
    #endregion

    #region Methods

    #endregion
}
