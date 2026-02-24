using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingInspectionCommand :
    IRequest<IHaveId<long>>
{
    public DateTime DateAt { get; set; }
    public DateTime ExpireAt { get; set; }
    public int ResponsiblePersonId { get; set; }
    public string Details { get; set; }
    public int NotifyBeforeDay { get; set; }
}
