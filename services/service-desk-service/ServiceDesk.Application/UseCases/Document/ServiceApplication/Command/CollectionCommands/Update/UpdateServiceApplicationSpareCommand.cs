using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationSpareCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int DeviceSpareTypeId { get; set; }
    public int Quantity { get; set; }
}
