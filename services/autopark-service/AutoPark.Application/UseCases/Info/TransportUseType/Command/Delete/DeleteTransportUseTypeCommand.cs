using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class DeleteTransportUseTypeCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
