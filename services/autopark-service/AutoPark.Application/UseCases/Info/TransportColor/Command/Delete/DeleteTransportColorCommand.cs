using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class DeleteTransportColorCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
