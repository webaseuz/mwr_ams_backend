using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationExecutorFileCommand :
    IRequest<IHaveId<long>>
{
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}
