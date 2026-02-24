using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransmissionBoxTypes;

public class GetTransmissionBoxTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}

