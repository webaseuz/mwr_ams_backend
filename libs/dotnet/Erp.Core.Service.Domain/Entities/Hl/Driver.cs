using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_driver")]
public class Driver :
    BaseEntity<int>
{
    public Driver()
    {
        Settings = new HashSet<TransportSetting>();
        Documents = new HashSet<DriverDocument>();
    }

    #region Properties

    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("unique_code")]
    public Guid UniqueCode { get; set; }

    [Column("qr_code_registry_id")]
    public Guid? QrCodeRegistryId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

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
    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey(nameof(PersonId))]
    public virtual Person Person { get; set; } = null!;

    [ForeignKey(nameof(QrCodeRegistryId))]
    public virtual QrCodeRegistry QrCodeRegistry { get; set; }

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    [InverseProperty(nameof(DriverDocument.Owner))]
    public virtual ICollection<DriverDocument> Documents { get; set; }

    [InverseProperty(nameof(TransportSetting.Driver))]
    public virtual ICollection<TransportSetting> Settings { get; set; }

    #endregion

}
