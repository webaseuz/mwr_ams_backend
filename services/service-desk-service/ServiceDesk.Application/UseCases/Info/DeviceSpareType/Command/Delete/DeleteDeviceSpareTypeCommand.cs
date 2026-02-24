using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class DeleteDeviceSpareTypeCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}