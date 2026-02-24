using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Enum;

public class GetStatusSelectListQuery : IRequest<SelectList<int>>
{
}
