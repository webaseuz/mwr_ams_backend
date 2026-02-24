using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class DeleteDeviceModelCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}