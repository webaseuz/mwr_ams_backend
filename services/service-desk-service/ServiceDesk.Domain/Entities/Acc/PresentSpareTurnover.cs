using Bms.Core.Domain.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ServiceDesk.Domain;

[Table("acc_present_spare_turnover")]
public class PresentSpareTurnover
{
    public PresentSpareTurnover()
    {
        SpareTurnovers = new HashSet<SpareTurnover>();
    }

    #region Properties
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("device_spare_type_id")]
    public int DeviceSpareTypeId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

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
    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey(nameof(DeviceSpareTypeId))]
    public virtual DeviceSpareType DeviceSpareType { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [InverseProperty(nameof(SpareTurnover.PresentSpareTurnover))]
    public virtual ICollection<SpareTurnover> SpareTurnovers { get; set; }

    #endregion

    #region Methods

    public static PresentSpareTurnover CreatePresentSpareTurnoverEntity(SpareTurnoverItemParameter parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        var entity = new PresentSpareTurnover();

        entity.Id = Guid.NewGuid();
        entity.BranchId = parameters.FromBranchId ?? parameters.ToBranchId.Value;
        entity.UserId = parameters.FromUserId ?? parameters.ToUserId;
        entity.DeviceSpareTypeId = parameters.DeviceSpareTypeId;
        entity.Quantity = parameters.Quantity;

        entity.SpareTurnovers.Add(SpareTurnover.AddSpareTurnover(parameters));

        return entity;
    }

    public void UpdatePresentSpareTurnoverEntity(SpareTurnoverItemParameter parameter)
    {
        ArgumentNullException.ThrowIfNull(parameter);

        Quantity = SpareTurnovers
            .Where(st => !st.IsDeleted)
            .Sum(st => st.IsDebit ? st.Quantity : -st.Quantity);

        if (parameter.IsDebit)
            Quantity += parameter.Quantity;
        else
            Quantity -= parameter.Quantity;
    }
    #endregion
}