using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class DeleteDeviceTypeCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}