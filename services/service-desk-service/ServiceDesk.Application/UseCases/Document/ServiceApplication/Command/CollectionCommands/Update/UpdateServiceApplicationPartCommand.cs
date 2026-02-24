using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationPartCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int? DevicePartId { get; set; }
    public int ApplicationPurposeId { get; set; }
    public int? ServiceTypeId { get; set; }
    public string AdditionalDesc { get; set; }
}
