using AutoPark.Domain.Constants;
using Bms.Core.Domain;
using Bms.Core.Domain.Domains;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_transport_setting")]
public class TransportSetting :
    Entity,
    IDocumentEntity,
    IHaveIdProp<long>
{
    public TransportSetting()
    {
        Files = new HashSet<TransportSettingFile>();
        Batteries = new HashSet<TransportSettingBattery>();
        Oils = new HashSet<TransportSettingOil>();
        Inspections = new HashSet<TransportSettingInspection>();
        Insurances = new HashSet<TransportSettingInsurance>();
        Fuels = new HashSet<TransportSettingFuel>();
        Tires = new HashSet<TransportSettingTire>();
        Liquids = new HashSet<TransportSettingLiquid>();
        Histories = new HashSet<TransportSettingHistory>();
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

    [Column("transport_id")]
    public int TransportId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("manager_id")]
    public long? ManagerId { get; set; }

    [Column("license_number")]
    [StringLength(50)]
    public string LicenseNumber { get; set; } = null!;

    [Column("license_end_at")]
    public DateTime LicenseEndAt { get; set; }

    [Column("poa_number")]
    [StringLength(50)]
    public string PoaNumber { get; set; } = null!;

    [Column("poa_end_at")]
    public DateTime PoaEndAt { get; set; }

    [Column("manager_full_name")]
    [StringLength(250)]
    public string ManagerFullName { get; set; }

    //[Column("load_capacity", TypeName = "NUMERIC(18,2)")]
    //public decimal LoadCapacity { get; set; }

    [Column("seat_count")]
    public int SeatCount { get; set; }

    [Column("odometr_indicator", TypeName = "NUMERIC(18,2)")]
    public decimal OdometrIndicator { get; set; }

    [Column("fuel_card_number")]
    [StringLength(50)]
    public string FuelCardNumber { get; set; } = null!;

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("message")]
    public string Message { get; set; }
    [Column("worked_hours")]
    public int WorkedHours { get; set; }
    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("status_id")]
    public int StatusId { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    #endregion

    #region Relations
    [InverseProperty(nameof(TransportSettingBattery.Owner))]
    public virtual ICollection<TransportSettingBattery> Batteries { get; set; } = new List<TransportSettingBattery>();

    [InverseProperty(nameof(TransportSettingFuel.Owner))]
    public virtual ICollection<TransportSettingFuel> Fuels { get; set; } = new List<TransportSettingFuel>();

    [InverseProperty(nameof(TransportSettingInspection.Owner))]
    public virtual ICollection<TransportSettingInspection> Inspections { get; set; } = new List<TransportSettingInspection>();

    [InverseProperty(nameof(TransportSettingInsurance.Owner))]
    public virtual ICollection<TransportSettingInsurance> Insurances { get; set; } = new List<TransportSettingInsurance>();

    [InverseProperty(nameof(TransportSettingLiquid.Owner))]
    public virtual ICollection<TransportSettingLiquid> Liquids { get; set; } = new List<TransportSettingLiquid>();

    [InverseProperty(nameof(TransportSettingOil.Owner))]
    public virtual ICollection<TransportSettingOil> Oils { get; set; } = new List<TransportSettingOil>();

    [InverseProperty(nameof(TransportSettingTire.Owner))]
    public virtual ICollection<TransportSettingTire> Tires { get; set; } = new List<TransportSettingTire>();

    [InverseProperty(nameof(TransportSettingHistory.Owner))]
    public virtual ICollection<TransportSettingHistory> Histories { get; set; } = new List<TransportSettingHistory>();

    [InverseProperty(nameof(TransportSettingFile.Owner))]
    public virtual ICollection<TransportSettingFile> Files { get; set; } = new List<TransportSettingFile>();

    [ForeignKey(nameof(DriverId))]
    public virtual Driver Driver { get; set; } = null!;

    [ForeignKey(nameof(ResponsiblePersonId))]
    public virtual Person ResponsiblePerson { get; set; } = null!;

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; private set; }

    [ForeignKey(nameof(TransportId))]
    public virtual Transport Transport { get; set; } = null!;

    [ForeignKey(nameof(ManagerId))]
    public virtual Person Manager { get; set; }

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


    public void UpdateStatus(int statusId)
    {
        if (!StatusIdConst.CanTransportSettingStatus(StatusId, statusId))
            throw ClientLogicalExceptionHelper.NotAllowedStatus();

        StatusId = statusId;
        //AddDomainEvent(new StatusChangedEvent<long>(ownerId: Id,
        //                      statusId: statusId,
        //                      message: Message,
        //                      dataAsJson: JsonConvert.SerializeObject(this)));
    }
    public void AddHistory(Guid fileId, string userInfo)
    {
        Guid historyFileId = Guid.NewGuid();

        Histories.Add(new TransportSettingHistory
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
