using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationBriefDto
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime DocDate { get; set; }
    public int BranchId { get; set; }
    public int DeviceId { get; set; }
    public int ExecutorTypeId { get; set; }
    public long? ServiceContractorId { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string PhoneNumber { get; set; }
    public int? ProcessDuration { get; set; }
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime? EndAt { get; set; }
    public string ApplicationDesc { get; set; }
    public string ProblemDesc { get; set; }
    public string ExecutorComment { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public string BranchName { get; set; }
    public string DeviceTypeName { get; set; }
    public string DeviceModelName { get; set; }
    public string ExecutorTypeName { get; set; }
    public string SerialNumber { get; set; }
    public string ServiceContractorName { get; set; }
    public string ResponsiblePersonName { get; set; }
    public DateTime CreatedAt { get; set; }

    #region Can
    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanCancelByExecutor { get; set; }
    public bool CanCancelByClient { get; set; }
    public bool CanSend { get; set; }
    public bool CanRevoke { get; set; }
    public bool CanFinish { get; set; }
    public bool CanFinishByExecutor { get; set; }
    public bool CanInProcess { get; set; }
    public bool CanWaitSpares { get; set; }
    public bool CanFail { get; set; }
    #endregion
}
