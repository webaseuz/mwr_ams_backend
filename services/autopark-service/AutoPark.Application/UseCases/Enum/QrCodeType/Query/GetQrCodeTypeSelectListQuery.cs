using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Enum.QrCodeTypes;

public class GetQrCodeTypeSelectListQuery : IRequest<SelectList<int>>
{
}
