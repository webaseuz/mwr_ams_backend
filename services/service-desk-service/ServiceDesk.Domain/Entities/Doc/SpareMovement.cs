
using Bms.Core.Domain;
using Bms.Core.Domain.Domains;
using Bms.WEBASE.Models;
using ServiceDesk.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("doc_spare_movement")]
public class SpareMovement :
	Entity,
	IDocumentEntity,
	IHaveIdProp<long>
{
    public SpareMovement()
    {
        Histories = new HashSet<SpareMovementHistory>();
        Tables = new HashSet<SpareMovementTable>();
    }
	#region Properties
	[Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateTime DocDate { get; set; }

    [Column("movement_type_id")]
    public int MovementTypeId { get; set; }

    [Column("from_branch_id")]
    public int? FromBranchId { get; set; }

    [Column("to_branch_id")]
    public int? ToBranchId { get; set; }

    [Column("from_user_id")]
    public int? FromUserId { get; set; }

    [Column("to_user_id")]
    public int? ToUserId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

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

	[InverseProperty(nameof(SpareMovementHistory.Owner))]
    public virtual ICollection<SpareMovementHistory> Histories { get; set; } = new List<SpareMovementHistory>();

    [InverseProperty(nameof(SpareMovementTable.Owner))]
    public virtual ICollection<SpareMovementTable> Tables { get; set; } = new List<SpareMovementTable>();

    [ForeignKey(nameof(FromBranchId))]
    public virtual Branch FromBranch { get; set; }

    [ForeignKey(nameof(FromUserId))]
    public virtual User FromUser { get; set; }

    [ForeignKey(nameof(MovementTypeId))]
    public virtual MovementType MovementType { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; } = null!;

    [ForeignKey(nameof(ToBranchId))]
    public virtual Branch ToBranch { get; set; }

    [ForeignKey(nameof(ToUserId))]
    public virtual User ToUser { get; set; }
	#endregion

	#region Methods
	public void Create()
		=> UpdateStatus(StatusIdConst.CREATED);


	public void Update()
		=> UpdateStatus(StatusIdConst.MODIFIED);


	public void Delete()
		=> UpdateStatus(StatusIdConst.DELETED);


	public void Accept()
		=> UpdateStatus(StatusIdConst.ACCEPTED);


	public void Cancel()
		=> UpdateStatus(StatusIdConst.CANCELLED);


	public void Send()
		=> UpdateStatus(StatusIdConst.SEND);


	public void Revoke()
		=> UpdateStatus(StatusIdConst.REVOKED);


	public void UpdateStatus(int statusId)
	{
		if (!StatusIdConst.CanSpareMovementStatus(StatusId, statusId))
			throw ClientLogicalExceptionHelper.NotAllowedStatus();

		StatusId = statusId;
	}
	public void AddHistory(Guid fileId, string userInfo)
	{
		Guid historyFileId = Guid.NewGuid();

		Histories.Add(new SpareMovementHistory
		{
			OwnerId = Id,
			HistoryFileId = fileId,
			StatusId = StatusId,
			Message = "Message",
			UserInfo = userInfo
		});
	}
	#endregion
}
