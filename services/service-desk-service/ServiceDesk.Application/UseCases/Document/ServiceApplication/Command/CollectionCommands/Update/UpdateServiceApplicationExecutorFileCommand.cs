using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationExecutorFileCommand :
    IHaveIdProp<Guid>,
    IRequest<IHaveId<Guid>>
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}
