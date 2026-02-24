using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Devices;

public class DeleteDeviceCommand : IRequest<SuccessResult<bool>>
{
     public int Id { get; set; }
}
