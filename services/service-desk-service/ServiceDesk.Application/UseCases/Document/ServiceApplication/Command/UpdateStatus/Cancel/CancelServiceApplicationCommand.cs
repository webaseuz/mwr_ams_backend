using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CancelServiceApplicationCommand :
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}
