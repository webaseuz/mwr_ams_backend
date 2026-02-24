using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Enum;

public class GetTransportTypeSelectListQuery : IRequest<SelectList<int>>
{
}
