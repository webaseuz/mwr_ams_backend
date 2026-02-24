using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Enum.QrCodeTypes;

public class GetQrCodeTypeSelectListQuery : IRequest<SelectList<int>>
{
}
