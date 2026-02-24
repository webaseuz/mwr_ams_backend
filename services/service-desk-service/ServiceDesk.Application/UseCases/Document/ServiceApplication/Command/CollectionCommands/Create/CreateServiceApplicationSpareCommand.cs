using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationSpareCommand :
    IRequest<IHaveId<long>>
{
    public long OwnerId { get; set; }
    public int DeviceSpareTypeId { get; set; }
    public int Quantity { get; set; }
}
