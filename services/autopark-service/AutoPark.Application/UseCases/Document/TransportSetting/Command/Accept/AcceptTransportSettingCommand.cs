using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class AcceptTransportSettingCommand
     : IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}
