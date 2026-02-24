using Bms.WEBASE.Helpers;
using Bms.WEBASE.Models;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationDto :
        IHaveIdProp<long>
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime DocDate { get; set; }
    public int BranchId { get; set; }
    public int? DeviceTypeId { get; set; }
    public int DeviceId { get; set; }
    public string DeviceName { get; set; }
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
    public string ServiceContractorName { get; set; }
    public string ResponsiblePersonName { get; set; }
    public string SerialNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ServiceApplicationFileDto> Files { get; set; } = new();
    public List<ServiceApplicationExecutorFileDto> ExecutorFiles { get; set; } = new();
    public List<ServiceApplicationPartDto> Parts { get; set; } = new();
    public List<ServiceApplicationSpareDto> Spares { get; set; } = new();

    #region Action Controls
    public bool CanCreateForAllBranch { get; set; }
    public bool CanEditExecutor { get; set; }
    #endregion
}
