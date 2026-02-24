using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class InProcessServiceApplicationCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}
