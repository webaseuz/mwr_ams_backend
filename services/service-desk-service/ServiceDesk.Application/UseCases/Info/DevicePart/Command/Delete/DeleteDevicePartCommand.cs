using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class DeleteDevicePartCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}