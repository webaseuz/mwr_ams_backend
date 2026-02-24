using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class DeleteTransportSettingCommand :
    IRequest<SuccessResult<bool>>
{
    public long Id { get; set; }
}
