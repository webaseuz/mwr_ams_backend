using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_driver")]
public class Driver :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public Driver()
    {
        Settings = new HashSet<TransportSetting>();
        Documents = new HashSet<DriverDocument>();
    }

    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("unique_code")]
    public Guid UniqueCode { get; set; }

    [Column("qr_code_registry_id")]
    public Guid? QrCodeRegistryId { get; set; }

    [Column("state_id")]
    public int StateId { get; private set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

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

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;

    #endregion
}
