using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class DeleteTransportBrandCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
