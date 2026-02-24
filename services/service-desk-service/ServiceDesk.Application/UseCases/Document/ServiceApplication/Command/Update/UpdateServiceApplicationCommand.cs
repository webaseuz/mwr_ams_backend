using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    public DateTime DocDate { get; set; }
    public int BranchId { get; set; }
    public int? DeviceTypeId { get; set; }
    public int DeviceId { get; set; }
    public int ExecutorTypeId { get; set; }
    public long? ServiceContractorId { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string PhoneNumber { get; set; }
    public int? ProcessDuration { get; set; }
    public DateTime? EndAt { get; set; }
    public string ApplicationDesc { get; set; }
    public string ProblemDesc { get; set; }
    public string ExecutorComment { get; set; }
    public List<UpdateServiceApplicationFileCommand> Files { get; set; }
    public List<UpdateServiceApplicationExecutorFileCommand> ExecutorFiles { get; set; }
    public List<UpdateServiceApplicationPartCommand> Parts { get; set; }
    public List<UpdateServiceApplicationSpareCommand> Spares { get; set; }
}
