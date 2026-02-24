using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.QrCodeStates;

public class GetQrCodeStateSelectListQuery :
    IRequest<SelectList<int>>
{
}
