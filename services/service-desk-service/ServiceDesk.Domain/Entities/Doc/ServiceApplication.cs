using ServiceDesk.Domain.Constants;
using Bms.Core.Domain;
using Bms.Core.Domain.Domains;
using Bms.Core.Domain.Events;
using Bms.WEBASE.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("doc_service_application")]
public class ServiceApplication :
    Entity,
    IDocumentEntity,
    IHaveIdProp<long>
{
    public ServiceApplication()
    {
        ServiceApplicationParts = new HashSet<ServiceApplicationPart>();
        ServiceApplicationFiles = new HashSet<ServiceApplicationFile>();
        ServiceApplicationExecutorFiles = new HashSet<ServiceApplicationExecutorFile>();
        ServiceApplicationHistories = new HashSet<ServiceApplicationHistory>();
        ServiceApplicationSpares = new HashSet<ServiceApplicationSpare>();
    }
    #region Properties
    [Column("id")]
    public long Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateTime DocDate { get; set; }

    [Column("branch_id")]
    public int? BranchId { get; set; }

    [Column("device_type_id")]
    public int? DeviceTypeId { get; set; }

    [Column("device_id")]
    public int DeviceId { get; set; }

    [Column("executor_type_id")]
    public int ExecutorTypeId { get; set; }

    [Column("service_contractor_id")]
    public long? ServiceContractorId { get; set; }

    [Column("responsible_person_id")]
    public long ResponsiblePersonId { get; set; }

    [Column("phone_number")]
    [StringLength(50)]
    public string PhoneNumber { get; set; }

    [Column("process_duration")]
    public int? ProcessDuration { get; set; }

    [Column("end_at", TypeName = "timestamp without time zone")]
    public DateTime? EndAt { get; set; }

    [Column("application_desc")]
    public string ApplicationDesc { get; set; }

    [Column("problem_desc")]
    public string ProblemDesc { get; set; }

    [Column("executor_comment")]
    public string ExecutorComment { get; set; }

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
    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey(nameof(DeviceId))]
    public virtual Device Device { get; set; } = null!;

    [InverseProperty(nameof(ServiceApplicationExecutorFile.Owner))]
    public virtual ICollection<ServiceApplicationExecutorFile> ServiceApplicationExecutorFiles { get; set; } = new List<ServiceApplicationExecutorFile>();

    [InverseProperty(nameof(ServiceApplicationFile.Owner))]
    public virtual ICollection<ServiceApplicationFile> ServiceApplicationFiles { get; set; } = new List<ServiceApplicationFile>();

    [InverseProperty(nameof(ServiceApplicationHistory.Owner))]
    public virtual ICollection<ServiceApplicationHistory> ServiceApplicationHistories { get; set; } = new List<ServiceApplicationHistory>();

    [InverseProperty(nameof(ServiceApplicationPart.Owner))]
    public virtual ICollection<ServiceApplicationPart> ServiceApplicationParts { get; set; } = new List<ServiceApplicationPart>();
    
    [InverseProperty(nameof(ServiceApplicationPart.Owner))]
    public virtual ICollection<ServiceApplicationSpare> ServiceApplicationSpares { get; set; } = new List<ServiceApplicationSpare>();

    [ForeignKey(nameof(ExecutorTypeId))]
    public virtual ExecutorType ExecutorType { get; set; } = null!;

    [ForeignKey(nameof(DeviceTypeId))]
    public virtual DeviceType DeviceType { get; set; } = null!;

    [ForeignKey(nameof(ResponsiblePersonId))]
    public virtual Person ResponsiblePerson { get; set; } = null!;

    [ForeignKey(nameof(ServiceContractorId))]
    public virtual Contractor ServiceContractor { get; set; }

    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; } = null!;
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


    public void InProcess()
        => UpdateStatus(StatusIdConst.IN_PROCESS);


    public void Finish()
        => UpdateStatus(StatusIdConst.FINISHED);


    public void CancelByClient()
        => UpdateStatus(StatusIdConst.CANCELED_BY_CLIENT);


    public void CancelByExecutor()
        => UpdateStatus(StatusIdConst.CANCELED_BY_EXECUTOR);


    public void FinishByExecutor()
        => UpdateStatus(StatusIdConst.FINISHED_BY_EXECUTOR);
    

    public void WaitSpares()
        => UpdateStatus(StatusIdConst.WAIT_SPARES);
    

    public void Fail()
        => UpdateStatus(StatusIdConst.FAILED);


    public void UpdateStatus(int statusId)
    {
        if (!StatusIdConst.CanServiceApplicationStatus(StatusId, statusId))
            throw ClientLogicalExceptionHelper.NotAllowedStatus();      

        StatusId = statusId;
        //AddDomainEvent(new StatusChangedEvent<long>(ownerId: Id,
        //                                            statusId: statusId,
        //                                            message: "Message",
        //                                            dataAsJson: JsonConvert.SerializeObject(this)));
    }

    public void AddHistory(Guid fileId, string userInfo)
    {
        Guid historyFileId = Guid.NewGuid();

        ServiceApplicationHistories.Add(new ServiceApplicationHistory
        {
            OwnerId = Id,
            HistoryFileId = fileId,
            StatusId = StatusId,
            UserInfo = userInfo
        });
    }

    #endregion
}
