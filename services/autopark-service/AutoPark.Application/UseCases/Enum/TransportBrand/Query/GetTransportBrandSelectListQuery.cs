using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class GetTransportBrandSelectListQuery :
    IRequest<SelectList<int>>
{
}
