using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.QrCodeStates;

public class GetQrCodeStateSelectListQuery :
    IRequest<SelectList<int>>
{
}
