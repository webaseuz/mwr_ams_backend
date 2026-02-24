using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportTypes;

public class DeleteTransportTypeCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
