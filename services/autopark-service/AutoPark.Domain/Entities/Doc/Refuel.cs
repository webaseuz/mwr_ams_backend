using AutoPark.Domain.Constants;
using Bms.Core.Domain;
using Bms.Core.Domain.Domains;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_refuel")]
public class Refuel :
    Entity,
    IDocumentEntity,
    IHaveIdProp<long>
{
    public Refuel()
    {
        Files = new HashSet<RefuelFile>();
        Histories = new HashSet<RefuelHistory>();
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

    [Column("branch_id")]
    public int? BranchId { get; set; }

    [Column("fuel_card_id")]
    public int FuelCardId { get; set; }

    [Column("transport_id")]
    public int TransportId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("fuel_type_id")]
    public int FuelTypeId { get; set; }

    [Column("latitude", TypeName = "numeric(18,6)")]
    public decimal? Latitude { get; set; }

    [Column("longitude", TypeName = "numeric(18,6)")]
    public decimal? Longitude { get; set; }

    [Column("litre", TypeName = "NUMERIC(18,2)")]
    public decimal Litre { get; set; }

    [Column("litre_price", TypeName = "NUMERIC(18,2)")]
    public decimal LitrePrice { get; set; } = 0;

    [Column("cheque_number")]
    [StringLength(50)]
    public string ChequeNumber { get; set; } = null!;

    [Column("address")]
    [StringLength(500)]
    public string Address { get; set; } = null!;

    [Column("message")]
    public string Message { get; set; }

    [Column("status_id")]
    public int StatusId { get; private set; }

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
    [InverseProperty(nameof(RefuelFile.Owner))]
    public virtual ICollection<RefuelFile> Files { get; set; } = new List<RefuelFile>();

    [InverseProperty(nameof(RefuelHistory.Owner))]
    public virtual ICollection<RefuelHistory> Histories { get; private set; } = new List<RefuelHistory>();

    [ForeignKey(nameof(DriverId))]
    public virtual Driver Driver { get; set; } = null!;

    [ForeignKey(nameof(FuelCardId))]
    public virtual FuelCard FuelCard { get; set; } = null!;

    [ForeignKey(nameof(FuelTypeId))]
    public virtual FuelType FuelType { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; private set; }

    [ForeignKey(nameof(TransportId))]
    public virtual Transport Transport { get; set; } = null!;

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;
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
        if (!StatusIdConst.CanRefuelStatus(StatusId, statusId))
            throw ClientLogicalExceptionHelper.NotAllowedStatus();

        StatusId = statusId;
    }

    public void AddHistory(Guid fileId, string userInfo)
    {
        Guid historyFileId = Guid.NewGuid();

        Histories.Add(new RefuelHistory
        {
            OwnerId = Id,
            HistoryFileId = fileId,
            StatusId = StatusId,
            Message = Message,
            UserInfo = userInfo
        });
    }
    #endregion
}
