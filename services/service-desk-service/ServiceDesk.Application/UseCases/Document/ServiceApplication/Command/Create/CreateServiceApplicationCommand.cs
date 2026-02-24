using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationCommand :
    IRequest<IHaveId<long>>
{
    public string DocNumber { get; set; } = null!;
    public DateTime DocDate { get; set; }
    public int? BranchId { get; set; }
    public int DeviceId { get; set; }
    public int ExecutorTypeId { get; set; }
    public long? ServiceContractorId { get; set; }
    public long ResponsiblePersonId { get; set; }
    public int? DeviceTypeId { get; set; }
    public string PhoneNumber { get; set; }
    public int? ProcessDuration { get; set; }
    public string ApplicationDesc { get; set; }
    public string ProblemDesc { get; set; }
    public string ExecutorComment { get; set; }
    public List<CreateServiceApplicationFileCommand> Files { get; set; }
    public List<CreateServiceApplicationExecutorFileCommand> ExecutorFiles { get; set; }
    public List<CreateServiceApplicationPartCommand> Parts { get; set; }
    public List<CreateServiceApplicationSpareCommand> Spares { get; set; }
}
