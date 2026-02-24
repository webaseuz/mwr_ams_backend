using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Positions;
public class PositionSelectListQuery : IRequest<SelectList<int>>
{

}

