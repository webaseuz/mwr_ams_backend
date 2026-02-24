using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Transports;

public class DeleteTransportCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
