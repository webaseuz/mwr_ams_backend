using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class GetTransportColorSelectListQuery :
    IRequest<SelectList<int>>
{
}
