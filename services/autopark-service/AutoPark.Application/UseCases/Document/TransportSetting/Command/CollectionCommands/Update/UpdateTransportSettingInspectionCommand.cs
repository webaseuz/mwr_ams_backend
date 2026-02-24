using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingInspectionCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public DateTime DateAt { get; set; }
    public long OwnerId { get; set; }
    public DateTime ExpireAt { get; set; }
    public int ResponsiblePersonId { get; set; }
    public string Details { get; set; }
    public int NotifyBeforeDay { get; set; }
}
