using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class GetTransportUseTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}
