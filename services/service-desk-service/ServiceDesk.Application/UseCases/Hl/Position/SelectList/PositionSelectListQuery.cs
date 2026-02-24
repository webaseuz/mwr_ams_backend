using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Positions;
public class PositionSelectListQuery : IRequest<SelectList<int>>
{

}

